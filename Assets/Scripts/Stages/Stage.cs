using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

[Serializable]
public class Stage : MonoBehaviour
{
    public int stageNumber;
    public RealmName realmName;
    public StageName stageName;
    public List<Enemy> enemyPool;

    public enum RealmName
    {
        IvoryPalace,
        MalvowDesert,
        TowerOfKalor,
        ClockworkManor,
        BrimstoneVillage,
        BarkskinForest
    }

    public enum StageName
    {
        Dungeon,
        Ramparts,
        ThroneRoom,
        ShiftingSands,
        GlassOcean,
        SunkenTomb,
        Ascension,
        Labyrinth,
        Archives,
        Courtyard,
        Stomach,
        Eye,
        Parish,
        PlagueWard,
        Inferno,
        Outskirts,
        Nest,
        VeridianLake
    }

    public virtual List<Enemy> GetEnemyPool()
    {
        List<Enemy> enemyPool = new List<Enemy> { };
        return enemyPool;
    }

    public Enemy GetEnemy(string enemyName)
    {
        Enemy enemy = new Enemy(enemyName);
        return enemy;
    }
    }
