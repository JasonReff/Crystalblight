using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FillTilemapOnStart : MonoBehaviour
{
    public Map map;
    public PlayerData playerData;

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

    public void Start()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        map = playerData.map;
        FillTilemap(map);
    }

    public void FillTilemap(Map map)
    {
        FillFixedEncounters(map);
        FillVariableEncounters(map);
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
                case Encounter.EncounterType.Merchant:
                    tilemap.SetTile(tileMapCoordinates, shopTile);
                    break;
                case Encounter.EncounterType.Gambler:
                    tilemap.SetTile(tileMapCoordinates, gamblerTile);
                    break;
                case Encounter.EncounterType.EssenceSource:
                    tilemap.SetTile(tileMapCoordinates, essenceTile);
                    break;

            }
        }
    }
}
