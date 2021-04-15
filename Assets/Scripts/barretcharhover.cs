using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class barretcharhover : MonoBehaviour
{
    public GoToMap GoMap;
    public Text textbox;
    void OnMouseEnter()
    {
        GameObject barret = GameObject.FindGameObjectWithTag("barret");
        Vector3 temp = new Vector3(693, -250, -2);
        barret.transform.position = temp;
        textbox.text = "Matriarch";
    }

    void OnMouseExit()
    {
        GameObject barret = GameObject.FindGameObjectWithTag("barret");
        Vector3 temp = new Vector3(1500, -100, -2);
        barret.transform.position = temp;
        textbox.text = "Overveiw";
    }

    void OnMouseDown()
    {
        //set all party member 1 stats to be barret's including name
        GoMap.OnMouseDown();
        PlayerPrefs.SetString("P1-Name", "Barret");
        PlayerPrefs.SetInt("P1-VIT", 5);
        PlayerPrefs.SetInt("P1-STR", 3);
        PlayerPrefs.SetInt("P1-INT", 1);
        PlayerPrefs.SetInt("P1-DEX", 1);
        PlayerPrefs.SetInt("P1-END", 3);
        PlayerPrefs.SetString("P1-Skill-1", "Shoot");
        PlayerPrefs.SetString("P1-Skill-2", "Null");
        PlayerPrefs.SetString("P1-Skill-3", "Null");
        PlayerPrefs.SetString("P1-Skill-4", "Null");
    }
}
