using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Set : MonoBehaviour
{
    public GoToMap GoMap;
    public Text textbox;
    public EnemyAllocation enemyAllocation;
    void OnMouseEnter()
    {
        string playerName = this.name.Remove(this.name.Length - 4, 4);
        GameObject playerPic = GameObject.Find(playerName);
        Vector3 temp = new Vector3(693, -250, -2);
        playerPic.transform.position = temp;
        textbox.text = playerName + ":" + "\n" + "VIT: " + PlayerPrefs.GetInt(playerName + "-VIT") + "\n" + 
            "STR: " + PlayerPrefs.GetInt(playerName + "-STR") + "\n" + "INT: " + PlayerPrefs.GetInt(playerName + "-INT") + "\n" + 
            "DEX: " + PlayerPrefs.GetInt(playerName + "-DEX") + "\n" + "END: " + PlayerPrefs.GetInt(playerName + "-END");
    }

    void OnMouseExit()
    {
        string playerName = this.name.Remove(this.name.Length - 4, 4);
        GameObject playerPic = GameObject.Find(playerName);
        Vector3 temp = new Vector3(1500, -250, -2);
        playerPic.transform.position = temp;
        textbox.text = "Overview";
    }

    void OnMouseDown()
    {
        string playerName = this.name.Remove(this.name.Length - 4, 4);
        PlayerPrefs.SetString("SelectedCharacter", playerName);
        GameObject disciplineDiss = GameObject.Find("DisciplineDiss");
        disciplineDiss.transform.localPosition = new Vector3(0, 0, -2);
        GameObject disciplineDisplay = GameObject.Find("DisciplineDisplay");
        disciplineDisplay.transform.localPosition = new Vector3(0, 0, -3);
        GameObject disciplineText = GameObject.Find("DisciplineText");
        disciplineText.transform.localPosition = new Vector3(0, 0, -3);
        GameObject.Find("Discipline1Text").GetComponent<Text>().text = PlayerPrefs.GetString(playerName + "Discipline1");
        GameObject.Find("Discipline2Text").GetComponent<Text>().text = PlayerPrefs.GetString(playerName + "Discipline2");
        GameObject.Find("Discipline3Text").GetComponent<Text>().text = PlayerPrefs.GetString(playerName + "Discipline3");
        for (int x = 1; x <= 3; x++)
        {
            GameObject.Find("Discipline" + x + "DescriptionText").GetComponent<Text>().text = "Skill: " + PlayerPrefs.GetString(playerName + "Level1Skill" + x) + "\n" +
                "Special: " + PlayerPrefs.GetString(playerName + "Discipline" + x + "Special") + "\n" + "Ultimate: " + PlayerPrefs.GetString(playerName + "-Ultimate" + x);
        }
    }
}
