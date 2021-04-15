using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsScreen : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("P1LevelUpAvailable", 0);
        PlayerPrefs.SetInt("P2LevelUpAvailable", 0);
    }

    public void OnMouseDown()
    {
        RewardDisplay(PlayerPrefs.GetString("CurrentStage"));
    }

    public static void RewardDisplay(string currentStage)
    {
        if (PlayerPrefs.GetInt("RewardDisplayOn") == 0)
        {
            PlayerPrefs.SetInt("RewardDisplayOn", 1);
            string tile = PlayerPrefs.GetString("CurrentTile");
            int combatNumber = 0;
            if (tile.Length == 7)
            {
                combatNumber = Int32.Parse(tile[6].ToString());
            }
            if (tile.Length == 8)
            {
                combatNumber = Int32.Parse(tile[6].ToString() + tile[7].ToString());
            }
            for (int i = 1; i <= 2; i++)
            {
                PlayerXP(currentStage, combatNumber, i);
            }
            GameObject rewardsBackground = GameObject.Find("RewardsBackground");
            rewardsBackground.transform.localPosition = new Vector3(0, 0, -1);
            GameObject mapButton = GameObject.Find("MapButton");
            LoadSprite.FindSprite(mapButton, "none");
            mapButton.transform.localPosition += new Vector3(0, 0, +2);
            ShardReward();
            if (PlayerPrefs.GetInt("P1LevelUpAvailable") == 0 && PlayerPrefs.GetInt("P2LevelUpAvailable") == 0)
            {
                LoadSprite.FindSprite(mapButton, "MapButton");
                mapButton.transform.localPosition += new Vector3(0, 0, -2);
            }
        }
    }

    public static void PlayerXP(string currentStage, int combatNumber, int playerNumber)
    {
        if (PlayerPrefs.GetString("P" + playerNumber + "-Name") != "null") 
        {
            GameObject p1Icon = GameObject.Find("P" + playerNumber + "Icon");
            LoadSprite.FindSprite(p1Icon, PlayerPrefs.GetString("P" + playerNumber + "-Name") + "Head");
            GameObject p1LevelUp = GameObject.Find("P" + playerNumber + "LevelUp");
            LoadSprite.FindSprite(p1LevelUp, "none");
            p1LevelUp.transform.localPosition += new Vector3(0, 0, 2);
            int xPReward = PlayerPrefs.GetInt(currentStage + "Combat" + combatNumber + "-XP");
            int p1XP = PlayerPrefs.GetInt("P" + playerNumber + "-XP") + xPReward;
            GameObject p1XPBar = GameObject.Find("P" + playerNumber + "XPBar");
            int p1XPMax = PlayerPrefs.GetInt("P" + playerNumber + "-XPMax");
            if (p1XP >= p1XPMax)
            {
                int p1XPOverflow = p1XP - p1XPMax;
                PlayerPrefs.SetInt("P" + playerNumber + "-Level", PlayerPrefs.GetInt("P" + playerNumber + "-Level") + 1);
                switch (PlayerPrefs.GetInt("P" + playerNumber + "-Level"))
                {
                    case 2:
                        {
                            PlayerPrefs.SetInt("P" + playerNumber + "-XPMax", 150);
                            p1XPMax = 150;
                            break;
                        }
                    case 3:
                        {
                            PlayerPrefs.SetInt("P" + playerNumber + "-XPMax", 400);
                            p1XPMax = 400;
                            break;
                        }
                    default: { break; }
                }
                p1XP = p1XPOverflow;
                LoadSprite.FindSprite(p1LevelUp, "LevelUp");
                p1LevelUp.transform.localPosition += new Vector3(0,0,-2);
                PlayerPrefs.SetInt("P" + playerNumber + "LevelUpAvailable", 1);
            }
            PlayerPrefs.SetInt("P" + playerNumber + "-XP", p1XP);
            float p1XPPercent = (float)p1XP / (float)p1XPMax;
            p1XPBar.transform.localScale = new Vector3(p1XPPercent, (float)0.45, 1);
            GameObject p1XPText = GameObject.Find("P" + playerNumber + "XPText");
            p1XPText.transform.localPosition = new Vector3(170, 114 - 90*(playerNumber - 1), -1);
            p1XPText.GetComponent<Text>().text = p1XP + "/" + p1XPMax;
        }
        else if (PlayerPrefs.GetString("P" + playerNumber + "-Name") == "null")
        {
            GameObject p1Icon = GameObject.Find("P" + playerNumber + "Icon");
            LoadSprite.FindSprite(p1Icon, "none");
            GameObject p1XPBar = GameObject.Find("P" + playerNumber + "XPBar");
            LoadSprite.FindSprite(p1XPBar, "none");
            GameObject p1XPText = GameObject.Find("P" + playerNumber + "XPText");
            p1XPText.GetComponent<Text>().text = "";
        }
    }

    public static void ShardReward()
    {
        if (PlayerPrefs.GetInt("ShardReward") == 0)
        {
            string currentStage = PlayerPrefs.GetString("CurrentStage");
            string tile = PlayerPrefs.GetString("CurrentTile");
            int xPReward = 0;
            if (tile[0] == 'C')
            {
                int combatNumber = 0;
                if (tile.Length == 7)
                {
                    combatNumber = Int32.Parse(tile[6].ToString());
                }
                if (tile.Length == 8)
                {
                    combatNumber = Int32.Parse(tile[6].ToString() + tile[7].ToString());
                }
                xPReward = PlayerPrefs.GetInt(currentStage + "Combat" + combatNumber + "-XP");
            }
            if (tile[0] == 'M')
            {
                xPReward = PlayerPrefs.GetInt(currentStage + "Miniboss-XP");
            }
            if (tile[0] == 'B')
            {
                xPReward = PlayerPrefs.GetInt(currentStage + "Boss-XP");
            }
            int random = UnityEngine.Random.Range(0, 21);
            int shardReward = (int)Math.Round((double)((60 - random) / 100 * xPReward));
            int currentShards = PlayerPrefs.GetInt("CurrentShards");
            currentShards += shardReward;
            PlayerPrefs.SetInt("CurrentShards", currentShards);
            GameObject.Find("ShardText").GetComponent<Text>().text = "Shards: " + currentShards.ToString();
            GameObject.Find("ShardText").transform.localPosition = new Vector3(-117, -300, -2);
            PlayerPrefs.SetInt("ShardReward", 1);
        }
    }

    public static void ItemReward()
    {
        if (PlayerPrefs.GetInt("ItemReward") == 0)
        {
            string tile = PlayerPrefs.GetString("CurrentTile");
            string item = "";
            if (tile[0] == 'C')
            {
                int combatNumber = 0;
                if (tile.Length == 7)
                {
                    combatNumber = Int32.Parse(tile[6].ToString());
                }
                if (tile.Length == 8)
                {
                    combatNumber = Int32.Parse(tile[6].ToString() + tile[7].ToString());
                }
                item = PlayerPrefs.GetString("Combat" + combatNumber + "ItemReward");
            }
            if (tile[0] == 'M')
            {
                item = PlayerPrefs.GetString("MinibossItemReward");
            }
            if (tile[0] == 'B')
            {
                item = PlayerPrefs.GetString("BossItemReward");
            }
            GameObject.Find("ItemRewardText").GetComponent<Text>().text = item;
            LoadSprite.FindSprite(GameObject.Find("ItemReward"), item);
            int itemCount = PlayerPrefs.GetInt(item + "Count");
            itemCount++;
            PlayerPrefs.SetInt(item + "Count", itemCount);
            PlayerPrefs.SetInt("ItemReward", 1);
        }
    }
}
