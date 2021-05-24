using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{

    public int[] mapCoordinates;
    public Encounter encounter;
    public bool visited;

    public MapTile(int x, int y)
    {
        mapCoordinates = new int[] { x, y };
        Encounter newEncounter = GenerateEncounter();
        newEncounter.mapLocation = mapCoordinates;
    }

    public Encounter GenerateEncounter()
    {
        Encounter encounter = new Encounter();
        int encounterType = UnityEngine.Random.Range(1, 3); //add in gambler and essence source
        switch (encounterType)
        {
            case 1:
                encounter = new CombatEncounter(mapCoordinates[0]);
                break;
            case 2: encounter = new ShopEncounter();
                break;
        }
        return encounter;
    }
}
