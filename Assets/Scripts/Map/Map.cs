using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map : MonoBehaviour
{
    public List<MapTile> mapTiles;

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
