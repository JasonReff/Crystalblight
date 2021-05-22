using System;
using System.Collections.Generic;

public class SingleTargetEnemySkill : Skill
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

    public void InflictStatus(Enemy enemy, StatusEffect.StatusType status, int statusValue)
    {
        List<StatusEffect> effects = enemy.statusEffects;
        if (effects.Contains(new StatusEffect(status)))
        {
            StatusEffect enemyStatus = effects.Find(x => x.statusType == status);
            enemyStatus.statusValue += statusValue;

        }
        else
        {
            StatusEffect statusEffect = new StatusEffect(status, statusValue);
            effects.Add(statusEffect);
        }
    }
}
