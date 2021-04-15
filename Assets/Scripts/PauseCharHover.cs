using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCharHover : MonoBehaviour
{
    public Text StatsWhite;
    public Text StatsBlack;
    public Text NameWhite;
    public Text NameBlack;

    void OnMouseDown()
    {
        PlayerPrefs.SetInt("PauseClick", 0);
        OnMouseEnter();
        PlayerPrefs.SetInt("PauseClick", 1);
        if (name != "Reaper")
        {
            GameObject full = GameObject.Find("Reaper" + "Full");
            Vector3 temp = new Vector3(-3000, 220, 0);
            full.transform.position = temp;
        }
        if (name != "Matriarch")
        {
            GameObject full = GameObject.Find("Matriarch" + "Full");
            Vector3 temp = new Vector3(-3000, 220, 0);
            full.transform.position = temp;
        }
        //add more as you add characters
    }
    
    void OnMouseEnter()
    {
        if (PlayerPrefs.GetInt("PauseClick") != 1)
        {
            int p = 0;
            GameObject full = GameObject.Find(name + "Full");
            if (PlayerPrefs.GetString("P1-Name") == name)
            {
                p = 1;
            }
            if (PlayerPrefs.GetString("P2-Name") == name)
            {
                p = 2;
            }
            if (PlayerPrefs.GetString("P3-Name") == name)
            {
                p = 3;
            }
            if (PlayerPrefs.GetString("P4-Name") == name)
            {
                p = 4;
            }
            Vector3 temp = new Vector3(-815, 220, 0);
            full.transform.position = temp;
            StatsWhite.text = "Level: " + PlayerPrefs.GetInt("P" + p + "-Level") + "\n" +
                "EXP: " + PlayerPrefs.GetInt("P" + p + "-EXP") + "/idk" + "\n" +
                "HP: " + PlayerPrefs.GetInt("P" + p + "-CHP") + "/" + PlayerPrefs.GetInt("P" + p + "-HP") + "\n" +
                "SP: " + PlayerPrefs.GetInt("P" + p + "-CSP") + "/" + PlayerPrefs.GetInt("P" + p + "-SP") + "\n" +
                "VIT: " + PlayerPrefs.GetInt("P" + p + "-VIT") + "\n" +
                "INT: " + PlayerPrefs.GetInt("P" + p + "-INT") + "\n" +
                "STR: " + PlayerPrefs.GetInt("P" + p + "-STR") + "\n" +
                "DEX: " + PlayerPrefs.GetInt("P" + p + "-DEX") + "\n" +
                "END: " + PlayerPrefs.GetInt("P" + p + "-END") + "\n";
            StatsBlack.text = "Level: " + PlayerPrefs.GetInt("P" + p + "-Level") + "\n" +
                "EXP: " + PlayerPrefs.GetInt("P" + p + "-EXP") + "/idk" + "\n" +
                "HP: " + PlayerPrefs.GetInt("P" + p + "-HP") + "/" + PlayerPrefs.GetInt("P" + p + "-CHP") + "\n" +
                "SP: " + PlayerPrefs.GetInt("P" + p + "-SP") + "/" + PlayerPrefs.GetInt("P" + p + "-CSP") + "\n" +
                "VIT: " + PlayerPrefs.GetInt("P" + p + "-VIT") + "\n" +
                "INT: " + PlayerPrefs.GetInt("P" + p + "-INT") + "\n" +
                "STR: " + PlayerPrefs.GetInt("P" + p + "-STR") + "\n" +
                "DEX: " + PlayerPrefs.GetInt("P" + p + "-DEX") + "\n" +
                "END: " + PlayerPrefs.GetInt("P" + p + "-END") + "\n";
            NameWhite.text = name;
            NameBlack.text = name;
        }
    }

    void OnMouseExit()
    {
        if (PlayerPrefs.GetInt("PauseClick") != 1)
        {
            int p = 0;
            GameObject full = GameObject.Find(name + "Full");
            if (PlayerPrefs.GetString("P1-Name") == name)
            {
                p = 1;
            }
            if (PlayerPrefs.GetString("P2-Name") == name)
            {
                p = 2;
            }
            if (PlayerPrefs.GetString("P3-Name") == name)
            {
                p = 3;
            }
            if (PlayerPrefs.GetString("P4-Name") == name)
            {
                p = 4;
            }
            Vector3 temp = new Vector3(-3000, 220, 0);
            full.transform.position = temp;
            NameWhite.text = "Name";
            NameBlack.text = "Name";
            StatsWhite.text = "Level: " + "\n" +
                "EXP: " + "\n" +
                "HP: "  + "\n" +
                "SP: "  + "\n" +
                "VIT: " + "\n" +
                "INT: " + "\n" +
                "STR: " + "\n" +
                "DEX: " + "\n" +
                "END: ";
            StatsBlack.text = "Level: " + "\n" +
                "EXP: " + "\n" +
                "HP: " + "\n" +
                "SP: " + "\n" +
                "VIT: " + "\n" +
                "INT: " + "\n" +
                "STR: " + "\n" +
                "DEX: " + "\n" +
                "END: ";
        }
    }
}
