using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpDone : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("LevelUpStatSelected") == 1 && PlayerPrefs.GetInt("LevelUpSkillSelected") == 1)
           {
            GameObject pIcon = GameObject.Find("PIconLevelUp");
            string playerNameHead = pIcon.GetComponent<SpriteRenderer>().sprite.name;
            string playerName = playerNameHead.Remove(playerNameHead.Length - 4, 4);
            int playerNumber = PlayerPrefs.GetInt(playerName + "P");
            string skill1 = PlayerPrefs.GetString("P" + playerNumber + "-Skill-1");
            int passiveNumber = Int32.Parse(PlayerPrefs.GetString(skill1 + "ID")[PlayerPrefs.GetString(skill1 + "ID").Length - 1].ToString());
            int playerLevel = PlayerPrefs.GetInt("P" + playerNumber + "-Level");
            LevelUpSkillChoice.PassiveStatBoost(playerNumber, playerName, playerLevel, passiveNumber);
            GameObject levelUpDisplay = GameObject.Find("LevelUpDisplay");
            levelUpDisplay.transform.localPosition = new Vector3(0, -2000, -1);
            GameObject.Find("LevelUpCanvas").transform.localPosition = new Vector3(0, -2000, -1);
            GameObject.Find("RewardsBackground").transform.localPosition = new Vector3(0, 0, -1);
            PlayerPrefs.SetInt("LevelUpStatSelected", 0);
            PlayerPrefs.SetInt("LevelUpSkillSelected", 0);
            if (PlayerPrefs.GetInt("P1LevelUpAvailable") == 0 && PlayerPrefs.GetInt("P2LevelUpAvailable") == 0)
            {
                LoadSprite.FindSprite(GameObject.Find("MapButton"), "MapButton");
            }
        }
    }
}
