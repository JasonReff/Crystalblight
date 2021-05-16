using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SkillCard1 : MonoBehaviour
{
    public Text textbox;
    public GameObject InputDiss;
    public unclick unclick;
    public CombatSystem combatSystem;
    public char skill;
    public string skillName;
    public GameObject nameText;

    private void Start()
    {
        StartCoroutine(SkillUpdate());
    }
    IEnumerator SkillUpdate()
    {
        while (true)
        {
            int p = combatSystem.activePlayer;
            FindSkillNumber(p);
            nameText.GetComponent<Text>().text = skillName;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void OnMouseDown()
    {
        skill = this.gameObject.name[10];
        int p = 0;
        for (int x = 1; x <= 4; x++)
        {
            GameObject player = GameObject.Find("P" + x);
            if (player.GetComponent<P1Combat>().clicked == true) { p = x; break; }
        }
        unclick.OnMouseDown();
        FindSkillNumber(p);
        textbox.text = "Choose target for skill";
        GameObject PDiss = GameObject.Find("PDiss");
        PDiss.transform.position = new Vector3(-500, 0, -100);
        GameObject.Find("P" + p).GetComponent<P1Combat>().targeting = true;
        GameObject.Find("P" + p).GetComponent<P1Combat>().clicked = false;
        combatSystem.activePlayer = p;
        }

    void FindSkillNumber(int p)
    {   
        switch (skill)
        {
            case 'A': skillName = "Attack"; break;
            case 'D': skillName = "Defend"; break;
            case '1': skillName = GameObject.Find("P" + p).GetComponent<P1Combat>().skill1; break;
            case '2': skillName = GameObject.Find("P" + p).GetComponent<P1Combat>().skill2; break;
            case '3': skillName = GameObject.Find("P" + p).GetComponent<P1Combat>().skill3; break;
            case '4': skillName = GameObject.Find("P" + p).GetComponent<P1Combat>().skill4; break;
        }
    }
}
