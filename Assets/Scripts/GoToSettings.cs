using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSettings : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerPrefs.SetString("lastLoadedScene2", PlayerPrefs.GetString("lastLoadedScene"));
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        Application.LoadLevel("Settings");
    }
}
