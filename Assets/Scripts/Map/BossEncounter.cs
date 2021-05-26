using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEncounter : CombatEncounter
{
    public BossEncounter()
    {
        encounterType = EncounterType.Boss;
    }
}
