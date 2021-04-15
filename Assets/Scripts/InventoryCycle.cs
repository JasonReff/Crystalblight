using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCycle : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (this.name[0] == 'I')
        {
            if (this.name.Substring(this.name.Length - 4) == "Left")
            {
                int itemLimit = 0;
                do
                {
                    itemLimit++;
                }
                while (PlayerPrefs.GetString("InventoryItem" + itemLimit) != "null");
                for (int itemNumber = 1; itemNumber <= itemLimit - 1; itemNumber++)
                {
                    PlayerPrefs.SetString("InventoryItem" + itemNumber, PlayerPrefs.GetString("InventoryItem" + itemNumber++));
                    PlayerPrefs.SetString("InventoryItem" + itemLimit, PlayerPrefs.GetString("InventoryItem1"));
                }
            }
            else if (this.name.Substring(this.name.Length - 5) == "Right")
            {
                int itemLimit = 0;
                do
                {
                    itemLimit++;
                }
                while (PlayerPrefs.GetString("InventoryItem" + itemLimit) != "null");
                for (int itemNumber = itemLimit; itemNumber >= 2; itemNumber--)
                {
                    PlayerPrefs.SetString("InventoryItem" + itemNumber, PlayerPrefs.GetString("InventoryItem" + itemNumber--));
                    PlayerPrefs.SetString("InventoryItem1", PlayerPrefs.GetString("InventoryItem" + itemLimit));
                }
            }
            for (int x = 1; x <= 3; x++)
            {
                GameObject itemIcon = GameObject.Find("Item" + x);
                LoadSprite.FindSprite(itemIcon, PlayerPrefs.GetString("InventoryItem" + x));
            }
        }
        else if (this.name[0] == 'R')
        {
            if (this.name.Substring(this.name.Length - 4) == "Left")
            {
                int runeLimit = 0;
                do
                {
                    runeLimit++;
                }
                while (PlayerPrefs.GetString("InventoryRune" + runeLimit) != "null");
                for (int runeNumber = 1; runeNumber <= runeLimit - 1; runeNumber++)
                {
                    PlayerPrefs.SetString("InventoryRune" + runeNumber, PlayerPrefs.GetString("InventoryRune" + runeNumber++));
                    PlayerPrefs.SetString("InventoryRune" + runeLimit, PlayerPrefs.GetString("InventoryRune1"));
                }
            }
            else if (this.name.Substring(this.name.Length - 5) == "Right")
            {
                int runeLimit = 0;
                do
                {
                    runeLimit++;
                }
                while (PlayerPrefs.GetString("InventoryRune" + runeLimit) != "null");
                for (int runeNumber = runeLimit; runeNumber >= 2; runeNumber--)
                {
                    PlayerPrefs.SetString("InventoryRune" + runeNumber, PlayerPrefs.GetString("InventoryRune" + runeNumber--));
                    PlayerPrefs.SetString("InventoryRune1", PlayerPrefs.GetString("InventoryRune" + runeLimit));
                }
            }
            for (int x = 1; x <= 3; x++)
            {
                GameObject runeIcon = GameObject.Find("Rune" + x);
                LoadSprite.FindSprite(runeIcon, PlayerPrefs.GetString("InventoryRune" + x));
            }
        }
        else if (this.name[0] == 'S')
        {
            if (this.name.Substring(this.name.Length - 4) == "Left")
            {
                int sigilLimit = 0;
                do
                {
                    sigilLimit++;
                }
                while (PlayerPrefs.GetString("InventorySigil" + sigilLimit) != "null");
                for (int sigilNumber = 1; sigilNumber <= sigilLimit - 1; sigilNumber++)
                {
                    PlayerPrefs.SetString("InventorySigil" + sigilNumber, PlayerPrefs.GetString("InventorySigil" + sigilNumber++));
                    PlayerPrefs.SetString("InventorySigil" + sigilLimit, PlayerPrefs.GetString("InventorySigil1"));
                }
            }
            else if (this.name.Substring(this.name.Length - 5) == "Right")
            {
                int sigilLimit = 0;
                do
                {
                    sigilLimit++;
                }
                while (PlayerPrefs.GetString("InventorySigil" + sigilLimit) != "null");
                for (int sigilNumber = sigilLimit; sigilNumber >= 2; sigilNumber--)
                {
                    PlayerPrefs.SetString("InventorySigil" + sigilNumber, PlayerPrefs.GetString("InventorySigil" + sigilNumber--));
                    PlayerPrefs.SetString("InventorySigil1", PlayerPrefs.GetString("InventorySigil" + sigilLimit));
                }
            }
            for (int x = 1; x <= 3; x++)
            {
                GameObject sigilIcon = GameObject.Find("Sigil" + x);
                LoadSprite.FindSprite(sigilIcon, PlayerPrefs.GetString("InventorySigil" + x));
            }
        }
        else if (this.name[0] == 'V')
        {
            if (this.name.Substring(this.name.Length - 4) == "Left")
            {
                int veilLimit = 0;
                do
                {
                    veilLimit++;
                }
                while (PlayerPrefs.GetString("InventoryVeil" + veilLimit) != "null");
                for (int veilNumber = 1; veilNumber <= veilLimit - 1; veilNumber++)
                {
                    PlayerPrefs.SetString("InventoryVeil" + veilNumber, PlayerPrefs.GetString("InventoryVeil" + veilNumber++));
                    PlayerPrefs.SetString("InventoryVeil" + veilLimit, PlayerPrefs.GetString("InventoryVeil1"));
                }
            }
            else if (this.name.Substring(this.name.Length - 5) == "Right")
            {
                int veilLimit = 0;
                do
                {
                    veilLimit++;
                }
                while (PlayerPrefs.GetString("InventoryVeil" + veilLimit) != "null");
                for (int veilNumber = veilLimit; veilNumber >= 2; veilNumber--)
                {
                    PlayerPrefs.SetString("InventoryVeil" + veilNumber, PlayerPrefs.GetString("InventoryVeil" + veilNumber--));
                    PlayerPrefs.SetString("InventoryVeil1", PlayerPrefs.GetString("InventoryVeil" + veilLimit));
                }
            }
            for (int x = 1; x <= 3; x++)
            {
                GameObject veilIcon = GameObject.Find("Veil" + x);
                LoadSprite.FindSprite(veilIcon, PlayerPrefs.GetString("InventoryVeil" + x));
            }
        }
    }
}
