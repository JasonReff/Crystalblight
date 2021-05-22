using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemySingleTargetCharacterSkill
{
    public override void Activate()
    {
        if (IsValid() == true)
        {
            base.Activate();
            baseDamage = enemy.attackDamage;
            Damage(enemy, target);
            EndSkill();
        }
    }
}
