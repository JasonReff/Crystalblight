using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    void Start()
    {
        GameObject shardText = GameObject.Find("ShardText");
        shardText.GetComponent<Text>().text = PlayerPrefs.GetInt("CurrentShards").ToString();
        string shopName = PlayerPrefs.GetString("CurrentTile");
        GameObject HPFlask = GameObject.Find("HPFlask");
        LoadSprite.FindSprite(HPFlask, PlayerPrefs.GetString("Item1Name"));
        GameObject HPFlaskPrice = GameObject.Find("HPFlaskPrice");
        HPFlaskPrice.GetComponent<Text>().text = PlayerPrefs.GetInt(PlayerPrefs.GetString("Item1Name") + "Price").ToString();
        GameObject SPFlask = GameObject.Find("SPFlask");
        LoadSprite.FindSprite(SPFlask, PlayerPrefs.GetString("Item2Name"));
        GameObject SPFlaskPrice = GameObject.Find("SPFlaskPrice");
        SPFlaskPrice.GetComponent<Text>().text = PlayerPrefs.GetInt(PlayerPrefs.GetString("Item2Name") + "Price").ToString();
        GameObject item1 = GameObject.Find("Item1");
        LoadSprite.FindSprite(item1, PlayerPrefs.GetString(shopName + "Item1"));
        string itemName = PlayerPrefs.GetString(shopName + "Item1");
        GameObject item1Price = GameObject.Find("Item1Price");
        item1Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject item2 = GameObject.Find("Item2");
        LoadSprite.FindSprite(item2, PlayerPrefs.GetString(shopName + "Item2"));
        itemName = PlayerPrefs.GetString(shopName + "Item2");
        GameObject item2Price = GameObject.Find("Item2Price");
        item2Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject item3 = GameObject.Find("Item3");
        LoadSprite.FindSprite(item3, PlayerPrefs.GetString(shopName + "Item3"));
        itemName = PlayerPrefs.GetString(shopName + "Item3");
        GameObject item3Price = GameObject.Find("Item3Price");
        item3Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject rune1 = GameObject.Find("Rune1");
        LoadSprite.FindSprite(rune1, PlayerPrefs.GetString(shopName + "Rune1"));
        itemName = PlayerPrefs.GetString(shopName + "Rune1");
        GameObject rune1Price = GameObject.Find("Rune1Price");
        rune1Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject rune2 = GameObject.Find("Rune2");
        LoadSprite.FindSprite(rune2, PlayerPrefs.GetString(shopName + "Rune2"));
        itemName = PlayerPrefs.GetString(shopName + "Rune2");
        GameObject rune2Price = GameObject.Find("Rune2Price");
        rune2Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject rune3 = GameObject.Find("Rune3");
        LoadSprite.FindSprite(rune3, PlayerPrefs.GetString(shopName + "Rune3"));
        itemName = PlayerPrefs.GetString(shopName + "Rune3");
        GameObject rune3Price = GameObject.Find("Rune3Price");
        rune3Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject sigil1 = GameObject.Find("Sigil1");
        LoadSprite.FindSprite(sigil1, PlayerPrefs.GetString(shopName + "Sigil1"));
        itemName = PlayerPrefs.GetString(shopName + "Sigil1");
        GameObject sigil1Price = GameObject.Find("Sigil1Price");
        sigil1Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject sigil2 = GameObject.Find("Sigil2");
        LoadSprite.FindSprite(sigil2, PlayerPrefs.GetString(shopName + "Sigil2"));
        itemName = PlayerPrefs.GetString(shopName + "Sigil2");
        GameObject sigil2Price = GameObject.Find("Sigil2Price");
        sigil2Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject sigil3 = GameObject.Find("Sigil3");
        LoadSprite.FindSprite(sigil3, PlayerPrefs.GetString(shopName + "Sigil3"));
        itemName = PlayerPrefs.GetString(shopName + "Sigil3");
        GameObject sigil3Price = GameObject.Find("Sigil3Price");
        sigil3Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject veil1 = GameObject.Find("Veil1");
        LoadSprite.FindSprite(veil1, PlayerPrefs.GetString(shopName + "Veil1"));
        itemName = PlayerPrefs.GetString(shopName + "Veil1");
        GameObject veil1Price = GameObject.Find("Veil1Price");
        veil1Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject veil2 = GameObject.Find("Veil2");
        LoadSprite.FindSprite(veil2, PlayerPrefs.GetString(shopName + "Veil2"));
        itemName = PlayerPrefs.GetString(shopName + "Veil2");
        GameObject veil2Price = GameObject.Find("Veil2Price");
        veil2Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
        GameObject veil3 = GameObject.Find("Veil3");
        LoadSprite.FindSprite(veil3, PlayerPrefs.GetString(shopName + "Veil3"));
        itemName = PlayerPrefs.GetString(shopName + "Veil3");
        GameObject veil3Price = GameObject.Find("Veil3Price");
        veil3Price.GetComponent<Text>().text = PlayerPrefs.GetInt(itemName + "Price").ToString();
    }

    private void OnMouseEnter()
    {
        GameObject itemDisplay = GameObject.Find("ItemDisplay");
        itemDisplay.transform.localPosition = new Vector3(400, 0, -2);
        string itemName = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        GameObject itemNameText = GameObject.Find("ItemNameText");
        itemNameText.GetComponent<Text>().text = itemName;
        GameObject itemDescription = GameObject.Find("ItemDescriptionText");
        itemDescription.GetComponent<Text>().text = PlayerPrefs.GetString(itemName + "Description");
        GameObject confirmText = GameObject.Find("ConfirmText");
        confirmText.GetComponent<Text>().text = "Confirm ---> ";
    }

    private void OnMouseExit()
    {
        GameObject itemDisplay = GameObject.Find("ItemDisplay");
        itemDisplay.transform.localPosition = new Vector3(400, 0, -2);
        string itemName = GameObject.Find(PlayerPrefs.GetString("ClickedItem")).GetComponent<SpriteRenderer>().sprite.name;
        GameObject itemNameText = GameObject.Find("ItemNameText");
        itemNameText.GetComponent<Text>().text = itemName;
        GameObject itemDescription = GameObject.Find("ItemDescriptionText");
        itemDescription.GetComponent<Text>().text = PlayerPrefs.GetString(itemName + "Description");
        GameObject confirmText = GameObject.Find("ConfirmText");
        confirmText.GetComponent<Text>().text = "Confirm ---> ";
    }

    private void OnMouseDown()
    {
        string itemName = this.name;
        PlayerPrefs.SetString("ClickedItem", itemName);
        GameObject merchantText = GameObject.Find("MerchantText");
        merchantText.GetComponent<Text>().text = "";
    }
}
