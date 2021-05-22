using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : UntargetedSkill
{
    public int defendingGuard;
    public Defend(int endurance)
    {
        defendingGuard = 2 * endurance;
    }

    public override void Activate()
    {
        if (IsValid() == true)
        {
            base.Activate();
            GainGuard(character, defendingGuard);
            EndSkill();
        }
    }
}
