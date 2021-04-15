using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInventoryEquipUnequip : MonoBehaviour
{

    private void OnMouseDown()
    {
        string equipment;
        if (this.name.Remove(this.name.Length - 4, 4) != "Back") { equipment = this.name + "Back"; }
        else { equipment = this.name; }
        if (GameObject.Find(equipment).GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            Unequip();
            Equip();
        }
        else if (PlayerPrefs.GetInt("EquipmentClicked") == 1)
        {
            Unequip();
        }
        else { PlayerPrefs.SetInt("EquipmentClicked", 1); }
        for (int x = 1; x <= 4; x++)
        {
            GameObject runeBack = GameObject.Find("InventoryCharacter" + x + "RuneBack");
            runeBack.GetComponent<SpriteRenderer>().color = Color.grey;
            GameObject sigilBack = GameObject.Find("InventoryCharacter" + x + "SigilBack");
            sigilBack.GetComponent<SpriteRenderer>().color = Color.grey;
            GameObject veilBack = GameObject.Find("InventoryCharacter" + x + "VeilBack");
            veilBack.GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }


    private void Equip()
    {
        int characterNumber = Int32.Parse(this.name[16].ToString());
        string equipmentType = this.name.Remove(0, 17);
        LoadSprite.FindSprite(this.gameObject, PlayerPrefs.GetString("InventoryClickedItem"));
        PlayerPrefs.SetString("P" + characterNumber + "-" + equipmentType, PlayerPrefs.GetString("InventoryClickedItem"));
        PlayerPrefs.SetString("InventoryClickedItem", "null");
    }

    private void Unequip()
    {
        string equipmentType = this.name.Remove(0, 17);
        int characterNumber = Int32.Parse(this.name[16].ToString());
        string equipmentName = PlayerPrefs.GetString("P" + characterNumber + "-" + equipmentType);
        int itemLimit = 0;
        do
        {
            itemLimit++;
        }
        while (PlayerPrefs.GetString("Inventory" + equipmentType + itemLimit) != "null");
        PlayerPrefs.SetString("Inventory" + equipmentType + itemLimit, equipmentName);
        PlayerPrefs.SetString("P" + characterNumber + "-" + equipmentType, "null");
        LoadSprite.FindSprite(this.gameObject, "null");
        if (itemLimit <= 3)
        {
            GameObject unequippedItem = GameObject.Find(equipmentType + itemLimit.ToString());
            LoadSprite.FindSprite(unequippedItem, equipmentName);
        }
        PlayerPrefs.SetInt("EquipmentClicked", 0);
    }


}
