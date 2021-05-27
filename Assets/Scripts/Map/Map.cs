using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
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
    public Tile bossTile;
    public Tile minibossTile;

    public int leftmostTile = 1;
    public int rightmostTile = 10;
    public int lowermostTile = -10;
    public int uppermostTile = 10;

    public Map()
    {
        CreateVariableEncounters(this);
        CreateFixedEncounters(this);
        CreateEmptySpaceInPath();
        foreach (MapTile mapTile in mapTiles)
        {
            LeftMapTilesEmpty(this, mapTile);
        }
    }

    public void FillTilemap(Map map)
    {
        FillFixedEncounters(map);
        FillVariableEncounters(map);
    }

    public void CreateFixedEncounters(Map map)
    {
        CreateHomeTile(map);
        CreateCharacterTiles(map);
        CreateBossTile(map);
        CreateMinibossTile(map);
    }

    public void CreateVariableEncounters(Map map)
    {
        for (int x = leftmostTile; x <= rightmostTile; x++)
        {
            for (int y = lowermostTile; y <= uppermostTile; y++)
            {
                MapTile mapTile = MapTile.RandomMapTile(x, y);
                map.mapTiles.Add(mapTile);
            }
        }
    }

    public void LeftMapTilesEmpty(Map map, MapTile mapTile)
    {
        switch (mapTile.encounter.encounterType)
        {
            case Encounter.EncounterType.Home:
            case Encounter.EncounterType.Character:
            case Encounter.EncounterType.Boss:
            case Encounter.EncounterType.Miniboss:
                return;
        }
        if (mapTile.DoesAdjacentLeftTileExist(this) == false)
        {
            mapTile.encounter = null;
        }
    }

    public void FillFixedEncounters(Map map)
    {
        foreach (MapTile mapTile in map.mapTiles)
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
                case Encounter.EncounterType.Boss:
                    tilemap.SetTile(tileMapCoordinates, bossTile);
                    break;
                case Encounter.EncounterType.Miniboss:
                    tilemap.SetTile(tileMapCoordinates, minibossTile);
                    break;
            }
        }
    }

    public void CreateHomeTile(Map map)
    {
        int[] homeCoordinates = new int[] { -10, 0 };
        MapTile home = map.mapTiles.Find(x => x.mapCoordinates == homeCoordinates);
        Encounter homeEncounter = new Encounter();
        homeEncounter.encounterType = Encounter.EncounterType.Home;
        home.encounter = homeEncounter;
    }

    public void CreateCharacterTiles(Map map)
    {
        int[] characterACoordinates = new int[] { -10, 1 };
        MapTile characterATile = map.mapTiles.Find(x => x.mapCoordinates == characterACoordinates);
        Encounter characterAEncounter = new Encounter();
        characterAEncounter.encounterType = Encounter.EncounterType.Character;
        characterATile.encounter = characterAEncounter;
        int[] characterBCoordinates = new int[] { -10, -1 };
        MapTile characterBTile = map.mapTiles.Find(x => x.mapCoordinates == characterBCoordinates);
        Encounter characterBEncounter = new Encounter();
        characterBEncounter.encounterType = Encounter.EncounterType.Character;
        characterBTile.encounter = characterBEncounter;
    }

    public void CreateMinibossTile(Map map)
    {
        int[] minibossCoordinates = new int[] { 0, 0 };
        MapTile miniboss = map.mapTiles.Find(x => x.mapCoordinates == minibossCoordinates);
        Encounter minibossEncounter = new MinibossEncounter();
        miniboss.encounter = minibossEncounter;
    }

    public void CreateBossTile(Map map)
    {
        int[] bossCoordinates = new int[] { 10, 0 };
        MapTile boss = map.mapTiles.Find(x => x.mapCoordinates == bossCoordinates);
        Encounter bossEncounter = new BossEncounter();
        boss.encounter = bossEncounter;
    }

    public void FillVariableEncounters(Map map)
    {
        foreach (MapTile mapTile in map.mapTiles)
        {
            Vector3Int tileMapCoordinates = new Vector3Int(mapTile.mapCoordinates[0], mapTile.mapCoordinates[1], 0);
            switch (mapTile.encounter.encounterType)
            {

                case Encounter.EncounterType.Combat:
                    tilemap.SetTile(tileMapCoordinates, combatTile);
                    break;

            }
        }
    }

    public void CreateEmptySpaceInPath()
    {
        foreach (MapTile mapTile in mapTiles)
        {
            CreateEmptySpaceAdjacentToEmptySpace(mapTile);
            CreateEmptySpaceSurroundedByFilledSpaces(mapTile);
        }
    }

    public void CreateEmptySpaceSurroundedByFilledSpaces(MapTile mapTile)
    {
        switch (mapTile.encounter.encounterType)
        {
            case Encounter.EncounterType.Home:
            case Encounter.EncounterType.Character:
            case Encounter.EncounterType.Boss:
            case Encounter.EncounterType.Miniboss:
                return;
        }
        List<MapTile> adjacentTiles = mapTile.AdjacentTiles(this, mapTile);
        if (adjacentTiles.Find(x => x.encounter == null) != null)
        {
            mapTile.encounter = null;
        }
    }

    public void CreateEmptySpaceAdjacentToEmptySpace(MapTile mapTile)
    {
        switch (mapTile.encounter.encounterType)
        {
            case Encounter.EncounterType.Home:
            case Encounter.EncounterType.Character:
            case Encounter.EncounterType.Boss:
            case Encounter.EncounterType.Miniboss:
                return;
        }
        if (mapTile.DoesAdjacentLeftTileExist(this) == false || mapTile.DoesAdjacentRightTileExist(this) == false)
        {
            mapTile.encounter = null;
        }
    }
}
