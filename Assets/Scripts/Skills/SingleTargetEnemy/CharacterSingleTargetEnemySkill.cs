using System;
using System.Collections.Generic;

public class CharacterSingleTargetEnemySkill : Skill
{
    new public Enemy target;
    public override void Activate()
    {
        base.Activate();
    }

    public override bool IsValid()
    {
        if (target = null)
        {
            Console.WriteLine("Invalid Target");
            return false;
        }
        return base.IsValid();
    }
}
