using System;

public class AetherCloak : CharacterUntargetedSkill
{
    public int aetherCloakGuardGain;

    public override void Activate()
    {
        base.Activate();
        if (IsValid() == true)
        {
            base.Activate();
            GainGuard(character, aetherCloakGuardGain);
            InflictStatus(character, StatusEffect.StatusType.Ethereal, 2);
            EndSkill();
        }
    }
}
