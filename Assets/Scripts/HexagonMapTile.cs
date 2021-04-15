using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class HexagonMapTile : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile empty;
    public Tile home;
    public Tile characterA;
    public Tile characterB;
    public Tile combat;
    public Tile shop;
    public Tile gambler;
    public Tile essence;
    public Tile miniboss;
    public Tile boss;
    public EnemyAllocation enemyAllocation;
    public ShopAllocation shopAllocation;
    public GamblerAllocation gamblerAllocation;

    public void Start()
    {
        if (PlayerPrefs.GetInt("P2-Selected") == 0)
        {
            if (new string[] { "Abandoned Dungeon", "Shifting Sands", "The Ascension", "Courtyard", "Parish", "Outskirts" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage1Seed"); }
            else if (new string[] { "Ramparts", "Glass Ocean", "The Labyrinth", "Stomach", "Plague Ward", "Nest" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage2Seed"); }
            else if (new string[] { "Throne Room", "Sunken Tomb", "The Archives", "The Eye", "Inferno", "Veridian Lake" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage3Seed"); }
            string p1Name = PlayerPrefs.GetString("P1-Name");
            int p1 = 0;
            if (p1Name == "Reaper") { p1 = 1; }
            if (p1Name == "Matriarch") { p1 = 2; }
            if (p1Name == "Hollow") { p1 = 3; }
            if (p1Name == "Shadow") { p1 = 4; }
            if (p1Name == "Storm") { p1 = 5; }
            int p2A = UnityEngine.Random.Range(1, 6);
            while (p2A == p1)
            {
                p2A = UnityEngine.Random.Range(1, 6);
            }
            PSet(p2A, "P2A-Name");
            int p2B = UnityEngine.Random.Range(1, 6);
            while (p2B == p2A || p2B == p1)
            {
                p2B = UnityEngine.Random.Range(1, 6);
            }
            PSet(p2B, "P2B-Name");
            }
        if (PlayerPrefs.GetInt("CombatSet") == 0)
        {
            if (new string[] { "Abandoned Dungeon", "Shifting Sands", "The Ascension", "Courtyard", "Parish", "Outskirts" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage1Seed"); }
            else if (new string[] { "Ramparts", "Glass Ocean", "The Labyrinth", "Stomach", "Plague Ward", "Nest" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage2Seed"); }
            else if (new string[] { "Throne Room", "Sunken Tomb", "The Archives", "The Eye", "Inferno", "Veridian Lake" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage3Seed"); }
            enemyAllocation.CombatSet();
            shopAllocation.ShopSet();
            gamblerAllocation.GamblerSet();
            PlayerPrefs.SetInt("CombatSet", 1);
        }
        enemyAllocation.CombatXPDisplay();
        CharacterIcon();
    }

    public void Update()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = tilemap.WorldToCell(position);
        if (tilemap.GetTile(tilePosition) == characterA || tilemap.GetTile(tilePosition) == characterB)
        {
            if (PlayerPrefs.GetInt("P2-Selected") == 0)
            {
                GameObject.Find("CharacterDisplay").transform.localPosition = new Vector3(173, -128, -4);
                GameObject.Find("CharacterName").transform.localPosition = new Vector3(176, -70, -5);
                GameObject.Find("CharacterLevel").transform.localPosition = new Vector3(176, -94, -5);
                GameObject.Find("CharacterSkill1").transform.localPosition = new Vector3(95, -127, -5);
                GameObject.Find("CharacterSkill2").transform.localPosition = new Vector3(95, -146, -5);
                GameObject.Find("CharacterSkill3").transform.localPosition = new Vector3(95, -166, -5);
                GameObject.Find("CharacterSkill4").transform.localPosition = new Vector3(95, -185, -5);
                string characterName = "";
                if (tilemap.GetTile(tilePosition) == characterA) { characterName = PlayerPrefs.GetString("P2A-Name"); }
                if (tilemap.GetTile(tilePosition) == characterB) { characterName = PlayerPrefs.GetString("P2B-Name"); }
                LoadSprite.FindSprite(GameObject.Find("CharacterIcon"), characterName + "Head");
                GameObject.Find("CharacterName").GetComponent<Text>().text = characterName;
                GameObject.Find("CharacterLevel").GetComponent<Text>().text = "Level: " + PlayerPrefs.GetInt(characterName + "-Level").ToString();
                GameObject.Find("CharacterSkill1").GetComponent<Text>().text = "Skill 1: " + PlayerPrefs.GetString(characterName + "Level1Skill1");
                GameObject.Find("CharacterSkill2").GetComponent<Text>().text = "Skill 2: " + PlayerPrefs.GetString(characterName + "-Skill-2");
                GameObject.Find("CharacterSkill3").GetComponent<Text>().text = "Skill 3: " + PlayerPrefs.GetString(characterName + "-Skill-3");
                GameObject.Find("CharacterSkill4").GetComponent<Text>().text = "Skill 4: " + PlayerPrefs.GetString(characterName + "-Skill-4");
            }
        }
        else
        {
            GameObject.Find("CharacterDisplay").transform.localPosition = new Vector3(173, -128, 1);
            GameObject.Find("CharacterName").transform.localPosition = new Vector3(176, -70, 1);
            GameObject.Find("CharacterLevel").transform.localPosition = new Vector3(176, -94, 1);
            GameObject.Find("CharacterSkill1").transform.localPosition = new Vector3(95, -127, 1);
            GameObject.Find("CharacterSkill2").transform.localPosition = new Vector3(95, -146, 1);
            GameObject.Find("CharacterSkill3").transform.localPosition = new Vector3(95, -166, 1);
            GameObject.Find("CharacterSkill4").transform.localPosition = new Vector3(95, -185, 1);
        }
    }
    public void OnMouseDown()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = tilemap.WorldToCell(position);
        Vector3Int previousTile = new Vector3Int(PlayerPrefs.GetInt("CurrentTileX"), PlayerPrefs.GetInt("CurrentTileY"), 0);
        if (tilemap.GetTile(tilePosition) != empty) {
            if (previousTile == GridLeftUp(tilePosition) || previousTile == GridLeft(tilePosition) || previousTile == GridLeftDown(tilePosition))
            {
                string tileName = PlayerPrefs.GetString("Grid-X-" + tilePosition.x + "-Y-" + tilePosition.y);
                PlayerPrefs.SetInt("CurrentTileX", tilePosition.x);
                PlayerPrefs.SetInt("CurrentTileY", tilePosition.y);
                PlayerPrefs.SetString("CurrentTile", tileName);
                switch (tileName[0])
                {
                    //combat or character
                    case 'C':
                        if (tileName[1] == 'h')
                        {
                            if (tileName == "CharacterA")
                            {
                                PlayerPrefs.SetString("P2-Name", PlayerPrefs.GetString("P2A-Name"));
                                PlayerPrefs.SetInt(PlayerPrefs.GetString("P2A-Name") + "P", 2);
                                PlayerPrefs.SetInt("P2-Level", 1);
                                PlayerPrefs.SetInt("P2-VIT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-VIT"));
                                PlayerPrefs.SetInt("P2-STR", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-STR"));
                                PlayerPrefs.SetInt("P2-INT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-INT"));
                                PlayerPrefs.SetInt("P2-DEX", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-DEX"));
                                PlayerPrefs.SetInt("P2-END", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-END"));
                                PlayerPrefs.SetInt("P2-XP", 0);
                                PlayerPrefs.SetInt("P2-XPMax", 50);
                                PlayerPrefs.SetString("P2-Skill-1", PlayerPrefs.GetString(PlayerPrefs.GetString("P2A-Name") + "Level1Skill1"));
                                PlayerPrefs.SetString("P2-Skill-2", "Null");
                                PlayerPrefs.SetString("P2-Skill-3", "Null");
                                PlayerPrefs.SetString("P2-Skill-4", "Null");
                                PlayerPrefs.SetString("P2-PassiveSkill", "Null");
                                PlayerPrefs.SetString("P2Status0", "null");
                                PlayerPrefs.SetInt("P2Status0X", 0);
                                PlayerPrefs.SetString("P2Status1", "null");
                                PlayerPrefs.SetInt("P2Status1X", 0);
                                PlayerPrefs.SetString("P2Status2", "null");
                                PlayerPrefs.SetInt("P2Status2X", 0);
                                PlayerPrefs.SetString("P2Status3", "null");
                                PlayerPrefs.SetInt("P2Status3X", 0);
                                int discipline = Int32.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID")
                                [PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID").Length - 1].ToString());
                                PlayerPrefs.SetString("P2-Ultimate", PlayerPrefs.GetString(PlayerPrefs.GetString("P2A-Name") + "-Ultimate" + discipline));
                                PlayerPrefs.SetString("P2-Special", PlayerPrefs.GetString(PlayerPrefs.GetString("P2A-Name") + "-Special" + discipline));
                                PlayerPrefs.SetInt("P2-SpecialMeter", 0);
                                PlayerPrefs.SetInt("P2-SpecialMax", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2A-Name") + "-Special" + discipline + "Max"));
                                PlayerPrefs.SetInt("P2-HP", 40 + 20 * PlayerPrefs.GetInt("P2-VIT"));
                                PlayerPrefs.SetInt("P2-SP", 30 + 10 * PlayerPrefs.GetInt("P2-INT"));
                                PlayerPrefs.SetInt("P2-CHP", PlayerPrefs.GetInt("P2-HP"));
                                PlayerPrefs.SetInt("P2-CSP", PlayerPrefs.GetInt("P2-SP"));
                                PlayerPrefs.SetInt("P2-Attack", 5 + 2 * PlayerPrefs.GetInt("P2-STR"));
                                PlayerPrefs.SetInt("P2-Guard", 10 * PlayerPrefs.GetInt("P2-END"));
                                PlayerPrefs.SetInt("P2-CG", PlayerPrefs.GetInt("P2-Guard"));
                                PlayerPrefs.SetInt("P2-DefGuard", 2 * PlayerPrefs.GetInt("P2-END"));
                                PlayerPrefs.SetInt("P2-Accuracy", 85 + PlayerPrefs.GetInt("P2-DEX"));
                                PlayerPrefs.SetInt("P2-Dodge", 5 + PlayerPrefs.GetInt("P2-DEX"));
                                PlayerPrefs.SetInt("P2-CritRate", 5 + 2 * PlayerPrefs.GetInt("P2-DEX"));
                            }
                            else if (tileName == "CharacterB")
                            {
                                PlayerPrefs.SetString("P2-Name", PlayerPrefs.GetString("P2B-Name"));
                                PlayerPrefs.SetInt(PlayerPrefs.GetString("P2B-Name") + "P", 2);
                                PlayerPrefs.SetInt("P2-Level", 1);
                                PlayerPrefs.SetInt("P2-VIT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-VIT"));
                                PlayerPrefs.SetInt("P2-STR", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-STR"));
                                PlayerPrefs.SetInt("P2-INT", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-INT"));
                                PlayerPrefs.SetInt("P2-DEX", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-DEX"));
                                PlayerPrefs.SetInt("P2-END", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-END"));
                                PlayerPrefs.SetInt("P2-XP", 0);
                                PlayerPrefs.SetInt("P2-XPMax", 50);
                                PlayerPrefs.SetString("P2-Skill-1", PlayerPrefs.GetString(PlayerPrefs.GetString("P2B-Name") + "Level1Skill1"));
                                PlayerPrefs.SetInt("P2-S1-Cost", 12);
                                PlayerPrefs.SetInt("P2-S1-Damage", PlayerPrefs.GetInt("P1-INT") * 10);
                                PlayerPrefs.GetString("P2-S1-Desc", "Fira: does Int*10 fire Damage for 12 sp (I will make a card hover or whatever for this later)");
                                PlayerPrefs.SetString("P2-Skill-2", "Null");
                                PlayerPrefs.SetString("P2-Skill-3", "Null");
                                PlayerPrefs.SetString("P2-Skill-4", "Null");
                                PlayerPrefs.SetString("P2-PassiveSkill", "Null");
                                PlayerPrefs.SetString("P2Status0", "null");
                                PlayerPrefs.SetInt("P2Status0X", 0);
                                PlayerPrefs.SetString("P2Status1", "null");
                                PlayerPrefs.SetInt("P2Status1X", 0);
                                PlayerPrefs.SetString("P2Status2", "null");
                                PlayerPrefs.SetInt("P2Status2X", 0);
                                PlayerPrefs.SetString("P2Status3", "null");
                                PlayerPrefs.SetInt("P2Status3X", 0);
                                int discipline = Int32.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID")
                                [PlayerPrefs.GetString(PlayerPrefs.GetString("P2-Skill-1") + "ID").Length - 1].ToString());
                                PlayerPrefs.SetString("P2-Ultimate", PlayerPrefs.GetString(PlayerPrefs.GetString("P2B-Name") + "-Ultimate" + discipline));
                                PlayerPrefs.SetString("P2-Special", PlayerPrefs.GetString(PlayerPrefs.GetString("P2B-Name") + "-Special" + discipline));
                                PlayerPrefs.SetInt("P2-SpecialMeter", 0);
                                PlayerPrefs.SetInt("P2-SpecialMax", PlayerPrefs.GetInt(PlayerPrefs.GetString("P2B-Name") + "-Special" + discipline + "Max"));
                                PlayerPrefs.SetInt("P2-HP", 40 + 20 * PlayerPrefs.GetInt("P2-VIT"));
                                PlayerPrefs.SetInt("P2-SP", 30 + 10 * PlayerPrefs.GetInt("P2-INT"));
                                PlayerPrefs.SetInt("P2-CHP", PlayerPrefs.GetInt("P2-HP"));
                                PlayerPrefs.SetInt("P2-CSP", PlayerPrefs.GetInt("P2-SP"));
                                PlayerPrefs.SetInt("P2-Attack", 5 + 2 * PlayerPrefs.GetInt("P2-STR"));
                                PlayerPrefs.SetInt("P2-Guard", 10 * PlayerPrefs.GetInt("P2-END"));
                                PlayerPrefs.SetInt("P2-CG", PlayerPrefs.GetInt("P2-Guard"));
                                PlayerPrefs.SetInt("P2-DefGuard", 2 * PlayerPrefs.GetInt("P2-END"));
                                PlayerPrefs.SetInt("P2-Accuracy", 85 + PlayerPrefs.GetInt("P2-DEX"));
                                PlayerPrefs.SetInt("P2-Dodge", 5 + PlayerPrefs.GetInt("P2-DEX"));
                                PlayerPrefs.SetInt("P2-CritRate", 5 + 2 * PlayerPrefs.GetInt("P2-DEX"));
                            }
                            PlayerPrefs.SetInt("P2-Selected", 1);
                            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                            SceneManager.LoadScene("CharacterSet");
                        }
                        if (tileName[1] == 'o')
                        {
                            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                            SceneManager.LoadScene("2E Battle");
                        }
                        break;
                    //boss
                    case 'B':
                        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                        SceneManager.LoadScene("2E Battle");
                        break;
                    //shop
                    case 'S':
                        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                        SceneManager.LoadScene("Shop");
                        break;
                    //gambler
                    case 'G':
                        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                        if (PlayerPrefs.GetString(tileName + "Type") == "Trade") 
                        {
                        SceneManager.LoadScene("Gambler- Trade");
                        }
                        break;
                    //essence
                    case 'E':
                            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                            SceneManager.LoadScene("EssenceSource");
                        break;
                    //miniboss
                    case 'M':
                        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                        SceneManager.LoadScene("2E Battle");
                        break;
                }
            }
        }
    }

    public void CharacterIcon()
    {
        GameObject characterCompass = GameObject.Find("CharacterCompass");
        LoadSprite.FindSprite(characterCompass, PlayerPrefs.GetString("P1-Name"));
        characterCompass.transform.localPosition = tilemap.CellToWorld(new Vector3Int(PlayerPrefs.GetInt("CurrentTileX"), PlayerPrefs.GetInt("CurrentTileY"), 0));
    }

    private Vector3Int GridLeftUp(Vector3Int tilePosition)
    {
        Vector3 position = tilemap.CellToWorld(tilePosition);
        position += new Vector3(-15, 23, 0);
        tilePosition = tilemap.WorldToCell(position);
        return tilePosition;
    }

    private Vector3Int GridLeftDown(Vector3Int tilePosition)
    {
        Vector3 position = tilemap.CellToWorld(tilePosition);
        position += new Vector3(-15, -23, 0);
        tilePosition = tilemap.WorldToCell(position);
        return tilePosition;
    }

    private Vector3Int GridLeft(Vector3Int tilePosition)
    {
        Vector3 position = tilemap.CellToWorld(tilePosition);
        position += new Vector3(-30, 0, 0);
        tilePosition = tilemap.WorldToCell(position);
        return tilePosition;
    }
    void PSet(int p, string pName)
    {
        if (p == 1) { PlayerPrefs.SetString(pName, "Reaper"); }
        if (p == 2) { PlayerPrefs.SetString(pName, "Matriarch"); }
        if (p == 3) { PlayerPrefs.SetString(pName, "Hollow"); }
        if (p == 4) { PlayerPrefs.SetString(pName, "Shadow"); }
        if (p == 5) { PlayerPrefs.SetString(pName, "Storm"); }
    }
}
