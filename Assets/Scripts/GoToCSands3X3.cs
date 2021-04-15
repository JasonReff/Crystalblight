using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCSands3X3 : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerPrefs.SetInt("IW-Set", 0);
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        Application.LoadLevel("CombatSands");
    }
}
