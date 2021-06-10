using System;

public class Riposte : CharacterUntargetedSkill
{
	public bool skillUsed;
	
	public override void Activate()
	{
		if (IsValid() == true)
		{
			base.Activate();
			InflictStatus(character, StatusEffect.StatusType.Counter, 1);
			EndFastSkill();
		}
	}

	public void EndFastSkill()
	{
		if (skillUsed == true)
		{
			EndSkill();
			skillUsed = false;
		}
		else
		{
			skillUsed = true;
		}
	}
}
