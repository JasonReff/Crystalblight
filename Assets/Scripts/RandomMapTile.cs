using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapTile : MonoBehaviour
{
    void Start()
    {
        GameObject lastTile = GameObject.Find(PlayerPrefs.GetString("CurrentTile"));
        GameObject.Find("Previous-Space").transform.localPosition = lastTile.transform.localPosition;
    }

    private void OnMouseDown()
    {
        string encounterName = PlayerPrefs.GetString(this.name);
        int encounterNumber = Int32.Parse(this.name.Substring(this.name.Length - 1));
        int pathNumber = Int32.Parse(this.name[5].ToString());
        if (encounterName.Substring(6).Remove(encounterName.Substring(6).Length - 1, 1) == "combat")
        {
            PlayerPrefs.SetString("CurrentTile", this.name);
            NextEncounter(encounterNumber, pathNumber);
        }
        if (encounterName.Substring(6).Remove(encounterName.Substring(6).Length - 1, 1) == "gambler")
        {
            PlayerPrefs.SetString("CurrentTile", this.name);
            NextEncounter(encounterNumber, pathNumber);
        }
        if (encounterName.Substring(6).Remove(encounterName.Substring(6).Length - 1, 1) == "essence")
        {
            PlayerPrefs.SetString("CurrentTile", this.name);
            NextEncounter(encounterNumber, pathNumber);
        }
        if (encounterName.Substring(6).Remove(encounterName.Substring(6).Length - 1, 1) == "shop")
        {
            PlayerPrefs.SetString("CurrentTile", this.name);
            NextEncounter(encounterNumber, pathNumber);
        }
    }

    private void OnMouseEnter()
    {
        
        if (PlayerPrefs.GetString("NextEncounterNumber") == this.name.Substring(this.name.Length - 1)) 
        {
        }
        else
        {
            GameObject.Find("TileDiss").transform.localPosition = this.transform.localPosition;
        }
    }

    private void NextEncounter(int encounterNumber, int pathNumber)
    {
        if (pathNumber == 1 || pathNumber == 5)
        {
            if (PlayerPrefs.GetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1)) == 1)
            {
                PlayerPrefs.SetString("NextEncounterNumber2", "Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1));
            }
        }
        if (pathNumber == 2 || pathNumber == 3 || pathNumber == 6 || pathNumber == 7)
        {
            if (PlayerPrefs.GetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1)) == 1)
            {
                PlayerPrefs.SetString("NextEncounterNumber2", "Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1));
            }
            if (PlayerPrefs.GetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1)) == 1)
            {
                PlayerPrefs.SetString("NextEncounterNumber3", "Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1));
            }
        }
        if (pathNumber == 4 || pathNumber == 8)
        {
            if (PlayerPrefs.GetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1)) == 1)
            {
                PlayerPrefs.SetString("NextEncounterNumber3", "Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1));
            }
        }
    }
}
