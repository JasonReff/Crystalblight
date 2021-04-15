using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class getRandomNumber : MonoBehaviour
    {
        public Text textbox;
        // Start is called before the first frame update
    private float[] noiseValues;
    public string seed = "";
    void OnMouseDown()
    {
        Random.seed = 15;
        noiseValues = new float[10];
        int i = 0;
        seed = "";
        while (i < noiseValues.Length)
        {
            noiseValues[i] = Random.value;
            seed = seed + noiseValues[i];
            i++;
        }
    }

    void Update()
        {
            textbox.text = "" + seed;
        }
    }