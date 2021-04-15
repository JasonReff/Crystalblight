using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viewSeed : MonoBehaviour
{
    public Text textbox;
    void OnMouseDown()
    {
        int seed = PlayerPrefs.GetInt("seed");
        textbox.text = "Seed: " + seed;
    }
}
