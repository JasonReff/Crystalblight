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
        List<Enemy> newEnemyPool = IvoryPalaceEnemies(enemyPool);
        return newEnemyPool;
    }

    public List<Enemy> IvoryPalaceEnemies(List<Enemy> enemyPool)
    {
        for (int enemy = 1; enemy <= 4; enemy++)
        {
            string enemyName = ReadPref.FindFromCSV("EnemyData.csv", "IvoryPalaceEnemy" + enemy);
            Enemy newEnemy = new Enemy(enemyName);
            enemyPool.Add(newEnemy);
        }
        return enemyPool;
    }
}
