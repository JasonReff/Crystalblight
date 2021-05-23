using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvoryPalace : Stage
{
    public IvoryPalace()
    {
        realmName = RealmName.IvoryPalace;
    }

    public override List<Enemy> GetEnemyPool()
    {
        List<Enemy> enemyPool = base.GetEnemyPool();
        return enemyPool;
    }

}
