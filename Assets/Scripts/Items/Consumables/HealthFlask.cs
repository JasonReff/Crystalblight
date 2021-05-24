using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFlask : Consumable
{

    public int restoration = 20;

    public HealthFlask()
    {
        itemName = ToString();
        price = Int32.Parse(ReadPref.FindFromCSV_PLUS_C("ItemData.csv", itemName, "Shard Cost"));
    }
    public override void UseItem(Character character)
    {
        base.UseItem();
        character.health += restoration;
        if (character.health > character.maxHealth)
        {
            character.health = character.maxHealth;
        }
    }
}
