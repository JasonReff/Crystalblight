using System;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public string selectedCharacter;
    public int selectedDiscipline;

    public PlayerData playerData;
    public GenerateGame generateGame;

    private void OnMouseDown()
    {
        if (selectedCharacter == "" || selectedDiscipline == 0)
        {
            return;
        }
        NewCharacter();
        generateGame.StartGame();
    }

    public void NewCharacter()
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
        string characterStat = stat;
        int statValue = Int32.Parse(ReadPref.FindFromCSV("CharacterData.csv", selectedCharacter, characterStat));
        return statValue;
    }
    
    public Skill GetCharacterSkill()
    {
        string skillName = CharacterSkillName();
        Skill skill = Skill.CreateSkill(skillName);
        return skill;
    }

    public string CharacterSkillName()
    {
        string characterSkill = "Skill" + selectedDiscipline;
        string skillName = ReadPref.FindFromCSV("CharacterSkillData.csv", selectedCharacter, characterSkill);
        return skillName;
    }

}
