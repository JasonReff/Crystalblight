using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public int seed;
    public Stage currentStage;
    public List<Character> characters;
    public List<CombatEncounter> combatEncounters;
    public Dictionary<Item, int> itemsInInventory;
    private static PlayerData instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
