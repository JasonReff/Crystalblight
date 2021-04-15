using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapItemButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        string item = this.name;
        string itemName = PlayerPrefs.GetString("Inventory" + item);
        GameObject descriptionText = GameObject.Find("DescriptionText");
        descriptionText.GetComponent<Text>().text = PlayerPrefs.GetString(itemName + "Description");
        if (itemName != "null")
        {
            PlayerPrefs.SetString("InventoryClickedItem", itemName);
            switch (item[0])
            {
                case 'I':
                    GameObject useButton = GameObject.Find("UseButton");
                    Vector3 position = useButton.transform.localPosition;
                    if (PlayerPrefs.GetInt(itemName + "MapUse") == 1)
                    {
                        useButton.transform.localPosition = new Vector3(position.x, position.y, -2);
                    }
                    else
                    {
                        useButton.transform.localPosition = new Vector3(position.x, position.y, 2);
                    }
                    for (int x = 1; x <= 4; x++)
                    {
                        GameObject runeBack = GameObject.Find("InventoryCharacter" + x + "RuneBack");
                        runeBack.GetComponent<SpriteRenderer>().color = Color.grey;
                        GameObject sigilBack = GameObject.Find("InventoryCharacter" + x + "SigilBack");
                        sigilBack.GetComponent<SpriteRenderer>().color = Color.grey;
                        GameObject veilBack = GameObject.Find("InventoryCharacter" + x + "VeilBack");
                        veilBack.GetComponent<SpriteRenderer>().color = Color.grey;
                    }
                    break;
                case 'R':
                    for (int x = 1; x <= 4; x++)
                    {
                        GameObject runeBack = GameObject.Find("InventoryCharacter" + x + "RuneBack");
                        runeBack.GetComponent<SpriteRenderer>().color = Color.yellow;
                        GameObject sigilBack = GameObject.Find("InventoryCharacter" + x + "SigilBack");
                        sigilBack.GetComponent<SpriteRenderer>().color = Color.grey;
                        GameObject veilBack = GameObject.Find("InventoryCharacter" + x + "VeilBack");
                        veilBack.GetComponent<SpriteRenderer>().color = Color.grey;
                    }
                    break;
                case 'S':
                    for (int x = 1; x <= 4; x++)
                    {
                        GameObject runeBack = GameObject.Find("InventoryCharacter" + x + "RuneBack");
                        runeBack.GetComponent<SpriteRenderer>().color = Color.grey;
                        GameObject sigilBack = GameObject.Find("InventoryCharacter" + x + "SigilBack");
                        sigilBack.GetComponent<SpriteRenderer>().color = Color.yellow;
                        GameObject veilBack = GameObject.Find("InventoryCharacter" + x + "VeilBack");
                        veilBack.GetComponent<SpriteRenderer>().color = Color.grey;
                    }
                    break;
                case 'V':
                    for (int x = 1; x <= 4; x++)
                    {
                        GameObject runeBack = GameObject.Find("InventoryCharacter" + x + "RuneBack");
                        runeBack.GetComponent<SpriteRenderer>().color = Color.grey;
                        GameObject sigilBack = GameObject.Find("InventoryCharacter" + x + "SigilBack");
                        sigilBack.GetComponent<SpriteRenderer>().color = Color.grey;
                        GameObject veilBack = GameObject.Find("InventoryCharacter" + x + "VeilBack");
                        veilBack.GetComponent<SpriteRenderer>().color = Color.yellow;
                    }
                    break;
            }
        }
    }
}
