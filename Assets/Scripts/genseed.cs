using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class genseed : MonoBehaviour
{
    public static int seed = 69;
    void OnMouseDown()
    {
        //makes seed from date and time
        int time = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = time;
        // the seed a number in that range
        seed = UnityEngine.Random.Range(0, 99999999);
        //stores seed in player prefs for use in other scenes
        PlayerPrefs.SetInt("seed", seed);
    }
}