using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemUse : MonoBehaviour
{
    public void OnMouseDown()
    {
        string itemName = PlayerPrefs.GetString("InventoryClickedItem");
        if (PlayerPrefs.GetInt(itemName + "MapUse") == 1)
        {
            if (PlayerPrefs.GetString(itemName + "-Targeting") == "All")
            {

            }
            else if (PlayerPrefs.GetString(itemName + "-Targeting") == "FriendlyTarget")
            {
                for (int x = 1; x <= 4; x++)
                {
                    GameObject characterIcon = GameObject.Find("InventoryCharacter" + x);
                    characterIcon.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }
        else
        {
            for (int x = 1; x <= 4; x++)
            {
                GameObject characterIcon = GameObject.Find("InventoryCharacter" + x);
                characterIcon.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
