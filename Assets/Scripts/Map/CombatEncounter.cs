using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CombatEncounter : Encounter
{
    public Stage stage;
    public int combatNumber;
    public List<Enemy> enemies;
    public int difficulty;
    public int XPReward;
    public List<Item> itemRewards;

    public CombatEncounter(int mapXValue)
    {
        int newDifficulty = mapXValue / 2 + mapXValue % 2;
        encounterType = EncounterType.Combat;
        difficulty = newDifficulty;
        enemies = EnemiesInCombat(difficulty);
    }

    public List<Enemy> EnemiesInCombat(int difficulty)
    {
        int combatXP = 0;
        int XPMinimum = 10 + 10 * difficulty;
        int XPMaximum = 30 + 10 * difficulty;
        List<Enemy> enemies = new List<Enemy> { };
        do
        {
            Enemy pulledEnemy = GenerateEnemy();
            enemies.Add(pulledEnemy);
            combatXP += pulledEnemy.XP;
            if (combatXP > XPMaximum)
            {
                combatXP = 0;
                enemies.Clear();
            }
        }
        while (combatXP < XPMinimum || combatXP > XPMaximum);
        return enemies;
    }

    public Enemy GenerateEnemy()
    {
        List<Enemy> enemyPool = stage.enemyPool;
        int random = UnityEngine.Random.Range(0, enemyPool.Count);
        Enemy pulledEnemy = enemyPool[random];
        return pulledEnemy;
    }
}
