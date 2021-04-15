using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    void OnMouseDown()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        PlayerPrefs.SetString("lastLoadedScene", PlayerPrefs.GetString("lastLoadedScene2"));
        SceneManager.LoadScene(sceneName);
    }
}