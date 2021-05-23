using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CombatEncounter : Encounter
{
    public int stageNumber;
    public int combatNumber;
    public List<Enemy> enemies;
    public int difficulty;
    public int XPReward;
    public List<Item> itemRewards;

    public CombatEncounter(int newDifficulty)
    {
        encounterType = EncounterType.Combat;
        difficulty = newDifficulty;
    }

    public List<Enemy> EnemiesInCombat(int difficulty)
    {
        int combatXP = 0;
        int XPMinimum = 10 + 10 * difficulty;
        int XPMaximum = 30 + 10 * difficulty;
        do
        {
            List<Enemy> enemyPool = 
        }
        while ()
    }
}
