using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void selectMenuButton(string scene)
    {
        Application.LoadLevel(scene);
    }
}
