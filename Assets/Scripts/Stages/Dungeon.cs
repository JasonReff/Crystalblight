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
        List<Enemy> newEnemyPool = DungeonEnemies(enemyPool);
        return newEnemyPool;
    }

    public List<Enemy> DungeonEnemies(List<Enemy> enemyPool)
    {
        for (int enemy = 1; enemy <= 4; enemy++)
        {
            string enemyName = ReadPref.FindFromCSV("EnemyData.csv", "Dungeon" + enemy);
            Enemy newEnemy = new Enemy(enemyName);
            enemyPool.Add(newEnemy);
        }
        return enemyPool;
    }
}
