using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemUseCharacter : MonoBehaviour
{
    public void OnMouseDown()
    {
        string itemName = PlayerPrefs.GetString("InventoryClickedItem");
        if (this.GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            int p = Int32.Parse(this.name[this.name.Length - 1].ToString());
            switch (itemName)
            {
                case "Health Flask":
                    int currentHP = PlayerPrefs.GetInt("P" + p + "-CHP");
                    int maxHP = PlayerPrefs.GetInt("P" + p + "-HP");
                    currentHP += 20;
                    if (currentHP > maxHP) { currentHP = maxHP; }
                    PlayerPrefs.SetInt("P" + p + "-CHP", currentHP);
                    float percentHP = (float)currentHP / (float)maxHP;
                    GameObject hpBar = GameObject.Find("Character" + p + "HP");
                    hpBar.transform.localScale = new Vector3(percentHP, 1, 1);
                    break;
                case "Spirit Flask":
                    int currentSP = PlayerPrefs.GetInt("P" + p + "-CSP");
                    int maxSP = PlayerPrefs.GetInt("P" + p + "-SP");
                    currentSP += 10;
                    if (currentSP > maxSP) { currentSP = maxSP; }
                    PlayerPrefs.SetInt("P" + p + "-CHP", currentSP);
                    float percentSP = (float)currentSP / (float)maxSP;
                    GameObject spBar = GameObject.Find("Character" + p + "SP");
                    spBar.transform.localScale = new Vector3(percentSP, 1, 1);
                    break;
                default:
                    break;
            }
        }
        for (int x = 1; x <= 4; x++)
        {
            GameObject.Find("InventoryCharacter" + x).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
