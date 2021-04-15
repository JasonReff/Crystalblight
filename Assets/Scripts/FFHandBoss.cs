using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFHandBoss : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameObject Hand = GameObject.Find("FFHand");
        Hand.transform.position = transform.position + new Vector3(-60, 0, 0);
    }
    void OnMouseExit()
    {
        GameObject Hand = GameObject.Find("FFHand");
        Hand.transform.position = new Vector3(-3000, 0, 0);
    }
}
