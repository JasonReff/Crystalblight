using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAllocation : MonoBehaviour
{
    void Start()
    {
        //set all enemy stats

        EnemySetStats("Shifting Sands", 1, "Sandworm", 15, 10, 5, 3, 80, 0, 10, "null", "null", "null", "null", 0, 0, 0, 0, "Physical", 12, "Gnaw", "Tail Whip", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 2, "Shocktoad", 20, 10, 6, 4, 83, 10, 5, "null", "null", "null", "null", 0, 0, 0, 0, "Electric", 14, "Zap", "Flycatcher", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 3, "Windsweeper", 35, 0, 7, 0, 80, 5, 10, "null", "null", "null", "null", 0, 0, 0, 0, "Magic", 15, "Searing Winds", "Sandstorm", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 4, "Rotten Oasis", 50, 0, 8, 0, 85, 5, 0, "null", "null", "null", "null", 0, 0, 0, 0, "Toxic", 20, "Toxic Wave", "Desert Wastes", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 5, "Malvow Cultist (Stage1)", 30, 15, 9, 5, 85, 10, 4, "null", "null", "null", "null", 0, 0, 0, 0, "Dark", 15, "Disease", "Infest", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 6, "Burrow Beetle (Stage1)", 24, 15, 7, 5, 80, 0, 6, "null", "null", "null", "null", 0, 0, 0, 0, "Physical", 10, "Burrow", "Pincer", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 7, "Famined Husk (Stage1)", 25, 10, 8, 0, 85, 4, 4, "null", "null", "null", "null", 0, 0, 0, 0, "Toxic", 13, "Desperate Claw", "Famine", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 8, "Gem Collector (Stage1)", 20, 10, 8, 3, 90, 6, 9, "null", "null", "null", "null", 0, 0, 0, 0, "Physical", 25, "Rusted Blade", "Bomb Lob", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 9, "Crystal Soldier (Stage1)", 20, 15, 8, 4, 85, 5, 5, "null", "null", "null", "null", 0, 0, 0, 0, "Light", 23, "Puncture", "Blight", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 10, "Crystal Heavyweight (Stage1)", 35, 20, 11, 6, 85, 5, 5, "null", "null", "null", "null", 0, 0, 0, 0, "Explosive", 28, "Hammerfist", "Malform", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 11, "Crystal Dreamer (Stage1)", 19, 10, 9, 3, 85, 5, 5, "elusive", "null", "null", "null", 99, 0, 0, 0, "Toxic", 26, "Mesmerize", "Mindspike", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 12, "Crystal Dragon (Stage1)", 44, 30, 14, 10, 85, 5, 5, "flying", "null", "null", "null", 99, 0, 0, 0, "Dark", 31, "Dark Echo", "Wildfire", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 13, "Crystal Shredder (Stage1)", 30, 16, 12, 4, 85, 5, 5, "null", "null", "null", "null", 0, 0, 0, 0, "Physical", 29, "Shred", "Butcher", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 14, "Crystal Matron (Stage1)", 30, 15, 7, 3, 85, 5, 5, "null", "null", "null", "null", 0, 0, 0, 0, "Acid", 27, "Birth", "Crystal Nutrients", "null", "null", "null", "null");
        MinibossSetStats("Shifting Sands", 1, "The Beast", 70, 30, 13, 3, 92, 7, 13, "haste", "null", "null", "null", 5, 0, 0, 0, "Dark", 50, "Trample", "Maw", "Retreat", "null", "null", "null");
        BossSetStats("Shifting Sands", 1, "Father of Plagues", 80, 30, 16, 8, 85, 5, 10, "null", "null", "null", "null", 0, 0, 0, 0, "Toxic", 75, "Locust Swarm", "Sloth", "Reabsorb", "Pestilence", "null", "null");
        MinibossSetStats("The Archives", 1, "Lord Kalor", 80, 50, 15, 8, 85, 5, 5, "null", "null", "null", "null", 0, 0, 0, 0, "Magic", 75, "Hex", "null", "null", "null", "null", "null");
        BossSetStats("The Archives", 1, "Sapphire Guardian", 150, 100, 20, 15, 85, 5, 5,  "null", "null", "null", "null", 0, 0, 0, 0, "Physical", 150, "Pierce", "null", "null", "null", "null", "null");
        EnemySetStats("Shifting Sands", 0, "null", 0, 0, 0, 0, 0, 0, 0, "null", "null", "null", "null", 0, 0, 0, 0, "none", 0, "null", "null", "null", "null", "null", "null");
    }

    public void CombatSet()
    {
        int combatNumber;
        // int realmNumber = PlayerPrefs.GetInt("RealmNumber");
        string currentStage = PlayerPrefs.GetString("CurrentStage");
        for (combatNumber = 1; combatNumber <= 50; combatNumber++)
        {
            EnemyChoice(combatNumber, currentStage);
            int difficulty = 10*(combatNumber / 5 + 1);
            if (PlayerPrefs.GetInt(currentStage + "Combat" + combatNumber + "-XP") > difficulty + 20)
            {
                combatNumber--;
            }
            else if (PlayerPrefs.GetInt(currentStage + "Combat" + combatNumber + "-XP") < difficulty - 20)
            {
                combatNumber--;
            }
        }
        MinibossSet2(currentStage);
        BossSet2(currentStage);
    }

    public void CombatXPDisplay()
    {
        int combatNumber;
        string currentStage = PlayerPrefs.GetString("CurrentStage");
        int totalXP;
        string xpText;
        GameObject xpDisplay;
        for (combatNumber = 1; combatNumber <= 50; combatNumber++)
        {
            totalXP = PlayerPrefs.GetInt(currentStage + "Combat" + combatNumber + "-XP");
            xpText = totalXP.ToString();
            if (GameObject.Find("Combat" + combatNumber + "XP") != null)
            {
                xpDisplay = GameObject.Find("Combat" + combatNumber + "XP");
                xpDisplay.GetComponent<Text>().text = xpText;
            }
        }
        //miniboss
        totalXP = PlayerPrefs.GetInt(currentStage + "Miniboss-XP");
        xpText = totalXP.ToString();
        xpDisplay = GameObject.Find("MinibossXP");
        xpDisplay.GetComponent<Text>().text = xpText;
        //boss
        totalXP = PlayerPrefs.GetInt(currentStage + "Boss-XP");
        xpText = totalXP.ToString();
        xpDisplay = GameObject.Find("BossXP");
        xpDisplay.GetComponent<Text>().text = xpText;
    }
    public void EnemyChoice(int combatNumber, string currentStage)
    {
        int amount = EnemyAmount(combatNumber, currentStage);
        for (int i = 1; i <= amount; i++)
        {
            int random = UnityEngine.Random.Range(9, 15);
            EnemySet(combatNumber, currentStage + random.ToString(), i);
        }
        int totalXP = PlayerPrefs.GetInt("Combat" + combatNumber + "E1-XP") + PlayerPrefs.GetInt("Combat" + combatNumber + "E2-XP") + PlayerPrefs.GetInt("Combat" + combatNumber + "E3-XP") + PlayerPrefs.GetInt("Combat" + combatNumber + "E4-XP");
        PlayerPrefs.SetInt(currentStage + "Combat" + combatNumber + "-XP", totalXP);
        ItemReward(combatNumber, totalXP);
    }

    public void MinibossSet2(string stageName)
    {
        //int random = UnityEngine.Random.Range(1, 3);
        string enemyName = PlayerPrefs.GetString(stageName + "Miniboss" + 1 + "Name");
        PlayerPrefs.SetString("MinibossE" + 1 + "-Name", enemyName);
        int totalXP = PlayerPrefs.GetInt(enemyName + "-XP");
        PlayerPrefs.SetInt(stageName + "Miniboss-XP", totalXP);
        int itemType = UnityEngine.Random.Range(1, 3);
        if (itemType == 1)
        {
            int itemNumber = UnityEngine.Random.Range(1, 5);
            PlayerPrefs.SetString("MinibossItemReward", PlayerPrefs.GetString("Sigil" + itemNumber + "Name"));
        }
        else if (itemType == 2)
        {
            int itemNumber = UnityEngine.Random.Range(1, 5);
            PlayerPrefs.SetString("MinibossItemReward", PlayerPrefs.GetString("Veil" + itemNumber + "Name"));
        }
    }
    public void BossSet2(string stageName)
    {
        //int random = UnityEngine.Random.Range(1, 3);
        string enemyName = PlayerPrefs.GetString(stageName + "Boss" + 1 + "Name");
        PlayerPrefs.SetString("BossE" + 1 + "-Name", enemyName);
        int totalXP = PlayerPrefs.GetInt(enemyName + "-XP");
        PlayerPrefs.SetInt(stageName + "Boss-XP", totalXP);
        int itemType = UnityEngine.Random.Range(1, 3);
        if (itemType == 1)
        {
            int itemNumber = UnityEngine.Random.Range(1, 5);
            PlayerPrefs.SetString("BossItemReward", PlayerPrefs.GetString("Sigil" + itemNumber + "Name"));
        }
        else if (itemType == 2)
        {
            int itemNumber = UnityEngine.Random.Range(1, 5);
            PlayerPrefs.SetString("BossItemReward", PlayerPrefs.GetString("Veil" + itemNumber + "Name"));
        }
    }
    public int EnemyAmount(int combatNumber, string currentStage)
    {
        int amount = UnityEngine.Random.Range(1, 5);
        for (int i = 5; i > amount; i--)
        {
            EnemySet(combatNumber, currentStage + "0", i);
        }
        return amount;
    }
    public void EnemySet(int combatNumber, string stageName, int enemyNumber)
    {
        string enemyName = PlayerPrefs.GetString(stageName + "Name");
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Name", enemyName);
        EnemyGetStats(combatNumber, enemyName, enemyNumber);
    }

    private void ItemReward(int combatNumber, int combatXP)
    {
        int random = UnityEngine.Random.Range(1, 101);
        random += combatXP/(combatNumber*10);
        if (random >= 95)
        {
            int itemType = UnityEngine.Random.Range(1, 101);
            if (itemType <= 40)
            {
                int itemNumber = UnityEngine.Random.Range(1, 7);
                PlayerPrefs.SetString("Combat" + combatNumber + "ItemReward", PlayerPrefs.GetString("Item" + itemNumber + "Name"));
            }
            else if (itemType > 40 && itemType <= 60)
            {
                int itemNumber = UnityEngine.Random.Range(1, 5);
                PlayerPrefs.SetString("Combat" + combatNumber + "ItemReward", PlayerPrefs.GetString("Rune" + itemNumber + "Name"));
            }
            else if (itemType > 60 && itemType <= 80)
            {
                int itemNumber = UnityEngine.Random.Range(1, 5);
                PlayerPrefs.SetString("Combat" + combatNumber + "ItemReward", PlayerPrefs.GetString("Sigil" + itemNumber + "Name"));
            }
            else if (itemType > 80)
            {
                int itemNumber = UnityEngine.Random.Range(1, 5);
                PlayerPrefs.SetString("Combat" + combatNumber + "ItemReward", PlayerPrefs.GetString("Veil" + itemNumber + "Name"));
            }
        }
        else
        {
            PlayerPrefs.SetString("Combat" + combatNumber + "ItemReward", "null");
        }
    }

    public void EnemyGetStats(int combatNumber, string enemyName, int enemyNumber)
    {
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber, enemyName);
        /*PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-CHP", PlayerPrefs.GetInt(enemyName + "-CHP"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-HP", PlayerPrefs.GetInt(enemyName + "-HP"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-CG", PlayerPrefs.GetInt(enemyName + "-CG"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-Guard", PlayerPrefs.GetInt(enemyName + "-Guard"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-Attack", PlayerPrefs.GetInt(enemyName + "-Attack"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-GuardGain", PlayerPrefs.GetInt(enemyName + "-GuardGain"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "Status0", PlayerPrefs.GetString(enemyName + "Status0"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "Status0X", PlayerPrefs.GetInt(enemyName + "Status0X"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "Status1", PlayerPrefs.GetString(enemyName + "Status1"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "Status1X", PlayerPrefs.GetInt(enemyName + "Status1X"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "Status2", PlayerPrefs.GetString(enemyName + "Status2"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "Status2X", PlayerPrefs.GetInt(enemyName + "Status2X"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "Status3", PlayerPrefs.GetString(enemyName + "Status3"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "Status3X", PlayerPrefs.GetInt(enemyName + "Status3X"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Weakness1", PlayerPrefs.GetString(enemyName + "-Weakness1"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Weakness2", PlayerPrefs.GetString(enemyName + "-Weakness2"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Resistance1", PlayerPrefs.GetString(enemyName + "-Resistance1"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Resistance2", PlayerPrefs.GetString(enemyName + "-Resistance2"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Resistance3", PlayerPrefs.GetString(enemyName + "-Resistance3"));
        PlayerPrefs.SetInt("Combat" + combatNumber + "E" + enemyNumber + "-XP", PlayerPrefs.GetInt(enemyName + "-XP"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Skill1", PlayerPrefs.GetString(enemyName + "-Skill1"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Skill2", PlayerPrefs.GetString(enemyName + "-Skill2"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Skill3", PlayerPrefs.GetString(enemyName + "-Skill3"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Skill4", PlayerPrefs.GetString(enemyName + "-Skill4"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Skill5", PlayerPrefs.GetString(enemyName + "-Skill5"));
        PlayerPrefs.SetString("Combat" + combatNumber + "E" + enemyNumber + "-Skill6", PlayerPrefs.GetString(enemyName + "-Skill6"));*/
    }

    public void EnemySetStats(string stageName, int enemyNumber, string enemyName, int maxHP, int maxGuard, int attack, int guardGain, int accuracy, int critrate, int dodge, 
        string status0, string status1, string status2, string status3, int status0X, int status1X, int status2X, int status3X, string damageType, int xP,
        string skill1, string skill2, string skill3, string skill4, string skill5, string skill6)
    {
        PlayerPrefs.SetString("StageEnemy" + enemyNumber, stageName + enemyNumber);
        PlayerPrefs.SetString(stageName + enemyNumber + "Name", enemyName);
        PlayerPrefs.SetInt(enemyName + "-CHP", maxHP);
        PlayerPrefs.SetInt(enemyName + "-HP", maxHP);
        PlayerPrefs.SetInt(enemyName + "-CG", maxGuard);
        PlayerPrefs.SetInt(enemyName + "-Guard", maxGuard);
        PlayerPrefs.SetInt(enemyName + "-Attack", attack);
        PlayerPrefs.SetInt(enemyName + "-GuardGain", guardGain);
        PlayerPrefs.SetString(enemyName + "Status0", status0);
        PlayerPrefs.SetInt(enemyName + "Status0X", status0X);
        PlayerPrefs.SetString(enemyName + "Status1", status1);
        PlayerPrefs.SetInt(enemyName + "Status1X", status1X);
        PlayerPrefs.SetString(enemyName + "Status2", status2);
        PlayerPrefs.SetInt(enemyName + "Status2X", status2X);
        PlayerPrefs.SetString(enemyName + "Status3", status3);
        PlayerPrefs.SetInt(enemyName + "Status3X", status3X);
        PlayerPrefs.SetInt(enemyName + "-XP", xP);
        PlayerPrefs.SetString(enemyName + "-Skill1", skill1);
        PlayerPrefs.SetString(enemyName + "-Skill2", skill2);
        PlayerPrefs.SetString(enemyName + "-Skill3", skill3);
        PlayerPrefs.SetString(enemyName + "-Skill4", skill4);
        PlayerPrefs.SetString(enemyName + "-Skill5", skill5);
        PlayerPrefs.SetString(enemyName + "-Skill6", skill6);
        PlayerPrefs.SetInt(enemyName + "-Accuracy", accuracy);
        PlayerPrefs.SetInt(enemyName + "-Dodge", dodge);
        PlayerPrefs.SetInt(enemyName + "-CritRate", critrate);
        DamageType(enemyName, damageType);
    }

    public void MinibossSetStats(string stageName, int enemyNumber, string enemyName, int maxHP, int maxGuard, int attack, int guardGain, int accuracy, int critrate, int dodge,
        string status0, string status1, string status2, string status3, int status0X, int status1X, int status2X, int status3X, string damageType, int xP,
        string skill1, string skill2, string skill3, string skill4, string skill5, string skill6)
    {
        PlayerPrefs.SetString("StageMiniboss" + enemyNumber, stageName + "Miniboss" + enemyNumber);
        PlayerPrefs.SetString(stageName + "Miniboss" + enemyNumber + "Name", enemyName);
        PlayerPrefs.SetInt(enemyName + "-CHP", maxHP);
        PlayerPrefs.SetInt(enemyName + "-HP", maxHP);
        PlayerPrefs.SetInt(enemyName + "-CG", maxGuard);
        PlayerPrefs.SetInt(enemyName + "-Guard", maxGuard);
        PlayerPrefs.SetInt(enemyName + "-Attack", attack);
        PlayerPrefs.SetInt(enemyName + "-GuardGain", guardGain);
        PlayerPrefs.SetString(enemyName + "Status0", status0);
        PlayerPrefs.SetInt(enemyName + "Status0X", status0X);
        PlayerPrefs.SetString(enemyName + "Status1", status1);
        PlayerPrefs.SetInt(enemyName + "Status1X", status1X);
        PlayerPrefs.SetString(enemyName + "Status2", status2);
        PlayerPrefs.SetInt(enemyName + "Status2X", status2X);
        PlayerPrefs.SetString(enemyName + "Status3", status3);
        PlayerPrefs.SetInt(enemyName + "Status3X", status3X);
        PlayerPrefs.SetInt(enemyName + "-XP", xP);
        PlayerPrefs.SetString(enemyName + "-Skill1", skill1);
        PlayerPrefs.SetString(enemyName + "-Skill2", skill2);
        PlayerPrefs.SetString(enemyName + "-Skill3", skill3);
        PlayerPrefs.SetString(enemyName + "-Skill4", skill4);
        PlayerPrefs.SetString(enemyName + "-Skill5", skill5);
        PlayerPrefs.SetString(enemyName + "-Skill6", skill6);
        PlayerPrefs.SetInt(enemyName + "-Accuracy", accuracy);
        PlayerPrefs.SetInt(enemyName + "-Dodge", dodge);
        PlayerPrefs.SetInt(enemyName + "-CritRate", critrate);
        DamageType(enemyName, damageType);
    }

    public void BossSetStats(string stageName, int enemyNumber, string enemyName, int maxHP, int maxGuard, int attack, int guardGain, int accuracy, int critrate, int dodge,
        string status0, string status1, string status2, string status3, int status0X, int status1X, int status2X, int status3X, string damageType, int xP,
        string skill1, string skill2, string skill3, string skill4, string skill5, string skill6)
    {
        PlayerPrefs.SetString("StageBoss" + enemyNumber, stageName + enemyNumber);
        PlayerPrefs.SetString(stageName + "Boss" + enemyNumber + "Name", enemyName);
        PlayerPrefs.SetInt(enemyName + "-CHP", maxHP);
        PlayerPrefs.SetInt(enemyName + "-HP", maxHP);
        PlayerPrefs.SetInt(enemyName + "-CG", maxGuard);
        PlayerPrefs.SetInt(enemyName + "-Guard", maxGuard);
        PlayerPrefs.SetInt(enemyName + "-Attack", attack);
        PlayerPrefs.SetInt(enemyName + "-GuardGain", guardGain);
        PlayerPrefs.SetString(enemyName + "Status0", status0);
        PlayerPrefs.SetInt(enemyName + "Status0X", status0X);
        PlayerPrefs.SetString(enemyName + "Status1", status1);
        PlayerPrefs.SetInt(enemyName + "Status1X", status1X);
        PlayerPrefs.SetString(enemyName + "Status2", status2);
        PlayerPrefs.SetInt(enemyName + "Status2X", status2X);
        PlayerPrefs.SetString(enemyName + "Status3", status3);
        PlayerPrefs.SetInt(enemyName + "Status3X", status3X);
        PlayerPrefs.SetInt(enemyName + "-XP", xP);
        PlayerPrefs.SetString(enemyName + "-Skill1", skill1);
        PlayerPrefs.SetString(enemyName + "-Skill2", skill2);
        PlayerPrefs.SetString(enemyName + "-Skill3", skill3);
        PlayerPrefs.SetString(enemyName + "-Skill4", skill4);
        PlayerPrefs.SetString(enemyName + "-Skill5", skill5);
        PlayerPrefs.SetString(enemyName + "-Skill6", skill6);
        PlayerPrefs.SetInt(enemyName + "-Accuracy", accuracy);
        PlayerPrefs.SetInt(enemyName + "-Dodge", dodge);
        PlayerPrefs.SetInt(enemyName + "-CritRate", critrate);
        DamageType(enemyName, damageType);
    }

    public void DamageType(string enemyName, string damageType)
    {
        switch (damageType)
        {
            case "Acid":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Blood");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Explosive");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Physical");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Electric");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Blood":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Toxic");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Physical");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Acid");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Fire");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Dark":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Light");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Fire");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Electric");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Dark");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", "none");
                    break;
                }
            case "Electric":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Acid");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Dark");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Frost");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Explosive");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Explosive":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Frost");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Electric");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Acid");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Magic");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Fire":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Blood");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Frost");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Toxic");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Dark");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Frost":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Electric");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Physical");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Fire");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Explosive");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Light":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Dark");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Toxic");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Magic");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Light");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", "none");
                    break;
                }
            case "Physical":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Magic");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Acid");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Frost");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Blood");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "Toxic":
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "Magic");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "Fire");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "Blood");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "Light");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", damageType);
                    break;
                }
            case "none": 
                {
                    PlayerPrefs.SetString(enemyName + "-Weakness1", "none");
                    PlayerPrefs.SetString(enemyName + "-Weakness2", "none");
                    PlayerPrefs.SetString(enemyName + "-Resistance1", "none");
                    PlayerPrefs.SetString(enemyName + "-Resistance2", "none");
                    PlayerPrefs.SetString(enemyName + "-Resistance3", "none");
                    break;
                }
        }
    }
}
