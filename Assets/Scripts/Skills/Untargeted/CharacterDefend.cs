using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefend : CharacterUntargetedSkill
{
    public int defendingGuard;
    public CharacterDefend(int endurance)
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
