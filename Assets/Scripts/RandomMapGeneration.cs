using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

public class RandomMapGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int pathNumber = 1; pathNumber <= 8; pathNumber ++)
        {
            for (int encounterNumber = 1; encounterNumber <= 5; encounterNumber++)
            {
                PlayerPrefs.SetInt("Path-" + (pathNumber + 1) + "-Encounter-" + encounterNumber + "-X-Path-" + pathNumber + "-Encounter-" + (encounterNumber + 1), 0);
                PlayerPrefs.SetInt("Path-" + (pathNumber) + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1), 0);
            }
        }
        MapSet();
        IconSet();
        PathSet();
    }

    public void MapSet()
    {
        for (int pathNumber = 1; pathNumber <= 8; pathNumber ++)
            { 
            string[] icons = { "combat1", "combat2", "shop1", "random1", "random2" };
            int random1 = UnityEngine.Random.Range(1, 5);
            int random2 = UnityEngine.Random.Range(1, 5);
            switch (random1) 
            {
                case 1:
                    {
                        icons[3] = "combat3";
                        break;
                    }
                case 2:
                    {
                        icons[3] = "shop2";
                        break;
                    }
                case 3:
                    {
                        icons[3] = "gambler1";
                        break;
                    }
                case 4:
                    {
                        icons[3] = "essence1";
                        break;
                    }
            }
            switch (random2)
            {
                case 1:
                    {
                        icons[4] = "combat3";
                        if (icons[3] == "combat3") { icons[4] = "combat4"; }
                        break;
                    }
                case 2:
                    {
                        icons[4] = "shop2";
                        if (icons[3] == "shop2") { icons[4] = "shop3"; }
                        break;
                    }
                case 3:
                    {
                        icons[4] = "gambler1";
                        if (icons[3] == "gambler1") { icons[4] = "gambler2"; }
                        break;
                    }
                case 4:
                    {
                        icons[4] = "essence1";
                        if (icons[3] == "essence1") { icons[4] = "essence2"; }
                        break;
                    }
            }
            int[] used = { 0, 0, 0, 0, 0};
            int j;
            string[] iconUsed = { "", "", "", "", "" };
            for (int i = 0; i <= 4; i++)
            {
                j = UnityEngine.Random.Range(1, 6);
                if (used.Contains(j) || iconUsed.Contains(icons[i]))
                {
                    i--;
                    continue;
                }
                used[i] = j;
                iconUsed[i] = icons[i];
                PlayerPrefs.SetString("Map-Path-" + pathNumber + "-Encounter-" + j, "Path-" + pathNumber + icons[i]);
            }
        }
    }

    void IconSet()
    {
        for (int pathNumber = 1; pathNumber <= 4; pathNumber ++)
        {
            for (int encounterNumber = 1; encounterNumber <= 5; encounterNumber ++)
            {
                string encounterSubstring = PlayerPrefs.GetString("Map-Path-" + pathNumber + "-Encounter-" + encounterNumber).Substring(6);
                string encounterName =
                    encounterSubstring.Remove(encounterSubstring.Length - 1, 1);
                LoadSprite.FindSprite(GameObject.Find("Map-Path-" + pathNumber + "-Encounter-" + encounterNumber), encounterName);
            }
        }
    }

    void PathSet()
    {
        for (int pathNumber = 1; pathNumber <= 4; pathNumber++)
        {
            for (int encounterNumber = 1; encounterNumber <= 4; encounterNumber ++)
            {
                if (pathNumber == 1 || pathNumber == 6)
                {
                    int random = UnityEngine.Random.Range(1,5);
                    if (random == 1 || random == 2)
                    {
                        if (PlayerPrefs.GetInt("Path-" + (pathNumber + 1) + "-Encounter-" + encounterNumber + "-X-Path-" + pathNumber + "-Encounter-" + (encounterNumber + 1)) == 1)
                        {

                        }
                        else
                        {
                            PlayerPrefs.SetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1), 1);
                            GameObject mapObject = GameObject.Find("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1));
                            mapObject.transform.localPosition += new Vector3(0, 0, -2);
                        }
                    }
                }
                if (pathNumber == 2 || pathNumber == 3 || pathNumber == 6 || pathNumber == 7)
                {
                    int random = UnityEngine.Random.Range(1, 5);
                    if (random == 1)
                    {
                        if (PlayerPrefs.GetInt("Path-" + (pathNumber + 1) + "-Encounter-" + encounterNumber + "-X-Path-" + pathNumber + "-Encounter-" + (encounterNumber + 1)) == 1)
                        {

                        }
                        else
                        {
                            PlayerPrefs.SetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1), 1);
                            GameObject mapObject = GameObject.Find("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber + 1) + "-Encounter-" + (encounterNumber + 1));
                            mapObject.transform.localPosition += new Vector3(0, 0, -2);
                        }
                    }
                    if (random == 2)
                    {
                        if (PlayerPrefs.GetInt("Path-" + (pathNumber - 1) + "-Encounter-" + encounterNumber + "-X-Path-" + pathNumber + "-Encounter-" + (encounterNumber + 1)) == 1)
                        {

                        }
                        else 
                        { 
                            PlayerPrefs.SetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1), 1);
                            GameObject mapObject = GameObject.Find("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1));
                            mapObject.transform.localPosition += new Vector3(0, 0, -2);
                        }
                    }
                }
                if (pathNumber == 4 || pathNumber == 8)
                {
                    int random = UnityEngine.Random.Range(1, 5);
                    if (random == 1 || random == 2)
                    {
                        if (PlayerPrefs.GetInt("Path-" + (pathNumber - 1) + "-Encounter-" + encounterNumber + "-X-Path-" + pathNumber + "-Encounter-" + (encounterNumber + 1)) == 1)
                        {

                        }
                        else
                        {
                            PlayerPrefs.SetInt("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1), 1);
                            GameObject mapObject = GameObject.Find("Path-" + pathNumber + "-Encounter-" + encounterNumber + "-X-Path-" + (pathNumber - 1) + "-Encounter-" + (encounterNumber + 1));
                            mapObject.transform.localPosition += new Vector3(0, 0, -2);
                        }
                    }
                }
            }
        }
    }
}
