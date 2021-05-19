using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public string selectedCharacter;
    public int selectedDiscipline;

    public PlayerData playerData;

    private void OnMouseDown()
    {
        int vitality = GetCharacterStat("Vitality");
        int intelligence = GetCharacterStat("Intelligence");
        int strength = GetCharacterStat("Strength");
        int dexterity = GetCharacterStat("Dexterity");
        int endurance = GetCharacterStat("Endurance");
        Skill skill1 = GetCharacterSkill();
        Character character1 = new Character(1, selectedCharacter, vitality, strength, intelligence, dexterity, endurance, skill1);
        playerData.characters.Add(character1);
    }

    public int GetCharacterStat(string stat)
    {
        string characterStat = selectedCharacter + stat;
        int statValue = Int32.Parse(ReadPref.FindFromCSV("CharacterData.csv", characterStat));
        return statValue;
    }
    
    public Skill GetCharacterSkill()
    {
        string skillName = CharacterSkillName();
        int SPCost = Int32.Parse(ReadPref.FindFromCSV("CharacterSkillData.csv", skillName + "SPCost"));
        int baseDamage = Int32.Parse(ReadPref.FindFromCSV("CharacterSkillData.csv", skillName + "BaseDamage"));
        string damageType = ReadPref.FindFromCSV("CharacterSkillData.csv", skillName + "DamageType");
        string targetingType = ReadPref.FindFromCSV("CharacterSkillData.csv", skillName + "TargetingType");
        string skillDescription = ReadPref.FindFromCSV("CharacterSkillData.csv", skillName + "Description");
        Skill skill1 = new Skill(skillName, SPCost, baseDamage, damageType, targetingType, skillDescription);
        return skill1;
    }

    public string CharacterSkillName()
    {
        string characterSkill = selectedCharacter + "Skill" + selectedDiscipline;
        string skillName = ReadPref.FindFromCSV("CharacterData.csv", characterSkill);
        return skillName;
    }

}
