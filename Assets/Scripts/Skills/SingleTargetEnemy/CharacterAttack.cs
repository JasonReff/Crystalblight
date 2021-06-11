using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterSingleTargetEnemySkill
{
    public CharacterAttack(int damage)
    {
        effectValue = damage;
    }
    public override void Activate()
    {
        if (IsValid() == true)
        {
            base.Activate();
            effectValue = character.attackDamage;
            Damage(character, target);
            EndSkill();
        }
    }
}
