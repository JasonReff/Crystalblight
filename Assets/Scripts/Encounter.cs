using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Encounter : MonoBehaviour
{
    public int[] mapLocation = new int[2];
    public EncounterType encounterType;
    public enum EncounterType
    {
        Combat,
        Merchant,
        EssenceSource,
        Gambler,
    }

    public Encounter()
    {

    }

    public Encounter(EncounterType encounter)
    {
        encounterType = encounter;
    }
}
