using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHPSP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("P1-CHP", PlayerPrefs.GetInt("P1-HP"));
        PlayerPrefs.SetInt("P2-CHP", PlayerPrefs.GetInt("P2-HP"));
        PlayerPrefs.SetInt("P1-CSP", PlayerPrefs.GetInt("P1-SP"));
        PlayerPrefs.SetInt("P2-CSP", PlayerPrefs.GetInt("P2-SP"));
    }
}
