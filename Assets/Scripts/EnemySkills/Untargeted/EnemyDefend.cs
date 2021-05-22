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
            EndSkill();
        }
    }
}
