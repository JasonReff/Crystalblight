using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleTargetCharacterSkill : EnemySkill
{
    new public Character target;

    public override void Activate()
    {
        base.Activate();
    }

    public override bool IsValid()
    {
        if (target = null)
        {
            return false;
        }
        return base.IsValid();
    }
}
