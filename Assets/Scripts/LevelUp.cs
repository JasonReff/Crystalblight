using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    public GameObject button;

    public void OnMouseDown()
    {
        int playerNumber = Int32.Parse(button.name[1].ToString());
        LoadLevelUp(playerNumber);
    }

    public void LoadLevelUp(int playerNumber)
    {
        int playerLevel = PlayerPrefs.GetInt("P" + playerNumber + "-Level");
        GameObject.Find("RewardsBackground").transform.localPosition = new Vector3(-3000, 0, -1);
        for (int x = 1; x<=2; x++) { GameObject.Find("P" + x + "XPText").transform.localPosition = new Vector3(0, 0, 2); }
        GameObject levelUpDisplay = GameObject.Find("LevelUpDisplay");
        levelUpDisplay.transform.localPosition = new Vector3(0, 0, -1);
        GameObject.Find("LevelUpCanvas").transform.localPosition = new Vector3(0, 0, -1);
        GameObject pIconLevelUp = GameObject.Find("PIconLevelUp");
        LoadSprite.FindSprite(pIconLevelUp, PlayerPrefs.GetString("P" + playerNumber + "-Name") + "Head");
        GameObject playerHPText = GameObject.Find("PlayerHPText");
        playerHPText.GetComponent<Text>().text = "HP: " + PlayerPrefs.GetInt("P" + playerNumber + "-CHP") + "/" + PlayerPrefs.GetInt("P" + playerNumber + "-HP");
        GameObject playerSPText = GameObject.Find("PlayerSPText");
        playerSPText.GetComponent<Text>().text = "SP: " + PlayerPrefs.GetInt("P" + playerNumber + "-CSP") + "/" + PlayerPrefs.GetInt("P" + playerNumber + "-SP");
        GameObject playerVITText = GameObject.Find("PlayerVITText");
        playerVITText.GetComponent<Text>().text = "VIT: " + PlayerPrefs.GetInt("P" + playerNumber + "-VIT").ToString();
        GameObject playerDEXText = GameObject.Find("PlayerDEXText");
        playerDEXText.GetComponent<Text>().text = "DEX: " + PlayerPrefs.GetInt("P" + playerNumber + "-DEX").ToString();
        GameObject playerENDText = GameObject.Find("PlayerENDText");
        playerENDText.GetComponent<Text>().text = "END: " + PlayerPrefs.GetInt("P" + playerNumber + "-END").ToString();
        GameObject playerINTText = GameObject.Find("PlayerINTText");
        playerINTText.GetComponent<Text>().text = "INT: " + PlayerPrefs.GetInt("P" + playerNumber + "-INT").ToString();
        GameObject playerSTRText = GameObject.Find("PlayerSTRText");
        playerSTRText.GetComponent<Text>().text = "STR: " + PlayerPrefs.GetInt("P" + playerNumber + "-STR").ToString();
        //present skill options
        if (playerLevel == 3 || playerLevel == 5 || playerLevel == 7) 
        {
            LoadSprite.FindSprite(GameObject.Find("SkillChoice1"), "block");
            LoadSprite.FindSprite(GameObject.Find("SkillChoice2"), "block");
            LoadSprite.FindSprite(GameObject.Find("SkillChoice3"), "block");
            GameObject passiveSkill = GameObject.Find("PassiveSkill");
            passiveSkill.transform.localPosition = new Vector3(0, -1000, -1);
            GameObject.Find("PassiveSkillText").GetComponent<Text>().text = "";
            GameObject.Find("PassiveDescriptionText").GetComponent<Text>().text = "";
            GameObject playerLevelText = GameObject.Find("PlayerLevelText");
            playerLevelText.GetComponent<Text>().text = "You are now Level" + playerLevel + ". Choose one attribute to increase and one skill to learn.";
            for (int i = 1; i <= 3; i++)
            {
                LevelUpSkillChoice.SkillChoice(i, playerNumber, playerLevel);
                //makes sure skills are different
                if (PlayerPrefs.GetString("SkillOption" + i) == PlayerPrefs.GetString("SkillOption" + i--) || PlayerPrefs.GetString("SkillOption3") == PlayerPrefs.GetString("SkillOption1")) { i--; }
            }
        }
        if (playerLevel == 2 || playerLevel == 4 || playerLevel == 6)
        {
            for (int i = 1; i<= 3; i++)
            {
                GameObject skillChoice = GameObject.Find("SkillChoice" + i);
                skillChoice.transform.localPosition = new Vector3(0,-500, -1);
                GameObject skillOption = GameObject.Find("SkillOption" + i);
                skillOption.GetComponent<Text>().text = "";
                GameObject skillOptionDescription = GameObject.Find("SkillOption" + i + "Description");
                skillOptionDescription.GetComponent<Text>().text = "";
                GameObject skillOptionSP = GameObject.Find("SkillOption" + i + "SP");
                skillOptionSP.GetComponent<Text>().text = "";
            }
            GameObject playerLevelText = GameObject.Find("PlayerLevelText");
            playerLevelText.GetComponent<Text>().text = "You are now Level" + playerLevel + ". Choose one attribute to increase. You have also learned a new Passive Skill.";
            GameObject passiveSkill = GameObject.Find("PassiveSkill");
            LoadSprite.FindSprite(passiveSkill, "block");
            string playerName = PlayerPrefs.GetString("P" + playerNumber + "-Name");
            string skill1 = PlayerPrefs.GetString("P" + playerNumber + "-Skill-1");
            int passiveNumber = Int32.Parse(PlayerPrefs.GetString(skill1 + "ID")[PlayerPrefs.GetString(skill1 + "ID").Length - 1].ToString());
            string passiveName = PlayerPrefs.GetString(playerName + "Level" + playerLevel + "Skill" + passiveNumber);
            PlayerPrefs.SetString("P" + playerNumber + "-PassiveSkill", passiveName);
            string passiveNameDescription = PlayerPrefs.GetString(PlayerPrefs.GetString(passiveName + "ID") + "Description");
            GameObject passiveDescriptionText = GameObject.Find("PassiveSkillText");
            passiveDescriptionText.GetComponent<Text>().text = passiveNameDescription;
            GameObject.Find("PassiveSkillText").GetComponent<Text>().text = passiveName;
        }
        //need to implement level 8+
        if (playerLevel >= 8)
        {

        }
    }
}