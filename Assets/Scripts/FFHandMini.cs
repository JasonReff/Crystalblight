using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFHandMini : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameObject Hand = GameObject.Find("FFHand");
        Hand.transform.position = transform.position + new Vector3(-40, 0, 0);
    }
    void OnMouseExit()
    {
        GameObject Hand = GameObject.Find("FFHand");
        Hand.transform.position = new Vector3(-3000, 0, 0);
    }
}
