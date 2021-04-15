using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour
{
    void OnMouseDown(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}