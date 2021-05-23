using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySkill : MonoBehaviour
{

    public string skillName;
    public int baseDamage;
    public Skill.DamageType damageType;
    public TargetingType targetingType;
    public string skillDescription;
    public GameObject target;
    public Enemy enemy;

    public enum TargetingType
    {
        SingleTargetCharacter,
        Untargeted,
        SingleTargetAlly,
        SingleTargetAllyOther,
        CharacterRow,
        CharacterColumn
    }

    public static EnemySkill CreateSkill(string name)
    {
        Type t = Type.GetType(name);
        EnemySkill skill = (EnemySkill)Activator.CreateInstance(t);
        string fileName = "EnemySkillData.csv";
        skill.skillName = name;
        skill.baseDamage = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "BaseDamage"));
        skill.damageType = (Skill.DamageType)Enum.Parse(typeof(Skill.DamageType), ReadPref.FindFromCSV(fileName, name + "DamageType"));
        skill.targetingType = (TargetingType)Enum.Parse(typeof(TargetingType), ReadPref.FindFromCSV(fileName, name + "TargetingType"));
        skill.skillDescription = ReadPref.FindFromCSV(fileName, name + "Description");
        return skill;
    }

    public virtual void Activate()
    {
        enemy = GetComponent<Enemy>(); //find the enemy this skill is attached to
    }

    public virtual bool IsValid()
    {
        return true;
    }

    public void EndSkill()
    {
        enemy.turnTaken = true;
    }

    public void Damage(Enemy enemy, Character character)
    {
        int damage = baseDamage;
        if (DoesSkillTarget(enemy, character) == true)
        {
            damage = CriticalDamage(enemy, damage);
            damage = ResistanceWeaknessAdjustment(character, damage);
            if (enemy.statusEffects.Contains(new StatusEffect(StatusEffect.StatusType.Vulnerable)))
            {
                DamageVulnerableCharacter(character, damage);
            }
            else if (enemy.statusEffects.Contains(new StatusEffect(StatusEffect.StatusType.Steadfast)))
            {
                DamageSteadfastCharacter(character, damage);
            }
            else
            {
                DamageCharacter(character, damage);
            }
        }
        else
        {
            Miss(character);
        }
    }

    bool DoesSkillTarget(Enemy enemy, Character character)
    {
        int accuracyCheck = UnityEngine.Random.Range(1, 101); //generate number between 1 and 100
        if (enemy.accuracy - character.dodge < accuracyCheck)
        {
            return false;
        }
        else return true;
    }

    int CriticalDamage(Enemy enemy, int damage)
    {
        double criticalModifier = 1.5;
        int criticalCheck = UnityEngine.Random.Range(1, 101);
        if (criticalCheck < enemy.critrate)
        {
            damage = (int)Math.Round(damage * criticalModifier);
        }
        return damage;
    }

    int ResistanceWeaknessAdjustment(Character character, int damage)
    {
        double resistanceModifier = 0.5;
        double weaknessModifier = 1.5;
        if (character.resistances.Contains(damageType))
        {
            damage = (int)Math.Round(damage * resistanceModifier);
        }
        else if (character.weaknesses.Contains(damageType))
        {
            damage = (int)Math.Round(damage * weaknessModifier);
        }
        return damage;
    }

    void DamageVulnerableCharacter(Character character, int damage)
    {
        character.health -= damage;
    }

    void DamageSteadfastCharacter(Character character, int damage)
    {
        character.guard -= damage;
        if (character.guard < 0)
        {
            character.health += enemy.guard;
            character.guard = 0;
        }
    }

    void DamageCharacter(Character character, int damage)
    {
        character.guard -= (damage / 2) + (damage % 2);
        character.health -= (damage / 2);
        if (character.guard < 0)
        {
            character.health += character.guard;
            character.guard = 0;
        }
    }

    void Miss(Character character)
    {
        GameObject miss = GameObject.Find("Miss");
        GameObject target = character.GetComponent<GameObject>();
        miss.transform.localPosition = target.transform.localPosition;
        StartCoroutine(MissWait());
        miss.transform.localPosition = new Vector3(-2500, 0, 0);
    }

    IEnumerator MissWait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void GuardGain()
    {
        enemy.guard += enemy.guardGain;
        if (enemy.guard > enemy.maxGuard)
        {
            enemy.guard = enemy.maxGuard;
        }
    }
}
