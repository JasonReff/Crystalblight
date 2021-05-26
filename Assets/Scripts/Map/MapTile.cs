using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{

    public int[] mapCoordinates;
    public Encounter encounter;
    public bool visited;

    public static MapTile RandomMapTile(int x, int y)
    {
        MapTile mapTile = new MapTile();
        mapTile.mapCoordinates = new int[] { x, y };
        Encounter newEncounter = GenerateRandomEncounter(mapTile.mapCoordinates);
        mapTile.encounter = newEncounter;
        return mapTile;
    }

    public static Encounter GenerateRandomEncounter(int [] mapCoordinates)
    {
        Encounter encounter = new Encounter();
        int encounterType = UnityEngine.Random.Range(1, 3); //add in gambler and essence source
        switch (encounterType)
        {
            case 1:
                encounter = new CombatEncounter(mapCoordinates);
                break;
            case 2: encounter = new ShopEncounter();
                break;
        }
        return encounter;
    }

    public List<MapTile> AdjacentTiles(Map map, MapTile mapTile)
    {
        int x = mapTile.mapCoordinates[0];
        int y = mapTile.mapCoordinates[1];
        MapTile leftTile = LeftTile(map, x, y);
        MapTile upperLeftTile = UpperLeftTile(map, x, y);
        MapTile lowerLeftTile = LowerLeftTile(map, x, y);
        MapTile rightTile = RightTile(map, x, y);
        MapTile upperRightTile = UpperRightTile(map, x, y);
        MapTile lowerRightTile = LowerRightTile(map, x, y);
        List <MapTile> adjacentTiles = new List<MapTile> { leftTile, upperLeftTile, lowerLeftTile, rightTile, upperRightTile, lowerRightTile };
        return adjacentTiles;
    }

    public List<Encounter> AdjacentEncounters(Map map)
    {
        List<MapTile> adjacentTiles = AdjacentTiles(map, this);
        List<Encounter> adjacentEncounters = new List<Encounter> { };
        foreach (MapTile mapTile in adjacentTiles)
        {
            Encounter encounter = mapTile.encounter;
            adjacentEncounters.Add(encounter);
        }
        return adjacentEncounters;
    }

    public List<MapTile> LeftTiles(Map map, MapTile mapTile)
    {
        int x = mapTile.mapCoordinates[0];
        int y = mapTile.mapCoordinates[1];
        MapTile leftTile = LeftTile(map, x, y);
        MapTile upperLeftTile = UpperLeftTile(map, x, y);
        MapTile lowerLeftTile = LowerLeftTile(map, x, y);
        List<MapTile> leftTiles = new List<MapTile> { leftTile, upperLeftTile, lowerLeftTile};
        return leftTiles;
    }

    public List<MapTile> RightTiles(Map map, MapTile mapTile)
    {
        int x = mapTile.mapCoordinates[0];
        int y = mapTile.mapCoordinates[1];
        MapTile rightTile = RightTile(map, x, y);
        MapTile upperRightTile = UpperRightTile(map, x, y);
        MapTile lowerRightTile = LowerRightTile(map, x, y);
        List<MapTile> rightTiles = new List<MapTile> { rightTile, upperRightTile, lowerRightTile };
        return rightTiles;
    }

    public MapTile LeftTile(Map map, int x, int y)
    {
        MapTile leftTile = map.mapTiles.Find(tile => tile.mapCoordinates == new int[] { x - 1, y });
        return leftTile;
    }

    public MapTile UpperLeftTile(Map map, int x, int y)
    {
        MapTile upperLeftTile = map.mapTiles.Find(tile => tile.mapCoordinates == new int[] { x - 1, y + 1 });
        return upperLeftTile;
    }

    public MapTile LowerLeftTile(Map map, int x, int y)
    {
        MapTile lowerLeftTile = map.mapTiles.Find(tile => tile.mapCoordinates == new int[] { x - 1, y - 1 });
        return lowerLeftTile;
    }

    public MapTile RightTile(Map map, int x, int y)
    {
        MapTile rightTile = map.mapTiles.Find(tile => tile.mapCoordinates == new int[] { x + 1, y });
        return rightTile;
    }

    public MapTile UpperRightTile(Map map, int x, int y)
    {
        MapTile upperRightTile = map.mapTiles.Find(tile => tile.mapCoordinates == new int[] { x + 1, y + 1 });
        return upperRightTile;
    }

    public MapTile LowerRightTile(Map map, int x, int y)
    {
        MapTile lowerRightTile = map.mapTiles.Find(tile => tile.mapCoordinates == new int[] { x - 1, y + 1 });
        return lowerRightTile;
    }

    public bool DoesAdjacentLeftTileExist(Map map)
    {
        List<MapTile> leftTiles = LeftTiles(map, this);
        if (leftTiles.Find(x => x.encounter != null) != null)
        {
            return true;
        }
        else return false;
    }

    public bool DoesAdjacentRightTileExist(Map map)
    {
        List<MapTile> rightTiles = RightTiles(map, this);
        if (rightTiles.Find(x => x.encounter != null) != null)
        {
            return true;
        }
        else return false;
    }
}
