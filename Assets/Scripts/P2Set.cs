using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Set : MonoBehaviour
{
    private void Start()
    {
        string p1Name = PlayerPrefs.GetString("P1-Name");
        int p1 = 0;
        if (p1Name == "Reaper") { p1 = 1; }
        if (p1Name == "Matriarch") { p1 = 2; }
        if (p1Name == "Hollow") { p1 = 3; }
        if (p1Name == "Shadow") { p1 = 4; }
        int p2A = UnityEngine.Random.Range(1, 5);
        while (p2A == p1)
        {
            p2A = UnityEngine.Random.Range(1, 5);
        }
        PSet(p2A, "P2A-Name");
        int p2B = UnityEngine.Random.Range(1, 5);
        while (p2B == p2A || p2B == p1)
        {
            p2B = UnityEngine.Random.Range(1, 5);
        }
        PSet(p2B, "P2B-Name");
    }

    void OnMouseDown()
    {
        string tileName = this.name[2].ToString();
        if (tileName == "A")
        {
            PlayerPrefs.SetString("P2-Name", PlayerPrefs.GetString("P2A-Name"));
            PlayerPrefs.SetInt(PlayerPrefs.GetString("P2A-Name") + "P", 2);
            PlayerPrefs.SetInt("P2-Level", 1);
            PlayerPrefs.SetInt("P2-VIT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-VIT"));
            PlayerPrefs.SetInt("P2-STR", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-STR"));
            PlayerPrefs.SetInt("P2-INT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-INT"));
            PlayerPrefs.SetInt("P2-DEX", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-DEX"));
            PlayerPrefs.SetInt("P2-END", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-END"));
            PlayerPrefs.SetInt("P2-XP", 0);
            PlayerPrefs.SetInt("P2-XPMax", 50);
            PlayerPrefs.SetString("P2-Skill-1", PlayerPrefs.GetString(PlayerPrefs.GetString("P2A-Name") + "Level1Skill1"));
            PlayerPrefs.SetString("P2-Skill-2", "Null");
            PlayerPrefs.SetString("P2-Skill-3", "Null");
            PlayerPrefs.SetString("P2-Skill-4", "Null");
            PlayerPrefs.SetString("P2-PassiveSkill", "Null");
            PlayerPrefs.SetString("P2Status0", "null");
            PlayerPrefs.SetInt("P2Status0X", 0);
            PlayerPrefs.SetString("P2Status1", "null");
            PlayerPrefs.SetInt("P2Status1X", 0);
            PlayerPrefs.SetString("P2Status2", "null");
            PlayerPrefs.SetInt("P2Status2X", 0);
            PlayerPrefs.SetString("P2Status3", "null");
            PlayerPrefs.SetInt("P2Status3X", 0);
            int discipline = Int32.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID")
            [PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID").Length - 1].ToString());
            PlayerPrefs.SetString("P2-Ultimate", PlayerPrefs.GetString(PlayerPrefs.GetString("P2A-Name") + "-Ultimate" + discipline));
            PlayerPrefs.SetString("P2-Special", PlayerPrefs.GetString(PlayerPrefs.GetString("P2A-Name") + "-Special" + discipline));
            PlayerPrefs.SetInt("P2-SpecialMeter", 0);
            PlayerPrefs.SetInt("P2-SpecialMax", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-Special" + discipline + "Max"));
            PlayerPrefs.SetInt("P2-HP", 40 + 20 * PlayerPrefs.GetInt("P2-VIT"));
            PlayerPrefs.SetInt("P2-SP", 30 + 10 * PlayerPrefs.GetInt("P2-INT"));
            PlayerPrefs.SetInt("P2-CHP", PlayerPrefs.GetInt("P2-HP"));
            PlayerPrefs.SetInt("P2-CSP", PlayerPrefs.GetInt("P2-SP"));
            PlayerPrefs.SetInt("P2-Attack", 5 + 2 * PlayerPrefs.GetInt("P2-STR"));
            PlayerPrefs.SetInt("P2-Guard", 10 * PlayerPrefs.GetInt("P2-END"));
            PlayerPrefs.SetInt("P2-CG", PlayerPrefs.GetInt("P2-Guard"));
            PlayerPrefs.SetInt("P2-DefGuard", 2 * PlayerPrefs.GetInt("P2-END"));
            PlayerPrefs.SetInt("P2-Accuracy", 85 + PlayerPrefs.GetInt("P2-DEX"));
            PlayerPrefs.SetInt("P2-Dodge", 5 + PlayerPrefs.GetInt("P2-DEX"));
            PlayerPrefs.SetInt("P2-CritRate", 5 + 2 * PlayerPrefs.GetInt("P2-DEX"));
        }
        else if (tileName == "B")
        {
            PlayerPrefs.SetString("P2-Name", PlayerPrefs.GetString("P2B-Name"));
            PlayerPrefs.SetInt(PlayerPrefs.GetString("P2B-Name") + "P", 2);
            PlayerPrefs.SetInt("P2-Level", 1);
            PlayerPrefs.SetInt("P2-VIT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-VIT"));
            PlayerPrefs.SetInt("P2-STR", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-STR"));
            PlayerPrefs.SetInt("P2-INT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-INT"));
            PlayerPrefs.SetInt("P2-DEX", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-DEX"));
            PlayerPrefs.SetInt("P2-END", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-END"));
            PlayerPrefs.SetInt("P2-XP", 0);
            PlayerPrefs.SetInt("P2-XPMax", 50);
            PlayerPrefs.SetString("P2-Skill-1", PlayerPrefs.GetString(PlayerPrefs.GetString("P2B-Name") + "Level1Skill1"));
            PlayerPrefs.SetInt("P2-S1-Cost", 12);
            PlayerPrefs.SetInt("P2-S1-Damage", PlayerPrefs.GetInt("P1-INT") * 10);
            PlayerPrefs.GetString("P2-S1-Desc", "Fira: does Int*10 fire Damage for 12 sp (I will make a card hover or whatever for this later)");
            PlayerPrefs.SetString("P2-Skill-2", "Null");
            PlayerPrefs.SetString("P2-Skill-3", "Null");
            PlayerPrefs.SetString("P2-Skill-4", "Null");
            PlayerPrefs.SetString("P2-PassiveSkill", "Null");
            PlayerPrefs.SetString("P2Status0", "null");
            PlayerPrefs.SetInt("P2Status0X", 0);
            PlayerPrefs.SetString("P2Status1", "null");
            PlayerPrefs.SetInt("P2Status1X", 0);
            PlayerPrefs.SetString("P2Status2", "null");
            PlayerPrefs.SetInt("P2Status2X", 0);
            PlayerPrefs.SetString("P2Status3", "null");
            PlayerPrefs.SetInt("P2Status3X", 0);
            int discipline = Int32.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID")
            [PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID").Length - 1].ToString());
            PlayerPrefs.SetString("P2-Ultimate", PlayerPrefs.GetString(PlayerPrefs.GetString("P2B-Name") + "-Ultimate" + discipline));
            PlayerPrefs.SetString("P2-Special", PlayerPrefs.GetString(PlayerPrefs.GetString("P2B-Name") + "-Special" + discipline));
            PlayerPrefs.SetInt("P2-SpecialMeter", 0);
            PlayerPrefs.SetInt("P2-SpecialMax", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-Special" + discipline + "Max"));
            PlayerPrefs.SetInt("P2-HP", 40 + 20 * PlayerPrefs.GetInt("P2-VIT"));
            PlayerPrefs.SetInt("P2-SP", 30 + 10 * PlayerPrefs.GetInt("P2-INT"));
            PlayerPrefs.SetInt("P2-CHP", PlayerPrefs.GetInt("P2-HP"));
            PlayerPrefs.SetInt("P2-CSP", PlayerPrefs.GetInt("P2-SP"));
            PlayerPrefs.SetInt("P2-Attack", 5 + 2 * PlayerPrefs.GetInt("P2-STR"));
            PlayerPrefs.SetInt("P2-Guard", 10 * PlayerPrefs.GetInt("P2-END"));
            PlayerPrefs.SetInt("P2-CG", PlayerPrefs.GetInt("P2-Guard"));
            PlayerPrefs.SetInt("P2-DefGuard", 2 * PlayerPrefs.GetInt("P2-END"));
            PlayerPrefs.SetInt("P2-Accuracy", 85 + PlayerPrefs.GetInt("P2-DEX"));
            PlayerPrefs.SetInt("P2-Dodge", 5 + PlayerPrefs.GetInt("P2-DEX"));
            PlayerPrefs.SetInt("P2-CritRate", 5 + 2 * PlayerPrefs.GetInt("P2-DEX"));
        }
    }

    void PSet(int p, string pName)
    {
        if (p == 1) { PlayerPrefs.SetString(pName, "Reaper"); }
        if (p == 2) { PlayerPrefs.SetString(pName, "Matriarch"); }
        if (p == 3) { PlayerPrefs.SetString(pName, "Hollow"); }
        if (p == 4) { PlayerPrefs.SetString(pName, "Shadow"); }
    }
}
