using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInventoryButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameObject inventoryDisplay = GameObject.Find("InventoryDisplay");
        GameObject inventoryDiss = GameObject.Find("InventoryDiss");
        GameObject inventoryText = GameObject.Find("InventoryText");
        if (inventoryDisplay.transform.localPosition != new Vector3(0, 0, -2))
        {
            GameObject.Find("Canvas").transform.localPosition = new Vector3(0, 0, 1);
            Vector3 characterPosition = GameObject.Find("CharacterCompass").transform.localPosition;
            GameObject.Find("CharacterCompass").transform.localPosition = new Vector3(characterPosition.x, characterPosition.y, 1);
            inventoryDisplay.transform.localPosition = new Vector3(0, 0, -2);
            inventoryDiss.transform.localPosition = new Vector3(0, 0, -1);
            inventoryText.transform.localPosition = new Vector3(0, 0, -1);
            for (int x = 1; x <= 4; x++)
            {
                string characterName = PlayerPrefs.GetString("P" + x + "-Name");
                if (characterName != "null")
                {
                    GameObject characterIcon = GameObject.Find("InventoryCharacter" + x);
                    LoadSprite.FindSprite(characterIcon, characterName + "Head");
                    GameObject characterRune = GameObject.Find("InventoryCharacter" + x + "Rune");
                    GameObject characterSigil = GameObject.Find("InventoryCharacter" + x + "Sigil");
                    GameObject characterVeil = GameObject.Find("InventoryCharacter" + x + "Veil");
                    LoadSprite.FindSprite(characterRune, PlayerPrefs.GetString("P" + x + "-Rune"));
                    LoadSprite.FindSprite(characterSigil, PlayerPrefs.GetString("P" + x + "-Sigil"));
                    LoadSprite.FindSprite(characterVeil, PlayerPrefs.GetString("P" + x + "-Veil"));
                }
                else
                {
                    GameObject characterIcon = GameObject.Find("InventoryCharacter" + x);
                    Vector3 position = characterIcon.transform.localPosition;
                    characterIcon.transform.localPosition = new Vector3(position.x, position.y, 4);
                }
            }
        }
        else
        {
            GameObject.Find("Canvas").transform.localPosition = new Vector3(0, 0, 0);
            Vector3 characterPosition = GameObject.Find("CharacterCompass").transform.localPosition;
            GameObject.Find("CharacterCompass").transform.localPosition = new Vector3(characterPosition.x, characterPosition.y, -2);
            inventoryDisplay.transform.localPosition = new Vector3(0, -500, -2);
            inventoryDiss.transform.localPosition = new Vector3(0, -500, -1);
            inventoryText.transform.localPosition = new Vector3(0, -500, 0);
        }
        InventoryItems();
        InventoryRunes();
        InventorySigils();
        InventoryVeils();
        InventoryShards();
    }

    private void InventoryItems()
    {
        int itemNumber = 0;
        for (int x = 1; x <= 20; x++)
        {
            string itemName = PlayerPrefs.GetString("Item" + x + "Name");
            if (PlayerPrefs.GetInt(itemName + "Count") > 0)
            {
                itemNumber++;
                PlayerPrefs.SetString("InventoryItem" + itemNumber, itemName);
            }
        }
        for (int y = 20; y > itemNumber; y--)
        {
            PlayerPrefs.SetString("InventoryItem" + y, "null");
        }
        for (int number = 1; number <= 3; number++)
        {
            GameObject item = GameObject.Find("Item" + number);
            LoadSprite.FindSprite(item, PlayerPrefs.GetString("InventoryItem" + number));
        }
        if (PlayerPrefs.GetString("InventoryItem4") != "null")
        {
            GameObject itemLeft = GameObject.Find("ItemLeft");
            GameObject itemRight = GameObject.Find("ItemRight");
            Vector3 itemLeftPosition = itemLeft.transform.localPosition;
            Vector3 itemRightPosition = itemRight.transform.localPosition;
            itemLeft.transform.localPosition = new Vector3(itemLeftPosition.x, itemLeftPosition.y, 0);
            itemRight.transform.localPosition = new Vector3(itemRightPosition.x, itemRightPosition.y, 0);
        }
        else
        {
            GameObject itemLeft = GameObject.Find("ItemLeft");
            GameObject itemRight = GameObject.Find("ItemRight");
            Vector3 itemLeftPosition = itemLeft.transform.localPosition;
            Vector3 itemRightPosition = itemRight.transform.localPosition;
            itemLeft.transform.localPosition = new Vector3(itemLeftPosition.x, itemLeftPosition.y, 4);
            itemRight.transform.localPosition = new Vector3(itemRightPosition.x, itemRightPosition.y, 4);
        }
    }

    private void InventoryRunes()
    {
        int runeNumber = 0;
        for (int x = 1; x <= 20; x++)
        {
            string runeName = PlayerPrefs.GetString("Rune" + x + "Name");
            if (PlayerPrefs.GetInt(runeName + "Count") > 0)
            {
                runeNumber++;
                PlayerPrefs.SetString("InventoryRune" + runeNumber, runeName);
            }
        }
        for (int y = 20; y > runeNumber; y--)
        {
            PlayerPrefs.SetString("InventoryRune" + y, "null");
        }
        for (int number = 1; number <= 3; number++)
        {
            GameObject rune = GameObject.Find("Rune" + number);
            LoadSprite.FindSprite(rune, PlayerPrefs.GetString("InventoryRune" + number));
        }
        if (PlayerPrefs.GetString("InventoryRune4") != "null")
        {
            GameObject runeLeft = GameObject.Find("RuneLeft");
            GameObject runeRight = GameObject.Find("RuneRight");
            Vector3 runeLeftPosition = runeLeft.transform.localPosition;
            Vector3 runeRightPosition = runeRight.transform.localPosition;
            runeLeft.transform.localPosition = new Vector3(runeLeftPosition.x, runeLeftPosition.y, 0);
            runeRight.transform.localPosition = new Vector3(runeRightPosition.x, runeRightPosition.y, 0);
        }
        else
        {
            GameObject runeLeft = GameObject.Find("RuneLeft");
            GameObject runeRight = GameObject.Find("RuneRight");
            Vector3 runeLeftPosition = runeLeft.transform.localPosition;
            Vector3 runeRightPosition = runeRight.transform.localPosition;
            runeLeft.transform.localPosition = new Vector3(runeLeftPosition.x, runeLeftPosition.y, 4);
            runeRight.transform.localPosition = new Vector3(runeRightPosition.x, runeRightPosition.y, 4);
        }
    }

    private void InventorySigils()
    {
        int sigilNumber = 0;
        for (int x = 1; x <= 20; x++)
        {
            string sigilName = PlayerPrefs.GetString("Sigil" + x + "Name");
            if (PlayerPrefs.GetInt(sigilName + "Count") > 0)
            {
                sigilNumber++;
                PlayerPrefs.SetString("InventorySigil" + sigilNumber, sigilName);
            }
        }
        for (int y = 20; y > sigilNumber; y--)
        {
            PlayerPrefs.SetString("InventorySigil" + y, "null");
        }
        for (int number = 1; number <= 3; number++)
        {
            GameObject sigil = GameObject.Find("Sigil" + number);
            LoadSprite.FindSprite(sigil, PlayerPrefs.GetString("InventorySigil" + number));
        }
        if (PlayerPrefs.GetString("InventorySigil4") != "null")
        {
            GameObject sigilLeft = GameObject.Find("SigilLeft");
            GameObject sigilRight = GameObject.Find("SigilRight");
            Vector3 sigilLeftPosition = sigilLeft.transform.localPosition;
            Vector3 sigilRightPosition = sigilRight.transform.localPosition;
            sigilLeft.transform.localPosition = new Vector3(sigilLeftPosition.x, sigilLeftPosition.y, 0);
            sigilRight.transform.localPosition = new Vector3(sigilRightPosition.x, sigilRightPosition.y, 0);
        }
        else
        {
            GameObject sigilLeft = GameObject.Find("SigilLeft");
            GameObject sigilRight = GameObject.Find("SigilRight");
            Vector3 sigilLeftPosition = sigilLeft.transform.localPosition;
            Vector3 sigilRightPosition = sigilRight.transform.localPosition;
            sigilLeft.transform.localPosition = new Vector3(sigilLeftPosition.x, sigilLeftPosition.y, 4);
            sigilRight.transform.localPosition = new Vector3(sigilRightPosition.x, sigilRightPosition.y, 4);
        }
    }

    private void InventoryVeils()
    {
        int veilNumber = 0;
        for (int x = 1; x <= 20; x++)
        {
            string veilName = PlayerPrefs.GetString("Veil" + x + "Name");
            if (PlayerPrefs.GetInt(veilName + "Count") > 0)
            {
                veilNumber++;
                PlayerPrefs.SetString("InventoryVeil" + veilNumber, veilName);
            }
        }
        for (int y = 20; y > veilNumber; y--)
        {
            PlayerPrefs.SetString("InventoryVeil" + y, "null");
        }
        for (int number = 1; number <= 3; number++)
        {
            GameObject veil = GameObject.Find("Veil" + number);
            LoadSprite.FindSprite(veil, PlayerPrefs.GetString("InventoryVeil" + number));
        }
        if (PlayerPrefs.GetString("InventoryVeil4") != "null")
        {
            GameObject veilLeft = GameObject.Find("VeilLeft");
            GameObject veilRight = GameObject.Find("VeilRight");
            Vector3 veilLeftPosition = veilLeft.transform.localPosition;
            Vector3 veilRightPosition = veilRight.transform.localPosition;
            veilLeft.transform.localPosition = new Vector3(veilLeftPosition.x, veilLeftPosition.y, 0);
            veilRight.transform.localPosition = new Vector3(veilRightPosition.x, veilRightPosition.y, 0);
        }
        else
        {
            GameObject veilLeft = GameObject.Find("VeilLeft");
            GameObject veilRight = GameObject.Find("VeilRight");
            Vector3 veilLeftPosition = veilLeft.transform.localPosition;
            Vector3 veilRightPosition = veilRight.transform.localPosition;
            veilLeft.transform.localPosition = new Vector3(veilLeftPosition.x, veilLeftPosition.y, 4);
            veilRight.transform.localPosition = new Vector3(veilRightPosition.x, veilRightPosition.y, 4);
        }
    }

    private void InventoryShards()
    {
        GameObject shardsText = GameObject.Find("ShardsText");
        shardsText.GetComponent<Text>().text = PlayerPrefs.GetInt("CurrentShards").ToString();
    }
}
