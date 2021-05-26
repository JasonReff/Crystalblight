using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamblerEncounter : Encounter
{
    public GamblerEvent gamblerEvent;
    public enum GamblerEvent
    {
        Trade,
        Oracle,
    }
    public GamblerEncounter()
    {
        encounterType = EncounterType.Gambler;
    }
}
