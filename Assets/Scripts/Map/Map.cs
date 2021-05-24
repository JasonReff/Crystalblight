using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<MapTile> mapTiles;

    public Map()
    {
        int leftmostTile = 1;
        int rightmostTile = 10;
        int lowermostTile = -10;
        int uppermostTile = 10;
        for (int x = leftmostTile; x <= rightmostTile; x++)
        {
            for (int y = lowermostTile; y <= uppermostTile; y++)
            {
                MapTile mapTile = new MapTile(x, y);
            }
        }
    }
}
