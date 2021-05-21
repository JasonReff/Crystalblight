using System;
using System.Collections;
using System.Runtime.Remoting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int SPCost;
    public int baseDamage;
    public string damageType;
    public string targetingType;
    public string skillDescription;
    public Character activePlayer;
    public GameObject target;

    public Skill()
    {

    }
    
    public Skill(string name, int SP, int damage, string type, string targeting, string description)
    {
        skillName = name;
        SPCost = SP;
        baseDamage = damage;
        damageType = type;
        targetingType = targeting;
        skillDescription = description;
    }

    public virtual void Activate()
    {
        activePlayer = GetComponent<Character>(); //Find character that this skill is attached to.
        SPSpend();
    }

    public static Skill CreateSkill(string name)
    {
        ObjectHandle handle = Activator.CreateInstance("Skill.cs", name);
        Skill skill = (Skill)handle.Unwrap();
        return skill;
    }
    
    public class SingleTargetSkill : Skill
    {
        new public E1 target;
        public override void Activate()
        {
            base.Activate();
        }
    }

    public class Attack : SingleTargetSkill
    {   
        public Attack(int damage)
        {
            baseDamage = damage;
        }
        public override void Activate()
        {
            base.Activate();
            baseDamage = activePlayer.attackDamage;
            Damage(activePlayer, target);
            activePlayer.turnTaken = true;
        }
    }

    void SPSpend()
    {
        activePlayer.SP -= SPCost;
    }

    void Damage(Character player, E1 enemy)
    {
        int damage = baseDamage;
        if (DoesSkillTarget(player, enemy) == true)
        {
            damage = CriticalDamage(player, damage);
            damage = ResistanceWeaknessAdjustment(enemy, damage);
            if (enemy.statusEffects.Contains("vulnerable"))
            {
                DamageVulnerableEnemy(enemy, damage);
            }
            else if (enemy.statusEffects.Contains("steadfast"))
            {
                DamageSteadfastEnemy(enemy, damage);
            }
            else
            {
                DamageEnemy(enemy, damage);
            }
        }
        else
        {
            Miss(enemy);
        }
    }

    int CriticalDamage(Character player, int damage)
    {
        double criticalModifier = 1.5;
        int criticalCheck = UnityEngine.Random.Range(1, 101);
        if (criticalCheck < player.critrate)
        {
            damage = (int)Math.Round(damage * criticalModifier);
        }
        return damage;
    }

    int ResistanceWeaknessAdjustment(E1 enemy, int damage)
    {
        double resistanceModifier = 0.5;
        double weaknessModifier = 1.5;
        if (enemy.resistances.Contains(damageType))
        {
            damage = (int)Math.Round(damage * resistanceModifier);
        }
        else if (enemy.weaknesses.Contains(damageType))
        {
            damage = (int)Math.Round(damage * weaknessModifier);
        }
        return damage;
    }

    void DamageVulnerableEnemy(E1 enemy, int damage)
    {
        enemy.health -= damage;
    }

    void DamageSteadfastEnemy(E1 enemy, int damage)
    {
        enemy.guard -= damage;
        if (enemy.guard < 0)
        {
            enemy.health += enemy.guard;
            enemy.guard = 0;
        }
    }

    void DamageEnemy(E1 enemy, int damage)
    {
        enemy.guard -= (damage / 2) + (damage % 2);
        enemy.health -= (damage / 2);
        if (enemy.guard < 0)
        {
            enemy.health += enemy.guard;
            enemy.guard = 0;
        }
    }

    bool DoesSkillTarget(Character player, E1 enemy)
    {
        int accuracyCheck = UnityEngine.Random.Range(1, 101); //generate number between 1 and 100
        if (player.accuracy - enemy.dodge < accuracyCheck)
        {
            return false;
        }
        else return true;
    }

    void Miss(E1 enemy)
    {
        GameObject miss = GameObject.Find("Miss");
        GameObject target = enemy.GetComponent<GameObject>();
        miss.transform.localPosition = target.transform.localPosition;
        StartCoroutine(MissWait());
        miss.transform.localPosition = new Vector3(-2500, 0, 0);
    }

    IEnumerator MissWait()
    {
        yield return new WaitForSeconds(1.0f);
    }
}