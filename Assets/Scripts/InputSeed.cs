using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputSeed : MonoBehaviour
{
    public InputField iField;
    public Text textbox;
    public Gengame gen;
    public GoToCharSelect gochar;
    void OnMouseDown()
    {
        string seedStr = iField.text;
        int seed;
        bool isParsable = Int32.TryParse(seedStr, out seed);
        if (isParsable)
        {
            if (0 <= seed && seed <= 99999999)
            {
                PlayerPrefs.SetInt("seed", seed);
                gen.OnMouseDown();
                gochar.OnMouseDown();
            }
            else
            {
                textbox.text = "Bad Seed";
            }
        }
        else
        {
            textbox.text = "Bad Seed";
        }
    }
}
