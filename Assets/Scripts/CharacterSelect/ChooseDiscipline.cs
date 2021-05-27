using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDiscipline : MonoBehaviour
{
    public int disciplineNumber;
    public Text disciplineName;
    public Text disciplineDescription;
    public Text skillName;
    public Text ultimateName;
    public CharacterSelect characterSelect;

    private void OnMouseDown()
    {
        characterSelect.selectedDiscipline = disciplineNumber;
    }
}
