using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : IvoryPalace
{
    public Dungeon()
    {
        realmName = RealmName.IvoryPalace;
        stageName = StageName.Dungeon;
    }

    public override List<Enemy> GetEnemyPool()
    {
        List<Enemy> enemyPool = base.GetEnemyPool();
        return enemyPool;
    }
}
