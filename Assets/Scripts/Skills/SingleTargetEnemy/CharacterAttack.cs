using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterSingleTargetEnemySkill
{
    public CharacterAttack(int damage)
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
