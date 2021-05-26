using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public List<MapTile> mapTiles;
    public Tilemap tilemap;
    public Tile emptyTile;
    public Tile homeTile;
    public Tile characterTile;
    public Tile combatTile;
    public Tile shopTile;
    public Tile gamblerTile;
    public Tile essenceTile;

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
                MapTile mapTile = MapTile.RandomMapTile(x, y);
            }
        }
        foreach (MapTile mapTile in mapTiles)
        {
            LeftMapTilesEmpty(this, mapTile);
        }
    }



    public void LeftMapTilesEmpty(Map map, MapTile mapTile)
    {
        List<MapTile> leftTiles = mapTile.LeftTiles(map, mapTile);
        if (leftTiles.Find(x => x.encounter != null) == null)
        {
            mapTile.encounter = null;
        }
    }

    public void FillFixedEncounters(Map map)
    {
        foreach(MapTile mapTile in map.mapTiles)
        {
            Vector3Int tileMapCoordinates = new Vector3Int(mapTile.mapCoordinates[0], mapTile.mapCoordinates[1], 0);
            switch (mapTile.encounter.encounterType)
            {
                case Encounter.EncounterType.Home:
                    tilemap.SetTile(tileMapCoordinates, homeTile);
                    break;
                case Encounter.EncounterType.Character:
                    tilemap.SetTile(tileMapCoordinates, characterTile);
                    break;
            }
        }
    }

    public void CreateHomeTile(Map map)
    {
        int[] homeCoordinates = new int[] { -10, 0 };
        MapTile home = map.mapTiles.Find(x => x.mapCoordinates == homeCoordinates);
        home.encounter.encounterType = Encounter.EncounterType.Home;
    }

    public void FillVariableEncounters(Map map)
    {
        foreach (MapTile mapTile in map.mapTiles)
        {
            switch (mapTile.encounter.encounterType)
            {
                case Encounter.EncounterType.Combat:
                    break;

            }
        }
    }
}
