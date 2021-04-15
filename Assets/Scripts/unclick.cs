using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class unclick : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("setup") == 0)
        {
            PlayerPrefs.SetInt("Clicked", 0);
            PlayerPrefs.SetInt("P1-Clicked", 0);
            PlayerPrefs.SetInt("P2-Clicked", 0);
            PlayerPrefs.SetInt("P3-Clicked", 0);
            PlayerPrefs.SetInt("P4-Clicked", 0);
            GameObject P1 = GameObject.Find("P1");
            P1.GetComponent<P1Combat>().OnMouseExit();
            if (PlayerPrefs.GetInt("Processing") != 1)
            {
                GameObject PDiss = GameObject.Find("PDiss");
                PDiss.transform.position = new Vector3(-3000, 0, 0);
            }
            PlayerPrefs.SetString("ActiveSkill", "None");
        }
    }
}