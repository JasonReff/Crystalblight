using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1DisciplineSet : MonoBehaviour
{
    public GoToMap GoMap;
    public int disciplineNumber;
    void OnMouseDown()
    {
        string playerName = PlayerPrefs.GetString("SelectedCharacter");
        GoMap.OnMouseDown();
        PlayerPrefs.SetString("P1-Name", playerName);
        PlayerPrefs.SetInt(playerName + "P", 1);
        PlayerPrefs.SetInt("P1-Level", 1);
        PlayerPrefs.SetInt("P1-XP", 0);
        PlayerPrefs.SetInt("P1-XPMax", 50);
        PlayerPrefs.SetInt("P1-VIT", PlayerPrefs.GetInt(playerName + "-VIT"));
        PlayerPrefs.SetInt("P1-STR", PlayerPrefs.GetInt(playerName + "-STR"));
        PlayerPrefs.SetInt("P1-INT", PlayerPrefs.GetInt(playerName + "-INT"));
        PlayerPrefs.SetInt("P1-DEX", PlayerPrefs.GetInt(playerName + "-DEX"));
        PlayerPrefs.SetInt("P1-END", PlayerPrefs.GetInt(playerName + "-END"));
        int disciplineNumber = Int32.Parse(this.name[this.name.Length - 1].ToString());
        PlayerPrefs.SetString("P1-Skill-1", PlayerPrefs.GetString(playerName + "Level1Skill" + disciplineNumber));
        /*int discipline = Int32.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString("P1-Skill-1") + "ID")
            [PlayerPrefs.GetString(PlayerPrefs.GetString("P1-Skill-1") + "ID").Length - 1].ToString());*/
        PlayerPrefs.SetString("P1-Skill-2", "Null");
        PlayerPrefs.SetString("P1-Skill-3", "Null");
        PlayerPrefs.SetString("P1-Skill-4", "Null");
        PlayerPrefs.SetString("P1-PassiveSkill", "Null");
        PlayerPrefs.SetString("P1-Ultimate", PlayerPrefs.GetString(playerName + "-Ultimate" + disciplineNumber));
        PlayerPrefs.SetString("P1-Special", PlayerPrefs.GetString(playerName + "-Special" + disciplineNumber));
        PlayerPrefs.SetInt("P1-SpecialMeter", 0);
        PlayerPrefs.SetInt("P1-SpecialMax", PlayerPrefs.GetInt(playerName + "-Special" + disciplineNumber + "Max"));
        PlayerPrefs.SetInt("P1-HP", 40 + 20 * PlayerPrefs.GetInt("P1-VIT"));
        PlayerPrefs.SetInt("P1-SP", 30 + 10 * PlayerPrefs.GetInt("P1-INT"));
        PlayerPrefs.SetInt("P1-CHP", PlayerPrefs.GetInt("P1-HP"));
        PlayerPrefs.SetInt("P1-CSP", PlayerPrefs.GetInt("P1-SP"));
        PlayerPrefs.SetInt("P1-Attack", 5 + 2 * PlayerPrefs.GetInt("P1-STR"));
        PlayerPrefs.SetInt("P1-Guard", 10 * PlayerPrefs.GetInt("P1-END"));
        PlayerPrefs.SetInt("P1-CG", PlayerPrefs.GetInt("P1-Guard"));
        PlayerPrefs.SetInt("P1-DefGuard", 2 * PlayerPrefs.GetInt("P1-END"));
        PlayerPrefs.SetInt("P1-Accuracy", 85 + PlayerPrefs.GetInt("P1-DEX"));
        PlayerPrefs.SetInt("P1-Dodge", 5 + PlayerPrefs.GetInt("P1-DEX"));
        PlayerPrefs.SetInt("P1-CritRate", 5 + 2 * PlayerPrefs.GetInt("P1-DEX"));
        PlayerPrefs.SetString("P1Status0", "null");
        PlayerPrefs.SetInt("P1Status0X", 0);
        PlayerPrefs.SetString("P1Status1", "null");
        PlayerPrefs.SetInt("P1Status2X", 0);
        PlayerPrefs.SetString("P1Status2", "null");
        PlayerPrefs.SetInt("P1Status2X", 0);
        PlayerPrefs.SetString("P1Status3", "null");
        PlayerPrefs.SetInt("P1Status3X", 0);
        PlayerPrefs.SetString("P2-Name", "null");
        PlayerPrefs.SetString("P3-Name", "null");
        PlayerPrefs.SetString("P4-Name", "null");
    }
}
