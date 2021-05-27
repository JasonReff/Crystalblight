using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGame : MonoBehaviour
{
    public PlayerData playerData;

    public void OnMouseDown()
    {
        GenerateSeed();
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

    public void GenerateMap()
    {
        Map map = new Map();
        playerData.map = map;
    }
}
