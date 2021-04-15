using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PauseClick", 0);
        GameObject P1 = GameObject.Find(PlayerPrefs.GetString("P1-Name"));
        Vector3 temp = new Vector3(-300, 415, -2);
        P1.transform.position = temp;
        GameObject P2 = GameObject.Find(PlayerPrefs.GetString("P2-Name"));
        temp = new Vector3(-100, 415, -2);
        P2.transform.position = temp;
        GameObject P3 = GameObject.Find(PlayerPrefs.GetString("P3-Name"));
        temp = new Vector3(100, 415, -2);
        P3.transform.position = temp;
        GameObject P4 = GameObject.Find(PlayerPrefs.GetString("P4-Name"));
        temp = new Vector3(300, 415, -2);
        P4.transform.position = temp;
    }
}
