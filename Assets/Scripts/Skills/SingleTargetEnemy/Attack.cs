using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : SingleTargetEnemySkill
{
    public Attack(int damage)
    {
        baseDamage = damage;
    }
    public override void Activate()
    {
        if (IsValid() == true)
        {
            base.Activate();
            baseDamage = character.attackDamage;
            Damage(character, target);
            EndSkill();
        }
    }
}
