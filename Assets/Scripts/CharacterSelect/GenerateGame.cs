using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateGame : MonoBehaviour
{
    public PlayerData playerData;

    public void StartGame()
    {
        GenerateSeed();
        GenerateStages();
        GenerateMap();
    }

    public int GenerateSeed()
    {
        int time = (int)System.DateTime.Now.Ticks;
        Random.InitState(time);
        int seed = UnityEngine.Random.Range(0, 99999999);
        Random.InitState(seed);
        return seed;
    }

    public void GenerateStages()
    {
        Stage stage = new Dungeon();
        playerData.currentStage = stage;
    }

    public void GenerateMap()
    {
        Map map = new Map();
        playerData.map = map;
    }

    public void GoToMap()
    {
        SceneManager.LoadScene("Map");
    }
}
