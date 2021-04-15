using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EssenceSourceConfirm : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (PlayerPrefs.GetString("EssenceButtonClicked") == "CharacterHeal")
        {
            int p = PlayerPrefs.GetInt("EssenceCharacterClicked");
            int HP = PlayerPrefs.GetInt("P" + p + "-CHP");
            int maxHP = PlayerPrefs.GetInt("P" + p + "-HP");
            int SP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int maxSP = PlayerPrefs.GetInt("P" + p + "-SP");
            HP += (maxHP / 2);
            SP += (maxSP / 2);
            if (HP > maxHP) { HP = maxHP; }
            if (SP > maxSP) { SP = maxSP; }
            PlayerPrefs.SetInt("P" + p + "-CHP", HP);
            PlayerPrefs.SetInt("P" + p + "-CSP", SP);
        }
        else if (PlayerPrefs.GetString("EssenceButtonClicked") == "PartyHeal")
        {
            for (int p = 1; p <= 4; p++)
            {
                if (PlayerPrefs.GetString("P" + p + "-Name") != "null")
                {
                    int HP = PlayerPrefs.GetInt("P" + p + "-CHP");
                    int maxHP = PlayerPrefs.GetInt("P" + p + "-HP");
                    int SP = PlayerPrefs.GetInt("P" + p + "-CSP");
                    int maxSP = PlayerPrefs.GetInt("P" + p + "-SP");
                    HP += (maxHP / 5);
                    SP += (maxSP / 5);
                    if (HP > maxHP) { HP = maxHP; }
                    if (SP > maxSP) { SP = maxSP; }
                    PlayerPrefs.SetInt("P" + p + "-CHP", HP);
                    PlayerPrefs.SetInt("P" + p + "-CSP", SP);
                }
            }
        }
        Vector3 position = GameObject.Find("EssenceDiss").transform.localPosition;
        GameObject.Find("EssenceDiss").transform.localPosition = new Vector3(position.x, position.y, -3);
        GameObject.Find("ConfirmText").GetComponent<Text>().text = "Confirmed!";
        Invoke("GoToMap", 2.0f);
    }

    private void GoToMap()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Map- Hexagon");
    }
}
