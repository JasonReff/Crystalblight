using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefend : EnemyUntargetedSkill
{
    public override void Activate()
    {
        if (IsValid() == true)
        {
            base.Activate();
            GuardGain();
            InflictStatus(enemy, StatusEffect.StatusType.Steadfast, 1);
            EndSkill();
        }
    }
}
