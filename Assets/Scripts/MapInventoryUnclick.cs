using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInventoryUnclick : MonoBehaviour
{
    private void OnMouseDown()
    {
        for (int x = 1; x <= 4; x++)
        {
            GameObject runeBack = GameObject.Find("InventoryCharacter" + x + "RuneBack");
            runeBack.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject sigilBack = GameObject.Find("InventoryCharacter" + x + "SigilBack");
            sigilBack.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject veilBack = GameObject.Find("InventoryCharacter" + x + "VeilBack");
            veilBack.GetComponent<SpriteRenderer>().color = Color.white;
        }
        for (int x = 1; x <= 4; x++)
        {
            GameObject.Find("InventoryCharacter" + x).GetComponent<SpriteRenderer>().color = Color.white;
        }
        GameObject descriptionText = GameObject.Find("DescriptionText");
        descriptionText.GetComponent<Text>().text = "";
        PlayerPrefs.SetString("InventoryItemClicked", "null");
        PlayerPrefs.SetInt("EquipmentClicked", 0);
    }
}
