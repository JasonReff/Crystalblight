using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCharSelect : MonoBehaviour
{
    public void OnMouseDown()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        Application.LoadLevel("CharacterSelect");
    }
}
