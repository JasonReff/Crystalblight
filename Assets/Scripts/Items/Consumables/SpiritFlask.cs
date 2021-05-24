using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritFlask : Consumable
{
    public int restoration = 15;

    public SpiritFlask()
    {
        itemName = ToString();
        price = Int32.Parse(ReadPref.FindFromCSV("ItemData.csv", itemName + "Price"));
    }

    public override void UseItem(Character character)
    {
        base.UseItem();
        character.SP += restoration;
        if (character.SP > character.maxSP)
        {
            character.SP = character.maxSP;
        }
    }
}
