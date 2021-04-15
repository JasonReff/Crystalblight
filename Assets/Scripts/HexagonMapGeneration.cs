using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class HexagonMapGeneration : MonoBehaviour
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
    public GameObject combatXP;
    void Start()
    {
        if (PlayerPrefs.GetInt("MapGenerated") == 0)
        {
            if (new string[] { "Abandoned Dungeon", "Shifting Sands", "The Ascension", "Courtyard", "Parish", "Outskirts" }.Contains(PlayerPrefs.GetString("CurrentStage"))) 
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage1Seed"); }
            else if (new string[] { "Ramparts", "Glass Ocean", "The Labyrinth", "Stomach", "Plague Ward", "Nest" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage2Seed"); }
            else if (new string[] { "Throne Room", "Sunken Tomb", "The Archives", "The Eye", "Inferno", "Veridian Lake" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            { UnityEngine.Random.seed = PlayerPrefs.GetInt("Stage3Seed"); }
            HomeTile();
            CharacterTiles();
            RandomTileSet2();
            TileNoise();
            RingSet();
            BossTiles();
            CombatOverwrite();
            CombatOverwrite2();
            TileLabels();
            PlayerPrefs.SetInt("MapGenerated", 1);
        }
        else
        {
            LoadMap();
        }
        CharacterStats();

    }

    private void HomeTile()
    {
        Vector3Int position = new Vector3Int(-10, 0, 0);
        tilemap.SetTile(position, home);
        PlayerPrefs.SetInt("CurrentTileX", -10);
        PlayerPrefs.SetInt("CurrentTileY", 0);
        PlayerPrefs.SetString("Grid-X-" + -10 + "-Y-" + 0, "Home");
    }

    private void CharacterTiles()
    {
        tilemap.SetTile(new Vector3Int(-10, 1, 0), characterA);
        tilemap.SetTile(new Vector3Int(-10, -1, 0), characterB);
    }

    private void BossTiles()
    {
        tilemap.SetTile(new Vector3Int(0, 0, 0), miniboss);
        tilemap.SetTile(new Vector3Int(10, 0, 0), boss);
        PlayerPrefs.SetString("MinibossCoordinates", "00");
        PlayerPrefs.SetString("Grid-X-" + 0 + "-Y-" + 0, "Miniboss");
        PlayerPrefs.SetString("BossCoordinates", "100");
        PlayerPrefs.SetString("Grid-X-" + 10 + "-Y-" + 0, "Boss");
        Vector3 position = tilemap.CellToWorld(new Vector3Int(10, 0, 0));
        GameObject bossXP1 = Instantiate(combatXP, position, Quaternion.identity, combatXP.transform.parent);
        bossXP1.name = "BossXP";
        int XP = PlayerPrefs.GetInt("Boss-XP");
        bossXP1.GetComponent<Text>().text = XP.ToString();
        position = tilemap.CellToWorld(new Vector3Int(0, 0, 0));
        bossXP1 = Instantiate(combatXP, position, Quaternion.identity, combatXP.transform.parent);
        bossXP1.name = "MinibossXP";
        XP = PlayerPrefs.GetInt("Miniboss-XP");
        bossXP1.GetComponent<Text>().text = XP.ToString();
    }


    private void RandomTileSet2()
    {
        for (int x = -9; x <= -1; x++)
        {
            tilemap.SetTile(new Vector3Int(x, 2, 0), combat);
            tilemap.SetTile(new Vector3Int(x, -2, 0), combat);
        }
        for (int x = 1; x <= 9; x++)
        {
            tilemap.SetTile(new Vector3Int(x, 2, 0), combat);
            tilemap.SetTile(new Vector3Int(x, -2, 0), combat);
        }
        tilemap.SetTile(new Vector3Int(-1, 1, 0), combat);
        tilemap.SetTile(new Vector3Int(-1, -1, 0), combat);
        tilemap.SetTile(new Vector3Int(0, 1, 0), combat);
        tilemap.SetTile(new Vector3Int(0, -1, 0), combat);
        tilemap.SetTile(new Vector3Int(9, 1, 0), combat);
        tilemap.SetTile(new Vector3Int(9, -1, 0), combat);
    }

    private void TileNoise()
    {
        for (int x = -9; x <= 8; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                int random = UnityEngine.Random.Range(1, 11);
                if (random <= 3)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), combat);
                }
                int gridLeftUp = 0;
                int gridLeftDown = 0;
                int gridLeft = 0;
                int gridRight = 0;
                int gridRightUp;
                int gridRightDown = 0;
                int leftTile = 0;
                int rightTile = 0;
                if (tilemap.GetTile(GridLeftUp(new Vector3Int(x,y,0))) != empty) { gridLeftUp = 1; } else { gridLeftUp = 0; }
                if (tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) != empty) { gridLeft = 1; } else { gridLeft = 0; }
                if (tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) != empty) { gridLeftDown = 1; } else { gridLeftDown = 0; }
                if (tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) != empty) { gridRightUp = 1; } else { gridRightUp = 0; }
                if (tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) != empty) { gridRight = 1; } else { gridRight = 0; }
                if (tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) != empty) { gridRightDown = 1; } else { gridRightDown = 0; }
                if (gridLeftUp == 1 || gridLeft == 1 || gridLeftDown == 1) { leftTile = 1; } else { leftTile = 0; }
                if (gridRightUp == 1 || gridRight == 1 || gridRightDown == 1) { rightTile = 1; } else { rightTile = 0; }
                if (leftTile == 0 || rightTile == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), empty);
                }
            }
        }
    }



    private void RingSet()
    {
        for (int x = -9; x <= 8; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                int gridLeftUp = 0;
                int gridLeftDown = 0;
                int gridLeft = 0;
                int gridRight = 0;
                int gridRightUp;
                int gridRightDown = 0;
                if (tilemap.GetTile(GridLeftUp(new Vector3Int(x, y, 0))) != empty) { gridLeftUp = 1; } else { gridLeftUp = 0; }
                if (tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) != empty) { gridLeft = 1; } else { gridLeft = 0; }
                if (tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) != empty) { gridLeftDown = 1; } else { gridLeftDown = 0; }
                if (tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) != empty) { gridRightUp = 1; } else { gridRightUp = 0; }
                if (tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) != empty) { gridRight = 1; } else { gridRight = 0; }
                if (tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) != empty) { gridRightDown = 1; } else { gridRightDown = 0; }
                if (gridLeftUp == 1 && gridLeft == 1 && gridLeftDown == 1 && gridRightUp == 1 && gridRight == 1 && gridRightDown == 1)
                {
                    int random = UnityEngine.Random.Range(1, 3);
                    if (random == 1)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), empty);
                    }
                }
            }
        }
    }

    private void CombatOverwrite()
    {
        for (int x = -9; x <= 8; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x,y,0)) == combat) 
                {
                    int adjacentEvent = 0;
                    if (tilemap.GetTile(GridLeftUp(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridLeftUp(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (adjacentEvent == 0)
                    {
                        int random = UnityEngine.Random.Range(1, 6);
                        if (random == 1)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), shop);
                        }
                        if (random == 2)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), gambler);
                        }
                        if (random == 3)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), essence);
                        }
                    }
                    if (adjacentEvent == 1)
                    {
                        int random = UnityEngine.Random.Range(1, 9);
                        if (random == 1)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), shop);
                        }
                        if (random == 2)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), gambler);
                        }
                        if (random == 3)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), essence);
                        }
                    }
                }
            }
        }
        tilemap.SetTile(new Vector3Int(-9, 0, 0), empty);
    }

    private void CombatOverwrite2()
    {
        for (int x = -9; x <= 8; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) == combat)
                {
                    int adjacentEvent = 0;
                    int adjacentCombat = 0;
                    if (tilemap.GetTile(GridLeftUp(new Vector3Int(x, y, 0))) == combat) { adjacentCombat++; }
                    if (tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) == combat) { adjacentCombat++; }
                    if (tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) == combat) { adjacentCombat++; }
                    if (tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) == combat) { adjacentCombat++; }
                    if (tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) == combat) { adjacentCombat++; }
                    if (tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) == combat) { adjacentCombat++; }
                    if (tilemap.GetTile(GridLeftUp(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridLeftUp(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridLeft(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridLeftDown(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridRightUp(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridRight(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) == empty || tilemap.GetTile(GridRightDown(new Vector3Int(x, y, 0))) == combat) { } else { adjacentEvent++; }
                    if (adjacentEvent == 2)
                    {
                        int random = UnityEngine.Random.Range(1, 3);
                        if (random == 1)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), combat);
                        }
                    }
                    if (adjacentEvent >= 3)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), combat);
                    }
                    if (adjacentCombat >= adjacentEvent + 2)
                    {
                        int random = UnityEngine.Random.Range(1, 5);
                        if (random == 1)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), shop);
                        }
                        if (random == 2)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), gambler);
                        }
                        if (random == 3)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), essence);
                        }
                    }
                }
            }
        }
    }

    private void TileLabels()
    {
        int combatNumber = 0;
        int shopNumber = 0;
        int gamblerNumber = 0;
        int essenceNumber = 0;
        for (int x = -11; x <= 11; x++)
        {
            for (int y = -5; y <= 5; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) == combat)
                {
                    combatNumber++;
                    Vector3 position = tilemap.CellToWorld(new Vector3Int(x, y, 0));
                    GameObject combatXP1 = Instantiate(combatXP, position, Quaternion.identity, combatXP.transform.parent);
                    combatXP1.name = "Combat" + combatNumber + "XP";
                    int XP = PlayerPrefs.GetInt("Combat" + combatNumber + "XP");
                    combatXP1.GetComponent<Text>().text = XP.ToString();
                    PlayerPrefs.SetString("Combat" + combatNumber + "Coordinates", x.ToString() + y.ToString());
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "Combat" + combatNumber);
                }
                else if (tilemap.GetTile(new Vector3Int(x,y,0)) == shop)
                {
                    shopNumber++;
                    PlayerPrefs.SetString("Shop" + shopNumber + "Coordinates", x.ToString() + y.ToString());
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "Shop" + shopNumber);
                }
                else if (tilemap.GetTile(new Vector3Int(x, y, 0)) == gambler)
                {
                    gamblerNumber++;
                    PlayerPrefs.SetString("Gambler" + gamblerNumber + "Coordinates", x.ToString() + y.ToString());
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "Gambler" + gamblerNumber);
                }
                else if (tilemap.GetTile(new Vector3Int(x, y, 0)) == essence)
                {
                    essenceNumber++;
                    PlayerPrefs.SetString("Essence" + essenceNumber + "Coordinates", x.ToString() + y.ToString());
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "Essence" + essenceNumber);
                }
                else if (tilemap.GetTile(new Vector3Int(x,y,0)) == characterA)
                {
                    PlayerPrefs.SetString("CharacterACoordinates", x.ToString() + y.ToString());
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "CharacterA");
                }
                else if (tilemap.GetTile(new Vector3Int(x, y, 0)) == characterB)
                {
                    PlayerPrefs.SetString("CharacterBCoordinates", x.ToString() + y.ToString());
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "CharacterB");
                }
                else if (tilemap.GetTile(new Vector3Int(x,y,0)) == home || tilemap.GetTile(new Vector3Int(x, y, 0)) == miniboss || tilemap.GetTile(new Vector3Int(x, y, 0)) == boss) { }
                else
                {
                    PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "");
                }
            }
        }
        PlayerPrefs.SetInt("ShopLimit", shopNumber);
        PlayerPrefs.SetInt("GamblerLimit", gamblerNumber);
            PlayerPrefs.SetString("CharacterACoordinates", "-101");
            PlayerPrefs.SetString("Grid-X-" + -10 + "-Y-" + 1, "CharacterA");
            PlayerPrefs.SetString("CharacterBCoordinates", "-10-1");
            PlayerPrefs.SetString("Grid-X-" + -10 + "-Y-" + -1, "CharacterB");
    }

    private void LoadMap()
    {
        for (int x = -11; x <= 11; x++)
        {
            for (int y = -5; y <= 5; y++)
            {
                string tileName = PlayerPrefs.GetString("Grid-X-" + x + "-Y-" + y);
                Vector3 position = tilemap.CellToWorld(new Vector3Int(x, y, 0));
                int XP;
                if (tileName != "")
                {
                    switch (tileName[0])
                    {
                        case 'C':
                            if (tileName[1] == 'h')
                            {
                                if (tileName == "CharacterA")
                                {
                                    tilemap.SetTile(new Vector3Int(x, y, 0), characterA);
                                }
                                else if (tileName == "CharacterB")
                                {
                                    tilemap.SetTile(new Vector3Int(x, y, 0), characterB);
                                }
                            }
                            else if (tileName[1] == 'o')
                            {
                                tilemap.SetTile(new Vector3Int(x, y, 0), combat);
                                int combatNumber = 0;
                                if (tileName.Length == 7) { combatNumber = Int32.Parse(tileName[6].ToString()); }
                                if (tileName.Length == 8) { combatNumber = Int32.Parse(tileName[6].ToString() + tileName[7].ToString()); }
                                GameObject combatXP1 = Instantiate(combatXP, position, Quaternion.identity, combatXP.transform.parent);
                                combatXP1.name = "Combat" + combatNumber + "XP";
                                XP = PlayerPrefs.GetInt("Combat" + combatNumber + "XP");
                                combatXP1.GetComponent<Text>().text = XP.ToString();
                                PlayerPrefs.SetString("Combat" + combatNumber + "Coordinates", x.ToString() + y.ToString());
                                PlayerPrefs.SetString("Grid-X-" + x + "-Y-" + y, "Combat" + combatNumber);
                            }
                            break;
                        case 'M':
                            tilemap.SetTile(new Vector3Int(x, y, 0), miniboss);
                            GameObject minibossXP1 = Instantiate(combatXP, position, Quaternion.identity, combatXP.transform.parent);
                            minibossXP1.name = "MinibossXP";
                            XP = PlayerPrefs.GetInt("Miniboss-XP");
                            minibossXP1.GetComponent<Text>().text = XP.ToString();
                            break;
                        case 'B':
                            tilemap.SetTile(new Vector3Int(x, y, 0), miniboss);
                            GameObject bossXP1 = Instantiate(combatXP, position, Quaternion.identity, combatXP.transform.parent);
                            bossXP1.name = "BossXP";
                            XP = PlayerPrefs.GetInt("Boss-XP");
                            bossXP1.GetComponent<Text>().text = XP.ToString();
                            break;
                        case 'S':
                            tilemap.SetTile(new Vector3Int(x, y, 0), shop);
                            break;
                        case 'G':
                            tilemap.SetTile(new Vector3Int(x, y, 0), gambler);
                            break;
                        case 'E':
                            if (tileName[1] == 's') { tilemap.SetTile(new Vector3Int(x, y, 0), essence); }
                            break;
                        case 'H':
                            tilemap.SetTile(new Vector3Int(x, y, 0), home);
                            break;
                    }
                }
            }
        }
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

    private Vector3Int GridRightUp(Vector3Int tilePosition)
    {
        Vector3 position = tilemap.CellToWorld(tilePosition);
        position += new Vector3(15, 23, 0);
        tilePosition = tilemap.WorldToCell(position);
        return tilePosition;
    }

    private Vector3Int GridRightDown(Vector3Int tilePosition)
    {
        Vector3 position = tilemap.CellToWorld(tilePosition);
        position += new Vector3(15, -23, 0);
        tilePosition = tilemap.WorldToCell(position);
        return tilePosition;
    }

    private Vector3Int GridRight(Vector3Int tilePosition)
    {
        Vector3 position = tilemap.CellToWorld(tilePosition);
        position += new Vector3(30, 0, 0);
        tilePosition = tilemap.WorldToCell(position);
        return tilePosition;
    }

    private void CharacterStats()
    {
        for (int x = 1; x <= 4; x++)
        {
            Vector3 position = GameObject.Find("Character" + x).transform.localPosition;
            if (PlayerPrefs.GetString("P" + x + "-Name") != "null")
            {
                string characterName = PlayerPrefs.GetString("P" + x + "-Name");
                LoadSprite.FindSprite(GameObject.Find("Character" + x), characterName + "Head");
                int currentHP = PlayerPrefs.GetInt("P" + x + "-CHP");
                int maxHP = PlayerPrefs.GetInt("P" + x + "-HP");
                int currentSP = PlayerPrefs.GetInt("P" + x + "-CSP");
                int maxSP = PlayerPrefs.GetInt("P" + x + "-SP");
                float percentHP = currentHP / maxHP;
                float percentSP = currentSP / maxSP;
                GameObject.Find("Character" + x + "HP").transform.localScale = new Vector3(percentHP, 1, 1);
                GameObject.Find("Character" + x + "SP").transform.localScale = new Vector3(percentSP, 1, 1);
                GameObject.Find("Character" + x).transform.localPosition = new Vector3(position.x, position.y, -2);
            }
            else
            {
                GameObject.Find("Character" + x).transform.localPosition = new Vector3(position.x, position.y, 2);
            }
        }
    }
}
