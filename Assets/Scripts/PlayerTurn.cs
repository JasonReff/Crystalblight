using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public void Begin()
    {
        GameObject FullDiss = GameObject.Find("FullDiss");
        FullDiss.transform.position = new Vector3(0, 0, -100);
        GetComponent<Rigidbody>().velocity = new Vector3(1500, 0, 0);
        Invoke("Pause", 1.0f);
    }
    public void Pause()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Invoke("Go", 1.5f);
    }
    public void Go()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(1500, 0, 0);
        Invoke("Stop", 1.3f);
    }
    public void Stop()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GameObject FullDiss = GameObject.Find("FullDiss");
        FullDiss.transform.position = new Vector3(-3000, 0, 0);
        transform.position = new Vector3(-1430, 0, 0);
    }
}
