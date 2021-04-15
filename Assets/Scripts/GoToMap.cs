using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMap : MonoBehaviour
{
    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("RewardDisplayOn", 0);
        PlayerPrefs.SetInt("ShardReward", 0);
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        string currentStage = PlayerPrefs.GetString("CurrentStage");
        string tile = PlayerPrefs.GetString("CurrentTile");
        if (tile[0] == 'B')
        {
            if (currentStage == "Abandoned Dungeon" || currentStage == "Shifting Sands" || currentStage == "The Ascension" || currentStage == "Courtyard" || currentStage == "Parish" || currentStage == "Outskirts")
            {
                PlayerPrefs.SetString("CurrentStage", PlayerPrefs.GetString("Stage2"));
            }
            else if (currentStage == "Ramparts" || currentStage == "Glass Ocean" || currentStage == "The Labyrinth" || currentStage == "Stomach" || currentStage == "Plague Ward" || currentStage == "Nest")
            {
                PlayerPrefs.SetString("CurrentStage", PlayerPrefs.GetString("Stage3"));
            }
            else if (new string[] {"Throne Room", "Sunken Tomb", "The Archives", "The Eye", "Inferno", "Veridian Lake"}.Contains(currentStage))
            {
                PlayerPrefs.SetString("CurrentStage", PlayerPrefs.GetString("Stage4"));
            }
            PlayerPrefs.SetString("CurrentTile", "Home");
            PlayerPrefs.SetInt("CurrentTileX", -10);
            PlayerPrefs.SetInt("CurrentTileY", 0);
            PlayerPrefs.SetInt("MapGenerated", 0);
            PlayerPrefs.SetInt("CombatSet", 0);
        }
        SceneManager.LoadScene("Map- Hexagon");
    }
}
