using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatriarchCharSelect : MonoBehaviour
{
    public GoToMap GoMap;
    public Text textbox;
    void OnMouseEnter()
    {
        GameObject cloud = GameObject.Find("Matriarch");
        Vector3 temp = new Vector3(693, -250, -2);
        cloud.transform.position = temp;
        textbox.text = "Matriarch:" + "\n" + "VIT:3" + "\n" + "STR:2" + "\n" + "INT: 2" + "\n" + "DEX: 1" + "\n" + "ENDR: 2" + "\n" + "Skills:" + "\n" + "no real ones yet";
    }

    void OnMouseExit()
    {
        GameObject cloud = GameObject.Find("Matriarch");
        Vector3 temp = new Vector3(1500, -250, -2);
        cloud.transform.position = temp;
        textbox.text = "Overview";
    }

    void OnMouseDown()
    {
        GoMap.OnMouseDown();
        PlayerPrefs.SetString("P1-Name", "Matriarch");
        PlayerPrefs.SetInt("MatriarchP", 1);
        PlayerPrefs.SetInt("P1-Level", 1);
        PlayerPrefs.SetInt("P1-XP", 0);
        PlayerPrefs.SetInt("P1-XPMax", 50);
        PlayerPrefs.SetInt("P1-VIT", 3);
        PlayerPrefs.SetInt("P1-STR", 2);
        PlayerPrefs.SetInt("P1-INT", 2);
        PlayerPrefs.SetInt("P1-DEX", 1);
        PlayerPrefs.SetInt("P1-END", 2);
        PlayerPrefs.SetString("P1-Skill-1", "Poison");
        PlayerPrefs.SetString("P1-Skill-2", "Null");
        PlayerPrefs.SetString("P1-Skill-3", "Null");
        PlayerPrefs.SetString("P1-Skill-4", "Null");
        PlayerPrefs.SetString("P1-PassiveSkill", "Null");
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
