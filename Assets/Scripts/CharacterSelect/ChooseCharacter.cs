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
        characterSelect.selectedDiscipline = 0;
        GetDisciplineScreen();
        GetDisciplineData();
    }

    public void GetDisciplineScreen()
    {
        GameObject disciplineDiss = GameObject.Find("DisciplineDiss");
        disciplineDiss.transform.localPosition = new Vector3(0, 0, -2);
        GameObject disciplineDisplay = GameObject.Find("DisciplineDisplay");
        disciplineDisplay.transform.localPosition = new Vector3(0, 0, -3);
    }

    public void GetDisciplineData()
    {
        for (int disciplineNumber = 1; disciplineNumber <= 3; disciplineNumber++)
        {
            GameObject disciplineButton = GameObject.Find("Discipline" + disciplineNumber);
            ChooseDiscipline chooseDiscipline = disciplineButton.GetComponent<ChooseDiscipline>();
            string disciplineName = ReadPref.FindFromCSV("CharacterData.csv", characterName + "Discipline" + disciplineNumber);
            chooseDiscipline.disciplineName.text = disciplineName;
            string disciplineDescription = ReadPref.FindFromCSV("CharacterData.csv", characterName + "Discipline" + disciplineNumber + "Description");
            chooseDiscipline.disciplineDescription.text = disciplineDescription;
            string skillName = ReadPref.FindFromCSV("CharacterData.csv", characterName + "Discipline" + disciplineNumber + "Skill");
            chooseDiscipline.skillName.text = skillName;
            string ultimateName = ReadPref.FindFromCSV("CharacterData.csv", characterName + "Discipline" + disciplineNumber + "Ultimate");
            chooseDiscipline.ultimateName.text = ultimateName;
        }
    }
}
