using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Encounter : MonoBehaviour
{
    public int[] mapLocation;
    public EncounterType encounterType;
    public enum EncounterType
    {
        Home,
        Character,
        Combat,
        Merchant,
        EssenceSource,
        Gambler,
        Miniboss,
        Boss
    }

    public Encounter()
    {

    }

    public Encounter(int [] coordinates)
    {
        mapLocation = coordinates;
    }

    public Encounter(EncounterType encounter)
    {
        encounterType = encounter;
    }
}
