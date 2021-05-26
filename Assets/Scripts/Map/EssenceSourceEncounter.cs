using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSourceEncounter : Encounter
{

    public Character character1;
    public Character character2;

    public EssenceSourceEncounter()
    {
        encounterType = EncounterType.EssenceSource;
    }

}
