using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{

    public string characterName;
    public CharacterSelect characterSelect;

    private void OnMouseDown()
    {
        characterSelect.selectedCharacter = characterName;
    }

    public void GetDisciplineScreen()
    {
        GameObject disciplineDiss = GameObject.Find("DisciplineDiss");
        disciplineDiss.transform.localPosition = new Vector3(0, 0, -2);
        GameObject disciplineDisplay = GameObject.Find("DisciplineDisplay");
        disciplineDisplay.transform.localPosition = new Vector3(0, 0, -3);
        GameObject disciplineText = GameObject.Find("DisciplineText");
        disciplineText.transform.localPosition = new Vector3(0, 0, -3);
    }

    public void GetDisciplineData()
    {
        for (int disciplineNumber = 1; disciplineNumber <= 3; disciplineNumber++)
        {
            GameObject disciplineButton = GameObject.Find("Discipline" + disciplineNumber);
            string disciplineName = ReadPref.FindFromCSV("CharacterData.csv", "Discipline" + disciplineNumber);
            string disciplineDescription = ReadPref.FindFromCSV("CharacterData.csv", "Discipline" + disciplineNumber + "Description");
            string skillName = ReadPref.FindFromCSV("CharacterData.csv", "Discipline" + disciplineNumber + "Skill");
            string ultimateName = ReadPref.FindFromCSV("CharacterData.csv", "Discipline" + disciplineNumber + "Ultimate");
        }
    }
}
