using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamblerAllocation : MonoBehaviour
{

    public void GamblerSet()
    {
        int gamblerLimit = PlayerPrefs.GetInt("GamblerLimit");
        for (int gamblerNumber = 1; gamblerNumber <= gamblerLimit; gamblerNumber++)
        {
            int random = 1;//int random = UnityEngine.Random.Range(1,5)
            if (random == 1)
            {
                PlayerPrefs.SetString("Gambler" + gamblerNumber + "Type", "Trade");
            }
            else if (random == 2)
            {
                PlayerPrefs.SetString("Gambler" + gamblerNumber + "Type", "Oracle");
            }
            else if (random == 3)
            {
                PlayerPrefs.SetString("Gambler" + gamblerNumber + "Type", "Investment");
            }
            else if (random == 4)
            {
                PlayerPrefs.SetString("Gambler" + gamblerNumber + "Type", "Wheel");
            }
        }
    }

}
