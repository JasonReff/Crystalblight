using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : IvoryPalace
{
    public Dungeon()
    {
        stageNumber = 1;
        realmName = RealmName.IvoryPalace;
        stageName = StageName.Dungeon;
        enemyPool = GetEnemyPool();
    }

    public override List<Enemy> GetEnemyPool()
    {
        List<Enemy> enemyPool = base.GetEnemyPool();
        return enemyPool;
    }
}
