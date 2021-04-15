using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceSource : MonoBehaviour
{
    void Start()
    {
        for (int x = 1; x <= 4; x++)
        {
            GameObject characterIcon = GameObject.Find("Character" + x + "Icon");
            if (PlayerPrefs.GetString("P" + x + "-Name") != "null")
            {
                LoadSprite.FindSprite(characterIcon, PlayerPrefs.GetString("P" + x + "-Name") + "Head");
            }
            else
            {
                Vector3 position = characterIcon.transform.position;
                characterIcon.transform.position = new Vector3(position.x, position.y, 1);
            }
        }
        PlayerPrefs.SetString("EssenceButtonClicked", "null");
        GameObject.Find("ConfirmText").GetComponent<Text>().text = "";
    }

    private void OnMouseDown()
    {
        if (this.GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            int p = Int32.Parse(this.name[this.name.Length - 5].ToString());
            PlayerPrefs.SetInt("EssenceCharacterClicked", p);
            for (int q = 1; q <= 4; q++)
            {
                if (q != p) { GameObject.Find("Character" + q + "Icon").GetComponent<SpriteRenderer>().color = Color.white; }
            }
        }
    }
}
