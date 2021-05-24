using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEncounter : Encounter
{
    public List<Consumable> consumables;
    public ShopEncounter()
    {
        PopulateShop();
    }

    public void PopulateShop()
    {
        HealthFlask healthFlask = new HealthFlask();
        consumables.Add(healthFlask);
        SpiritFlask spiritFlask = new SpiritFlask();
        consumables.Add(spiritFlask);
    }


}
