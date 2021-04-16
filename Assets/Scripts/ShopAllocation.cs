using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAllocation : MonoBehaviour
{
    void Start()
    {
        ItemNumberSet("Item", "Health Flask", 1, 15, "Restore 20 Health to a character.", 1, "FriendlyTarget");
        ItemNumberSet("Item", "Spirit Flask", 2, 15, "Restore 10 SP to a character.", 1, "FriendlyTarget");
        ItemNumberSet("Item", "Matchstick", 3, 25, "Deal 5 fire damage to an enemy. Inflict Burning: 5.", 0, "SingleTarget");
        ItemNumberSet("Item", "Contaminant", 4, 25, "Deal 12 acid damage to an enemy. Inflict Corrosion: 4.", 0, "SingleTarget");
        ItemNumberSet("Item", "Blood Bomb", 5, 25, "Deal 15 blood damage to an enemy. Inflict Berserk: 3.", 0, "SingleTarget");
        ItemNumberSet("Item", "Icicle", 6, 25, "Deal 14 frost damage to an enemy. Inflict Shiver: 3.", 0, "SingleTarget");
        ItemNumberSet("Rune", "Rune of the Magi (Tier 1)", 1, 50, "+1 VIT. Gain Aether Wind.", 0, "null");
        ItemNumberSet("Rune", "Rune of the Kingslayer (Tier 1)", 2, 50, "+1 STR. Gain Lymph Slice.", 0, "null");
        ItemNumberSet("Rune", "Rune of the Soldier (Tier 1)", 3, 50, "+1 INT. Gain Death Cloud.", 0, "null");
        ItemNumberSet("Rune", "Rune of the Defender (Tier 1)", 4, 50, "+1 DEX. Gain Mana Grip.", 0, "null");
        ItemNumberSet("Sigil", "Fire Sigil (Tier 1)", 1, 40, "Your attacks deal +3 fire damage.", 0, "null");
        ItemNumberSet("Sigil", "Acid Sigil (Tier 1)", 2, 40, "Your attacks deal +3 acid damage.", 0, "null");
        ItemNumberSet("Sigil", "Blood Sigil (Tier 1)", 3, 40, "Your attacks deal +3 blood damage.", 0, "null");
        ItemNumberSet("Sigil", "Frost Sigil (Tier 1)", 4, 40, "Your attacks deal +3 frost damage.", 0, "null");
        ItemNumberSet("Veil", "Fire Veil (Tier 1)", 1, 40, "+2 Defense and fire resistance.", 0, "null");
        ItemNumberSet("Veil", "Acid Veil (Tier 1)", 2, 40, "+2 Defense and acid resistance.", 0, "null");
        ItemNumberSet("Veil", "Blood Veil (Tier 1)", 3, 40, "+2 Defense and blood resistance.", 0, "null");
        ItemNumberSet("Veil", "Frost Veil (Tier 1)", 4, 40, "+2 Defense and frost resistance.", 0, "null");
    }

    public void ShopSet()
    {
        int shopLimit = PlayerPrefs.GetInt("ShopLimit");
        for (int shopNumber = 1; shopNumber <= shopLimit; shopNumber++)
        {
            for (int itemNumber = 1; itemNumber <= 3; itemNumber++) 
            {
                int random = UnityEngine.Random.Range(3, 7);
                PlayerPrefs.SetString("Shop" + shopNumber + "Item" + itemNumber, PlayerPrefs.GetString("Item" + random + "Name"));
                /*do
                {
                    int random = UnityEngine.Random.Range(3, 7);
                    PlayerPrefs.SetString("Shop" + shopNumber + "Item" + itemNumber, PlayerPrefs.GetString("Item" + random + "Name"));
                }
                while (PlayerPrefs.GetString("Shop" + shopNumber + "Item" + itemNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Item" + itemNumber--) ||
                PlayerPrefs.GetString("Shop" + shopNumber + "Item" + itemNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Item" + (itemNumber - 2)));*/
            }
            for (int runeNumber = 1; runeNumber <= 3; runeNumber++)
            {
                int random = UnityEngine.Random.Range(1, 5);
                PlayerPrefs.SetString("Shop" + shopNumber + "Rune" + runeNumber, PlayerPrefs.GetString("Rune" + random + "Name"));
                /*do
                {
                    int random = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetString("Shop" + shopNumber + "Rune" + runeNumber, PlayerPrefs.GetString("Rune" + random + "Name"));
                }
                while (PlayerPrefs.GetString("Shop" + shopNumber + "Rune" + runeNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Rune" + runeNumber--) ||
                PlayerPrefs.GetString("Shop" + shopNumber + "Rune" + runeNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Rune" + (runeNumber - 2)));*/
            }
            for (int sigilNumber = 1; sigilNumber <= 3; sigilNumber++)
            {
                int random = UnityEngine.Random.Range(1, 5);
                PlayerPrefs.SetString("Shop" + shopNumber + "Sigil" + sigilNumber, PlayerPrefs.GetString("Sigil" + random + "Name"));
                /*do
                {
                    int random = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetString("Shop" + shopNumber + "Sigil" + sigilNumber, PlayerPrefs.GetString("Sigil" + random + "Name"));
                }
                while (PlayerPrefs.GetString("Shop" + shopNumber + "Sigil" + sigilNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Sigil" + sigilNumber--) ||
                PlayerPrefs.GetString("Shop" + shopNumber + "Sigil" + sigilNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Sigil" + (sigilNumber - 2)));*/
            }
            for (int veilNumber = 1; veilNumber <= 3; veilNumber++)
            {
                int random = UnityEngine.Random.Range(1, 5);
                PlayerPrefs.SetString("Shop" + shopNumber + "Veil" + veilNumber, PlayerPrefs.GetString("Veil" + random + "Name"));
                /*do
                {
                    int random = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetString("Shop" + shopNumber + "Veil" + veilNumber, PlayerPrefs.GetString("Veil" + random + "Name"));
                }
                while (PlayerPrefs.GetString("Shop" + shopNumber + "Veil" + veilNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Veil" + veilNumber--) ||
                PlayerPrefs.GetString("Shop" + shopNumber + "Veil" + veilNumber) == PlayerPrefs.GetString("Shop" + shopNumber + "Veil" + (veilNumber - 2)));*/
            }
        }
    }

    private void ItemNumberSet(string type, string itemName, int itemNumber, int itemPrice, string description, int useOnMap, string targeting)
    {
        PlayerPrefs.SetString(type + itemNumber + "Name", itemName);
        PlayerPrefs.SetInt(itemName + "Price", itemPrice);
        PlayerPrefs.SetString(itemName + "Description", description);
        PlayerPrefs.SetInt(itemName + "MapUse", useOnMap);
        PlayerPrefs.SetString(itemName + "-Targeting", targeting);
    }
}
