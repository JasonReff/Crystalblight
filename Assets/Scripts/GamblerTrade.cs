using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GamblerTrade : MonoBehaviour
{
    void Start()
    {
        int resource1Type = UnityEngine.Random.Range(1, 4);
        int resource2Type = 0;
        do {resource2Type = UnityEngine.Random.Range(1, 4); }
        while (resource2Type == resource1Type);
        float resource1WeightedValue = 0;
        float resource2WeightedValue = 0;
        GameObject character1Icon = GameObject.Find("Character1Icon");
        GameObject character1Resource = GameObject.Find("Character1Resource");
        GameObject character1ResourceValue = GameObject.Find("Character1ResourceValue");
        GameObject character2Icon = GameObject.Find("Character2Icon");
        GameObject character2Resource = GameObject.Find("Character2Resource");
        GameObject character2ResourceValue = GameObject.Find("Character2ResourceValue");
        switch (resource1Type)
        {
            
            case 1:
                int x = 0;
                do
                {
                    x = UnityEngine.Random.Range(1, 5);
                }
                while (PlayerPrefs.GetString("P" + x + "-Name") == "null");
                LoadSprite.FindSprite(character1Icon, PlayerPrefs.GetString("P" + x + "-Name") + "Head");
                character1Resource.GetComponent<Text>().text = PlayerPrefs.GetString("P" + x + "-Name") + "'s Health";
                int p1HP = PlayerPrefs.GetInt("P" + x + "-CHP");
                int random = UnityEngine.Random.Range(30, 61);
                p1HP = (int)(p1HP * (random/100));
                character1ResourceValue.GetComponent<Text>().text = "-" + p1HP.ToString();
                resource1WeightedValue = (float)(1.1 * p1HP);
                break;
            case 2:
                do
                {
                    x = UnityEngine.Random.Range(1, 5);
                }
                while (PlayerPrefs.GetString("P" + x + "-Name") == "null");
                LoadSprite.FindSprite(character1Icon, PlayerPrefs.GetString("P" + x + "-Name") + "Head");
                character1Resource.GetComponent<Text>().text = PlayerPrefs.GetString("P" + x + "-Name") + "'s SP";
                int p1SP = PlayerPrefs.GetInt("P" + x + "-CSP");
                random = UnityEngine.Random.Range(30, 61);
                p1SP = (int)(p1SP * (random/100));
                character1ResourceValue.GetComponent<Text>().text = "-" + p1SP.ToString();
                resource1WeightedValue = (float)(1.3 * p1SP);
                break;
            case 3:
                int shards = PlayerPrefs.GetInt("CurrentShards");
                LoadSprite.FindSprite(character1Icon, "null");
                character1Resource.GetComponent<Text>().text = "Shards";
                random = UnityEngine.Random.Range(0, shards);
                character1ResourceValue.GetComponent<Text>().text = "-" + random.ToString();
                resource1WeightedValue = random;
                break;
        }
        resource2WeightedValue = (float)(resource1WeightedValue * 1.1);
        switch (resource2Type)
        {
            case 1:
                int x = 0;
                do
                {
                    x = UnityEngine.Random.Range(1, 5);
                }
                while (PlayerPrefs.GetString("P" + x + "-Name") == "null");
                LoadSprite.FindSprite(character2Icon, PlayerPrefs.GetString("P" + x + "-Name") + "Head");
                character2Resource.GetComponent<Text>().text = PlayerPrefs.GetString("P" + x + "-Name") + "'s HP";
                int p2HP = (int)(resource2WeightedValue / 1.1);
                character2ResourceValue.GetComponent<Text>().text = "+" + p2HP.ToString();
                break;
            case 2:
                do
                {
                    x = UnityEngine.Random.Range(1, 5);
                }
                while (PlayerPrefs.GetString("P" + x + "-Name") == "null");
                LoadSprite.FindSprite(character2Icon, PlayerPrefs.GetString("P" + x + "-Name") + "Head");
                character2Resource.GetComponent<Text>().text = PlayerPrefs.GetString("P" + x + "-Name") + "'s SP";
                int p2SP = (int)(resource2WeightedValue / 1.3);
                character2ResourceValue.GetComponent<Text>().text = "+" + p2SP.ToString();
                break;
            case 3:
                LoadSprite.FindSprite(character2Icon, "null");
                character2Resource.GetComponent<Text>().text = "Shards";
                int shards = (int)resource2WeightedValue;
                character2ResourceValue.GetComponent<Text>().text = "+" + shards.ToString();
                break;
        }
    }

    private void OnMouseDown()
    {
        string resource1Type = GameObject.Find("Character1Resource").GetComponent<Text>().text;
        string resource2Type = GameObject.Find("Character2Resource").GetComponent<Text>().text;
        int resource1Value = Int32.Parse(GameObject.Find("Character1ResourceValue").GetComponent<Text>().text.Substring(1));
        int resource2Value = Int32.Parse(GameObject.Find("Character2ResourceValue").GetComponent<Text>().text.Substring(1));
        string character1 = "";
        string character2 = "";
        if (GameObject.Find("Character1Icon").GetComponent<SpriteRenderer>().name != null) 
        {
            character1 = GameObject.Find("Character1Icon").GetComponent<SpriteRenderer>().sprite.name.Remove(GameObject.Find("Character1Icon").
                GetComponent<SpriteRenderer>().sprite.name.Length - 4, 4);
        }
        if (GameObject.Find("Character1Icon").GetComponent<SpriteRenderer>().name != null)
        {
            character2 = GameObject.Find("Character2Icon").GetComponent<SpriteRenderer>().sprite.name.Remove(GameObject.Find("Character2Icon").
                GetComponent<SpriteRenderer>().sprite.name.Length - 4, 4);
        }
        int character1Number = PlayerPrefs.GetInt(character1 + "P");
        int character2Number = PlayerPrefs.GetInt(character2 + "P");
        if (resource1Type.Substring(resource1Type.Length - 2) == "SP" || resource1Type.Substring(resource1Type.Length - 2) == "HP")
        {
            resource1Type = resource1Type.Substring(resource1Type.Length - 2);
        }
        if (resource2Type.Substring(resource2Type.Length - 2) == "SP" || resource2Type.Substring(resource2Type.Length - 2) == "HP")
        {
            resource2Type = resource2Type.Substring(resource2Type.Length - 2);
        }
        switch (resource1Type)
        {
            case "HP":
                int HP = PlayerPrefs.GetInt("P" + character1Number + "-CHP");
                HP -= resource1Value;
                if (HP < 0) { HP = 0; }
                PlayerPrefs.SetInt("P" + character1Number + "-CHP", HP);
                break;
            case "SP":
                int SP = PlayerPrefs.GetInt("P" + character1Number + "-CSP");
                SP -= resource1Value;
                if (SP < 0) { SP = 0; }
                PlayerPrefs.SetInt("P" + character1Number + "-CSP", SP);
                break;
            case "Shards":
                int shards = PlayerPrefs.GetInt("CurrentShards");
                shards -= resource1Value;
                if (shards < 0) { shards = 0; }
                PlayerPrefs.SetInt("CurrentShards", shards);
                break;
            default:
                break;
        }
        switch (resource2Type)
        {
            case "HP":
                int HP = PlayerPrefs.GetInt("P" + character2Number + "-CHP");
                int maxHP = PlayerPrefs.GetInt("P" + character2Number + "-HP");
                HP += resource2Value;
                if (HP > maxHP) { HP = maxHP; }
                PlayerPrefs.SetInt("P" + character2Number + "-CHP", HP);
                break;
            case "SP":
                int SP = PlayerPrefs.GetInt("P" + character2Number + "-CSP");
                int maxSP = PlayerPrefs.GetInt("P" + character2Number + "-SP");
                SP -= resource2Value;
                if (SP > maxSP) { SP = maxSP; }
                PlayerPrefs.SetInt("P" + character2Number + "-CSP", SP);
                break;
            case "Shards":
                int shards = PlayerPrefs.GetInt("CurrentShards");
                shards -= resource2Value;
                PlayerPrefs.SetInt("CurrentShards", shards);
                break;
            default:
                break;
        }
        GameObject.Find("TradeText").GetComponent<Text>().text = "I hope you got what you wanted.";
        Invoke("GoToMap", 2.0f);
    }

    private void GoToMap()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Map- Hexagon");
    }
}
