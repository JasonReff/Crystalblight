using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventNumber : MonoBehaviour
{
    public Text textbox;
    // Start is called before the first frame update
    void Start()
    {
        int e = PlayerPrefs.GetInt("enc1");
        textbox.text = e.ToString();
    }
}
