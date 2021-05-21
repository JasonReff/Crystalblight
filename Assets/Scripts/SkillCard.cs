using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SkillCard : MonoBehaviour
{
    public CombatSystem combatSystem;
    public int skillNumber;
    public Character activePlayer;
    public Skill skill;
    public Text nameText;
    public Text SPCost;
    public Text description;

    private void Start()
    {
        StartCoroutine(SkillUpdate());
    }
    IEnumerator SkillUpdate()
    {
        while (true)
        {
            activePlayer = combatSystem.activePlayer;
            skill = activePlayer.skills[skillNumber];
            nameText.text = skill.ToString();
            SPCost.text = skill.SPCost.ToString();
            description.text = skill.skillDescription;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void OnMouseDown()
    {
        skill.Activate();
    }
}
