using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewEnc : MonoBehaviour
{
    public Text textbox;
    void Update()
    {
        textbox.text = "Enc1: " + PlayerPrefs.GetInt("enc1")+"\n"+"Enc2: "+ PlayerPrefs.GetInt("enc2");
    }
}
