using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSkillChoice : MonoBehaviour
{

    public static void SkillChoice(int i, int playerNumber, int playerLevel)
    {
        int skillChoice = UnityEngine.Random.Range(1, 7);
        PlayerPrefs.SetString("SkillOption" + i, PlayerPrefs.GetString(PlayerPrefs.GetString("P" + playerNumber + "-Name") + "Level" + playerLevel + "Skill" + skillChoice));
        //sets text correlating to found skill
        GameObject skillOption = GameObject.Find("SkillOption" + i);
        skillOption.GetComponent<Text>().text = PlayerPrefs.GetString("SkillOption" + i);
        GameObject skillOptionDescription = GameObject.Find("SkillOption" + i + "Description");
        skillOptionDescription.GetComponent<Text>().text = PlayerPrefs.GetString(PlayerPrefs.GetString("P" + playerNumber + "-Name") + "Level" + playerLevel + "Skill" + skillChoice + "Description");
        GameObject skillOptionSP = GameObject.Find("SkillOption" + i + "SP");
        skillOptionSP.GetComponent<Text>().text = PlayerPrefs.GetString(PlayerPrefs.GetString("P" + playerNumber + "-Name") + "Level" + playerLevel + "Skill" + skillChoice + "SP");
    }

    public void OnMouseDown()
    {
        if (this.name[0].ToString() == "S") {
            GameObject pIcon = GameObject.Find("PIconLevelUp");
            string playerNameHead = pIcon.GetComponent<SpriteRenderer>().sprite.name;
            string playerName = playerNameHead.Remove(playerNameHead.Length - 4, 4);
            int playerNumber = PlayerPrefs.GetInt(playerName + "P");
            int skillChoice = Int32.Parse(this.name[11].ToString());
            int playerLevel = PlayerPrefs.GetInt("P" + playerNumber + "-Level");
            int skillTier = 1;
            switch (playerLevel)
            {
                case 3:
                    {
                        skillTier = 2;
                        break;
                    }
                case 5:
                    {
                        skillTier = 3;
                        break;
                    }
                case 7:
                    {
                        skillTier = 4;
                        break;
                    }
                default: break;
            }
            //PlayerPrefs.SetString("P" + playerNumber + "-Skill-" + skillTier, PlayerPrefs.GetString("SkillOption" + skillChoice));
            GameObject.Find("SkillChoice1").transform.localScale = new Vector3((float)0.25, (float)0.25, 1);
            GameObject.Find("SkillChoice2").transform.localScale = new Vector3((float)0.25, (float)0.25, 1);
            GameObject.Find("SkillChoice3").transform.localScale = new Vector3((float)0.25, (float)0.25, 1);
            GameObject.Find("SkillChoice" + skillChoice).transform.localScale = new Vector3((float)0.30, (float)0.30, 1);
            PlayerPrefs.SetInt("LevelUpSkillSelected", 1);
        }
        if (this.name[0].ToString() == "P")
        {
            GameObject pIcon = GameObject.Find("PIconLevelUp");
            string playerNameHead = pIcon.GetComponent<SpriteRenderer>().sprite.name;
            string playerName = playerNameHead.Remove(playerNameHead.Length - 4, 4);
            int playerNumber = PlayerPrefs.GetInt(playerName + "P");
            string skill1 = PlayerPrefs.GetString("P" + playerNumber + "-Skill-1");
            int passiveNumber = Int32.Parse(PlayerPrefs.GetString(skill1 + "ID")[PlayerPrefs.GetString(skill1 + "ID").Length - 1].ToString());
            int playerLevel = PlayerPrefs.GetInt("P" + playerNumber + "-Level");
            switch (playerLevel)
            {
                case 2:
                    {
                        PlayerPrefs.SetString("P" + playerNumber + "-PassiveSkill", PlayerPrefs.GetString(playerName + "Level2Skill" + passiveNumber));
                        break;
                    }
                case 4:
                    {
                        PlayerPrefs.SetString("P" + playerNumber + "-PassiveSkill", PlayerPrefs.GetString(playerName + "Level4Skill" + passiveNumber));
                        break;
                    }
                case 6:
                    {
                        PlayerPrefs.SetString("P" + playerNumber + "-PassiveSkill", PlayerPrefs.GetString(playerName + "Level6Skill" + passiveNumber));
                        break;
                    }
            }
            GameObject.Find("PassiveSkill").transform.localScale = new Vector3((float)0.45, (float)0.43, 1);
            PlayerPrefs.SetInt("LevelUpSkillSelected", 1);
        }
    }

    public static void PassiveStatBoost(int p, string playerName, int level, int passiveNumber)
    {
        string passiveSkill = PlayerPrefs.GetString(playerName + "Level" + level + "Skill" + passiveNumber);
        switch (passiveSkill)
        {
            case ("Iron Will1"):
                PlayerPrefs.SetInt("P" + p + "-END", PlayerPrefs.GetInt("P" + p + "-END") + 1);
                break;
            case ("Iron Will3"):
                PlayerPrefs.SetInt("P" + p + "-END", PlayerPrefs.GetInt("P" + p + "-END") + 1);
                break;
            case ("Storm Claws2"):
                PlayerPrefs.SetInt("P" + p + "-DEX", PlayerPrefs.GetInt("P" + p + "-DEX") + 1);
                break;
            case ("Storm Claws3"):
                PlayerPrefs.SetInt("P" + p + "-DEX", PlayerPrefs.GetInt("P" + p + "-DEX") + 1);
                break;
            default: break;
        }
        float percentHP = PlayerPrefs.GetInt("P" + p + "-CHP") / PlayerPrefs.GetInt("P" + p + "-HP");
        PlayerPrefs.SetInt("P" + p + "-HP", 40 + 20 * PlayerPrefs.GetInt("P1-VIT"));
        PlayerPrefs.SetInt("P" + p + "-CHP", (int)(percentHP * PlayerPrefs.GetInt("P" + p + "-HP")));
        float percentSP = PlayerPrefs.GetInt("P" + p + "-CSP") / PlayerPrefs.GetInt("P" + p + "-SP");
        PlayerPrefs.SetInt("P" + p + "-SP", 30 + 10 * PlayerPrefs.GetInt("P1-INT"));
        PlayerPrefs.SetInt("P" + p + "-CSP", (int)(percentSP * PlayerPrefs.GetInt("P" + p + "-SP")));
        PlayerPrefs.SetInt("P" + p + "-Attack", 5 + 2 * PlayerPrefs.GetInt("P1-STR"));
        PlayerPrefs.SetInt("P" + p + "-Guard", 10 * PlayerPrefs.GetInt("P1-END"));
        PlayerPrefs.SetInt("P" + p + "-DefGuard", 2 * PlayerPrefs.GetInt("P1-END"));
        PlayerPrefs.SetInt("P" + p + "-Accuracy", 85 + PlayerPrefs.GetInt("P1-DEX"));
        PlayerPrefs.SetInt("P" + p + "-Dodge", 5 + PlayerPrefs.GetInt("P1-DEX"));
        PlayerPrefs.SetInt("P" + p + "-CritRate", 5 + 2 * PlayerPrefs.GetInt("P1-DEX"));
    }
}
