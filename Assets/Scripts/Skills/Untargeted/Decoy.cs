using System;

public class Decoy : CharacterUntargetedSkill
{
	public override void Activate()
	{
		if (IsValid() == true)
		{
			base.Activate();
			InflictStatus(character, StatusEffect.StatusType.Decoy, 2);
			EndSkill();
		}
	}
}
