using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStatChoice : MonoBehaviour
{

    public void OnMouseDown()
    {
        GameObject pIcon = GameObject.Find("PIconLevelUp");
        string playerNameHead = pIcon.GetComponent<SpriteRenderer>().sprite.name;
        string playerName = playerNameHead.Remove(playerNameHead.Length - 4, 4);
        int playerNumber = PlayerPrefs.GetInt(playerName + "P");
        string statName = this.name.Remove(this.name.Length - 8, 8);
        int statValue = PlayerPrefs.GetInt("P" + playerNumber + "-" + statName);
        statValue++;
        //PlayerPrefs.SetInt("P" + playerNumber + "-" + statName, statValue);
        GameObject statText = GameObject.Find("Player" + statName + "Text");
        GameObject.Find("PlayerHPText").GetComponent<Text>().text = "HP: " + PlayerPrefs.GetInt("P" + playerNumber + "-CHP").ToString() + "/" + PlayerPrefs.GetInt("P" + playerNumber + "-HP");
        if (statName == "VIT") { GameObject.Find("PlayerHPText").GetComponent<Text>().text = "HP: " + PlayerPrefs.GetInt("P" + playerNumber + "-CHP").ToString() + "/" + (PlayerPrefs.GetInt("P" + playerNumber + "-HP") + 20); }
        GameObject.Find("PlayerSPText").GetComponent<Text>().text = "SP: " + PlayerPrefs.GetInt("P" + playerNumber + "-CSP").ToString() + "/" + PlayerPrefs.GetInt("P" + playerNumber + "-SP");
        if (statName == "INT") { GameObject.Find("PlayerSPText").GetComponent<Text>().text = "SP: " + PlayerPrefs.GetInt("P" + playerNumber + "-CSP").ToString() + "/" + (PlayerPrefs.GetInt("P" + playerNumber + "-SP") + 10); }
        GameObject.Find("PlayerVITText").GetComponent<Text>().text = "VIT: " + PlayerPrefs.GetInt("P" + playerNumber + "-VIT").ToString();
        GameObject.Find("PlayerINTText").GetComponent<Text>().text = "INT: " + PlayerPrefs.GetInt("P" + playerNumber + "-INT").ToString();
        GameObject.Find("PlayerDEXText").GetComponent<Text>().text = "DEX: " + PlayerPrefs.GetInt("P" + playerNumber + "-DEX").ToString();
        GameObject.Find("PlayerSTRText").GetComponent<Text>().text = "STR: " + PlayerPrefs.GetInt("P" + playerNumber + "-STR").ToString();
        GameObject.Find("PlayerENDText").GetComponent<Text>().text = "END: " + PlayerPrefs.GetInt("P" + playerNumber + "-END").ToString();
        statText.GetComponent<Text>().text = statName + ": " + statValue;
        PlayerPrefs.SetInt("LevelUpStatSelected", 1);
        GameObject.Find("VITIncrease").transform.localScale = new Vector3((float)0.075, (float)0.075, 1);
        GameObject.Find("INTIncrease").transform.localScale = new Vector3((float)0.075, (float)0.075, 1);
        GameObject.Find("DEXIncrease").transform.localScale = new Vector3((float)0.075, (float)0.075, 1);
        GameObject.Find("STRIncrease").transform.localScale = new Vector3((float)0.075, (float)0.075, 1);
        GameObject.Find("ENDIncrease").transform.localScale = new Vector3((float)0.075, (float)0.075, 1);
        GameObject.Find(statName + "Increase").transform.localScale = new Vector3((float)0.1, (float)0.1, 1);
    }
}
