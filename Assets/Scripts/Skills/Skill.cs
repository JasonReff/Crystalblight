using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int SPCost;
    public int effectValue;
    public DamageType damageType;
    public TargetingType targetingType;
    public string skillDescription;
    public Character character;
    public GameObject target;
    public CombatSystem combatSystem;

    public Skill()
    {

    }
    
    
    // right now, this constructor is not being used
    public Skill(string name, int SP, int damage, DamageType type, TargetingType targeting, string description)
    {
        skillName = name;
        SPCost = SP;
        effectValue = damage;
        damageType = type;
        targetingType = targeting;
        skillDescription = description;
    }
    
    public enum TargetingType 
    {
        SingleTargetEnemy,
        SingleTargetAlly,
        SingleTargetAllyOther,
        Untargeted,
        EnemyRow,
        EnemyColumn
    }

    public enum DamageType
    {
        Acid,
        Blood,
        Dark,
        Electric,
        Explosive,
        Fire,
        Frost,
        Light,
        Magic,
        None,
        Physical,
        Toxic
    }

    public virtual void Activate()
    {
        character = GetComponent<Character>(); //Find character that this skill is attached to.
        SPSpend();
    }

    public virtual bool IsValid()
    {
        if (SPCost > character.SP)
        {
            Console.WriteLine("Not Enough SP");
            return false;
        }
        else return true;
    }

    public void EndSkill()
    {
        character.turnTaken = true;
        combatSystem = GameObject.Find("CombatSystem").GetComponent<CombatSystem>();
        combatSystem.activeSkill = null;
    }

    
    //this is the method used to create skill objects
    public static Skill CreateSkill(string name)
    {
        Type t = Type.GetType(name);
        Skill skill = (Skill)Activator.CreateInstance(t);
        skill.skillName = name;
        skill.SPCost = Int32.Parse(ReadPref.FindFromCSV("CharacterSkillData.csv", name, "SPCost"));
        skill.effectValue = Int32.Parse(ReadPref.FindFromCSV("CharacterSkillData.csv", name, "Effect"));
        skill.damageType = (DamageType)Enum.Parse(typeof(DamageType), ReadPref.FindFromCSV("CharacterSkillData.csv", name, "DamageType"));
        skill.targetingType = (TargetingType)Enum.Parse(typeof(TargetingType), ReadPref.FindFromCSV("CharacterSkillData.csv", name, "TargetingType"));
        skill.skillDescription = ReadPref.FindFromCSV("CharacterSkillData.csv", name, "Description");
        return skill;
    }

    public virtual void CalculateEffect(string skillName)
    {
        
        /*
        string equation = ReadPref.FindFromCSV("CharacterSkillData.csv", skillName, "Effect");
        string skillModifier = ReadPref.FindFromCSV("CharacterSkillData.csv", skillName, "EffectModifier");
        int modifierValue = 0;
        switch (skillModifier) 
        {
            case "":
                break;
            case "VIT":
                modifierValue = character.vitality;
                break;
            case "STR":
                modifierValue = character.strength;
                break;
            case "INT":
                modifierValue = character.intelligence;
                break;
            case "DEX":
                modifierValue = character.dexterity;
                break;
            case "END":
                modifierValue = character.endurance;
                break;
        }
        effectValue = Calculate.Calc(equation, modifierValue);
         */
    }

    void SPSpend()
    {
        character.SP -= SPCost;
    }

    public void GainGuard(Character character, int guard)
    {
        character.guard += guard;
        if (character.guard > character.maxGuard)
        {
            character.guard = character.maxGuard;
        }
    }

    public void Damage(Character player, Enemy enemy)
    {
        int damage = effectValue;
        if (DoesSkillTarget(player, enemy) == true)
        {
            damage = CriticalDamage(player, damage);
            damage = ResistanceWeaknessAdjustment(enemy, damage);
            if (enemy.statusEffects.Contains(new StatusEffect(StatusEffect.StatusType.Vulnerable)))
            {
                DamageVulnerableEnemy(enemy, damage);
            }
            else if (enemy.statusEffects.Contains(new StatusEffect(StatusEffect.StatusType.Steadfast)))
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

    int ResistanceWeaknessAdjustment(Enemy enemy, int damage)
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

    void DamageVulnerableEnemy(Enemy enemy, int damage)
    {
        enemy.health -= damage;
    }

    void DamageSteadfastEnemy(Enemy enemy, int damage)
    {
        enemy.guard -= damage;
        if (enemy.guard < 0)
        {
            enemy.health += enemy.guard;
            enemy.guard = 0;
        }
    }

    void DamageEnemy(Enemy enemy, int damage)
    {
        enemy.guard -= (damage / 2) + (damage % 2);
        enemy.health -= (damage / 2);
        if (enemy.guard < 0)
        {
            enemy.health += enemy.guard;
            enemy.guard = 0;
        }
    }

    bool DoesSkillTarget(Character player, Enemy enemy)
    {
        int accuracyCheck = UnityEngine.Random.Range(1, 101); //generate number between 1 and 100
        if (player.accuracy - enemy.dodge < accuracyCheck)
        {
            return false;
        }
        else return true;
    }

    void Miss(Enemy enemy)
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

    public void InflictStatus(Character character, StatusEffect.StatusType status, int statusValue)
    {
        List<StatusEffect> effects = character.statuses;
        if (effects.Contains(new StatusEffect(status)))
        {
            StatusEffect characterStatus = effects.Find(x => x.statusType == status);
            characterStatus.statusValue += statusValue;

        }
        else
        {
            StatusEffect statusEffect = new StatusEffect(status, statusValue);
            effects.Add(statusEffect);
        }
    }
}