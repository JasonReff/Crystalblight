using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class buttonhover : MonoBehaviour
{
    public void OnMouseEnter()
    {
        transform.localScale = transform.localScale * 1.1f;
    }

    void OnMouseExit()
    {
        transform.localScale = transform.localScale / 1.1f;
    }
}