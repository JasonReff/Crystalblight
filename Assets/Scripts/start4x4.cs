using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class start4x4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("setup", 1);
        LoadSprite.FindSprite(GameObject.Find("background"), PlayerPrefs.GetString("CurrentStage"));
        string music = "";
        if (PlayerPrefs.GetString("CurrentTile")[0] == 'B')
        {
            if (new string[] { "Abandoned Dungeon", "Ramparts", "Throne Room" }.Contains(PlayerPrefs.GetString("CurrentStage"))) 
            {
                music = "Ivory Palace Boss Music";
            }
            else if (new string[] { "Shifting Sands", "Glass Ocean", "Sunken Tomb"}.Contains(PlayerPrefs.GetString("CurrentStage")))
            {
                music = "Malvow Desert Boss Music";
            }
            else if (new string[] { "The Ascension", "The Labyrinth", "The Archives" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            {
                music = "Tower of Kalor Boss Music";
            }
            else if (new string[] { "Courtyard", "Stomach", "The Eye" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            {
                music = "Clockwork Manor Boss Music";
            }
            else if (new string[] { "Parish", "Plague Ward", "Inferno" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            {
                music = "Brimstone Village Boss Music";
            }
            else if (new string[] { "Outskirts", "Nest", "Veridian Lake" }.Contains(PlayerPrefs.GetString("CurrentStage")))
            {
                music = "Barkskin Forest Boss Music";
            }
        }
        else
        {
            music = PlayerPrefs.GetString("CurrentStage") + "Music";
        }
        GameObject.Find("music").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(music);
        GameObject.Find("music").GetComponent<AudioSource>().Play();
        //makes all blocks moveable
        for (int i = 1; i <= 25; i++)
        {
            PlayerPrefs.SetInt("Block-" + i + "-Moveable", 1);
        }
        PlayerPrefs.SetInt("P1-CanMove", 1);
        PlayerPrefs.SetInt("P2-CanMove", 1);
        PlayerPrefs.SetInt("P3-CanMove", 1);
        PlayerPrefs.SetInt("P4-CanMove", 1);
        PlayerPrefs.SetInt("P1-Clicked", 1);
        PlayerPrefs.SetInt("P1-TurnTaken", 0);
        PlayerPrefs.SetInt("P2-TurnTaken", 0);
        PlayerPrefs.SetInt("P3-TurnTaken", 0);
        PlayerPrefs.SetInt("P4-TurnTaken", 0);
        PlayerPrefs.SetInt("Turns", 0);
        PlayerPrefs.SetInt("Processing", 0);
    }
}
