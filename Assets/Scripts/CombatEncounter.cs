using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEncounter : MonoBehaviour
{
    public int stageNumber;
    public int combatNumber;
    public int[] mapLocation = new int[2];
    public List<Enemy> enemies;
    public int difficulty;
    public int XPReward;
    public List<Item> itemRewards;
}
