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
        //add more when those exist
        GameObject P1Hp = GameObject.Find("P1-Hp");
        GameObject P1G = GameObject.Find("P1-Guard");
        GameObject P2Hp = GameObject.Find("P2-Hp");
        GameObject P2G = GameObject.Find("P2-Guard");
        GameObject E1Hp = GameObject.Find("E1-Hp");
        GameObject E1G = GameObject.Find("E1-Guard");
        GameObject P1Sp = GameObject.Find("P1-Sp");
        GameObject E1Status1 = GameObject.Find("E1Status1");
        GameObject P2Sp = GameObject.Find("P2-Sp");
        GameObject E2Hp = GameObject.Find("E2-Hp");
        GameObject E2G = GameObject.Find("E2-Guard");
        GameObject E2Status1 = GameObject.Find("E2Status1");
        float Percent = ((float)PlayerPrefs.GetInt("P1-CHP") / (float)PlayerPrefs.GetInt("P1-HP"));
        P1Hp.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("P1-CSP") / (float)PlayerPrefs.GetInt("P1-SP"));
        P1Sp.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("P1-CG") / (float)PlayerPrefs.GetInt("P1-Guard"));
        P1G.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("P2-CHP") / (float)PlayerPrefs.GetInt("P2-HP"));
        P2Hp.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("P2-CSP") / (float)PlayerPrefs.GetInt("P2-SP"));
        P2Sp.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("P2-CG") / (float)PlayerPrefs.GetInt("P2-Guard"));
        P2G.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("E1-CHP") / (float)PlayerPrefs.GetInt("E1-HP"));
        E1Hp.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        Percent = ((float)PlayerPrefs.GetInt("E1-CG") / (float)PlayerPrefs.GetInt("E1-Guard"));
        E1G.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        //Percent = ((float)PlayerPrefs.GetInt("E2-CHP") / (float)PlayerPrefs.GetInt("E2-HP"));
        //E2Hp.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        //Percent = ((float)PlayerPrefs.GetInt("E2-CG") / (float)PlayerPrefs.GetInt("E2-Guard"));
        //E2G.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
    }
}
