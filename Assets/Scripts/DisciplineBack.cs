using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisciplineBack : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject disciplineDisplay = GameObject.Find("DisciplineDisplay");
        disciplineDisplay.transform.localPosition = new Vector3(0, -1000, -1);
        GameObject disciplineText = GameObject.Find("DisciplineText");
        disciplineText.transform.localPosition = new Vector3(0, -350, -1);
        GameObject disciplineDiss = GameObject.Find("DisciplineDiss");
        disciplineDiss.transform.localPosition = new Vector3(0, -2500, -2);
    }
}
