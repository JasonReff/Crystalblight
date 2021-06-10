using JetBrains.Annotations;
using System;

public class Bolster : CharacterUntargetedSkill
{
    public int bolsterGuardGain;
    public override void Activate()
    {
        bolsterGuardGain = 3 + 3 * character.endurance;
        if (IsValid() == true)
        {
            base.Activate();
            GainGuard(character, bolsterGuardGain);
            EndSkill();
        }
    }
}
