using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gengame : MonoBehaviour
{
    public EnemyAllocation enemyAllocation;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        int seed = PlayerPrefs.GetInt("seed");
        UnityEngine.Random.seed = seed;
        int enc1 = UnityEngine.Random.Range(0, 100);
        List<int> used = new List<int>();
        used.Add(enc1);
        PlayerPrefs.SetInt("enc1", enc1);
        int enc2 = UnityEngine.Random.Range(0, 100);
        while (used.Contains(enc2))
        {
            enc2 = UnityEngine.Random.Range(0, 100);
        }
        PlayerPrefs.SetInt("enc2", enc2);
        PlayerPrefs.SetString("P2-Name", "null");
        PlayerPrefs.SetString("P3-Name", "null");
        PlayerPrefs.SetString("P4-Name", "null");
        PlayerPrefs.SetInt("P1-TurnTaken", 0);
        PlayerPrefs.SetInt("P2-TurnTaken", 0);
        PlayerPrefs.SetInt("P3-TurnTaken", 0);
        PlayerPrefs.SetInt("P4-TurnTaken", 0);
        PlayerPrefs.SetInt("Turns", 0);
        PlayerPrefs.SetInt("E1-Set", 0);
        PlayerPrefs.SetInt("E2-Set", 0);
        PlayerPrefs.SetInt("E3-Set", 0);
        PlayerPrefs.SetInt("E4-Set", 0);
        PlayerPrefs.SetInt("E5-Set", 0);
        PlayerPrefs.SetInt("E6-Set", 0);
        PlayerPrefs.SetInt("E7-Set", 0);
        PlayerPrefs.SetInt("E8-Set", 0);
        PlayerPrefs.SetInt("E9-Set", 0);
        PlayerPrefs.SetInt("CurrentShards", 90);
        PlayerPrefs.SetString("CurrentTile", "Home");
        PlayerPrefs.SetInt("CurrentTileX", -10);
        PlayerPrefs.SetInt("CurrentTileY", 0);
        PlayerPrefs.SetInt("MapGenerated", 0);
        PlayerPrefs.SetInt("CombatSet", 0);
        PlayerPrefs.SetInt("P2-Selected", 0);
        int stage1 = 2; //UnityEngine.Random.Range(1, 7);
        switch (stage1)
        {
            case 1: PlayerPrefs.SetString("Stage1", "Abandoned Dungeon");
                break;
            case 2: PlayerPrefs.SetString("Stage1", "Shifting Sands");
                break;
            case 3: PlayerPrefs.SetString("Stage1", "The Ascension");
                break;
            case 4: PlayerPrefs.SetString("Stage1", "Courtyard");
                break;
            case 5: PlayerPrefs.SetString("Stage1", "Parish");
                break;
            case 6: PlayerPrefs.SetString("Stage1", "Outskirts");
                break;
        }
        int stage1Seed = UnityEngine.Random.Range(0, 99999999);
        PlayerPrefs.SetInt("Stage1Seed", stage1Seed);
        int stage2 = 0;
        do
        {
            stage2 = 1; //UnityEngine.Random.Range(1, 7);
        }
        while (stage2 == stage1);
        switch (stage2)
        {
            case 1: PlayerPrefs.SetString("Stage2", "Ramparts");
                break;
            case 2: PlayerPrefs.SetString("Stage2", "Glass Ocean");
                break;
            case 3: PlayerPrefs.SetString("Stage2", "The Labyrinth");
                break;
            case 4: PlayerPrefs.SetString("Stage2", "Stomach");
                break;
            case 5: PlayerPrefs.SetString("Stage2", "Plague Ward");
                break;
            case 6: PlayerPrefs.SetString("Stage2", "Nest");
                break;
        }
        int stage2Seed = UnityEngine.Random.Range(0, 99999999);
        PlayerPrefs.SetInt("Stage2Seed", stage2Seed);
        int stage3 = 0;
        do
        {
            stage3 = 3; //UnityEngine.Random.Range(1, 7);
        }
        while (stage3 == stage2 || stage3 == stage1);
        switch (stage3)
        {
            case 1: PlayerPrefs.SetString("Stage3", "Throne Room");
                break;
            case 2: PlayerPrefs.SetString("Stage3", "Sunken Tomb");
                break;
            case 3: PlayerPrefs.SetString("Stage3", "The Archives");
                break;
            case 4: PlayerPrefs.SetString("Stage3", "The Eye");
                break;
            case 5: PlayerPrefs.SetString("Stage3", "Inferno");
                break;
            case 6: PlayerPrefs.SetString("Stage3", "Veridian Lake");
                break;
        }
        int stage3Seed = UnityEngine.Random.Range(0, 99999999);
        PlayerPrefs.SetInt("Stage3Seed", stage3Seed);
        PlayerPrefs.SetString("CurrentStage", PlayerPrefs.GetString("Stage1"));
        for (int x = 1; x <= 10; x++)
        {
            PlayerPrefs.SetString("InventoryItem" + x, "null");
            PlayerPrefs.SetString("InventoryRune" + x, "null");
            PlayerPrefs.SetString("InventoryVeil" + x, "null");
            PlayerPrefs.SetString("InventorySigil" + x, "null");
        }
        for (int x = 1; x <= 6; x++)
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("Item" + x + "Name") + "Count", 0);
            PlayerPrefs.SetInt(PlayerPrefs.GetString("Rune" + x + "Name") + "Count", 0);
            PlayerPrefs.SetInt(PlayerPrefs.GetString("Sigil" + x + "Name") + "Count", 0);
            PlayerPrefs.SetInt(PlayerPrefs.GetString("Veil" + x + "Name") + "Count", 0);
        }
    }
}
