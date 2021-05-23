using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public virtual void UseItem()
    {
        ConsumeItem();
    }

    public virtual void UseItem(Character character)
    {
        ConsumeItem();
    }

    public virtual void UseItem(Enemy enemy)
    {
        ConsumeItem();
    }

    void ConsumeItem()
    {
        PlayerData playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        int inventoryCount = playerData.itemsInInventory[this];
        inventoryCount--;
        playerData.itemsInInventory[this] = inventoryCount;
        if (playerData.itemsInInventory[this] == 0)
        {
            playerData.itemsInInventory.Remove(this);
        }
    }
}
