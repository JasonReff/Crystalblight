using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public virtual void UseItem()
    {
        itemsInInventory--;
    }

    public virtual void UseItem(Character character)
    {
        itemsInInventory--;
    }

    public virtual void UseItem(Enemy enemy)
    {
        itemsInInventory--;
    }
}
