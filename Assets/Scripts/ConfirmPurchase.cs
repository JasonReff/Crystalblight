using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPurchase : MonoBehaviour
{
    private void OnMouseDown()
    {
        string itemName = GameObject.Find(PlayerPrefs.GetString("ClickedItem")).GetComponent<SpriteRenderer>().sprite.name;
        int itemPrice = PlayerPrefs.GetInt(itemName + "Price");
        int currentShards = PlayerPrefs.GetInt("CurrentShards");
        if (currentShards >= itemPrice)
        {
            currentShards -= itemPrice;
            PlayerPrefs.SetInt("CurrentShards", currentShards);
            int itemCount = PlayerPrefs.GetInt(itemName + "Count");
            itemCount++;
            PlayerPrefs.SetInt(itemName + "Count", itemCount);
            GameObject shardText = GameObject.Find("ShardText");
            shardText.GetComponent<Text>().text = currentShards.ToString();
            GameObject clickedItem = GameObject.Find(PlayerPrefs.GetString("ClickedItem"));
            LoadSprite.FindSprite(clickedItem, "null");
        }
        if (currentShards < itemPrice)
        {
            GameObject merchantText = GameObject.Find("MerchantText");
            merchantText.GetComponent<Text>().text = "Looks like you can't afford that.";
        }
        GameObject itemDisplay = GameObject.Find("ItemDisplay");
        itemDisplay.transform.localPosition = new Vector3(400, 0, 2);
        GameObject itemNameText = GameObject.Find("ItemNameText");
        itemNameText.GetComponent<Text>().text = "";
        GameObject itemDescription = GameObject.Find("ItemDescriptionText");
        itemDescription.GetComponent<Text>().text = "";
        GameObject confirmText = GameObject.Find("ConfirmText");
        confirmText.GetComponent<Text>().text = "";
    }
}
