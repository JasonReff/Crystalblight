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
    public Text damage;
    public Text SPCost;
    public Text description;

    private void Start()
    {
        StartCoroutine(SkillUpdate());
        StartCoroutine(SkillCardAppear());
    }
    IEnumerator SkillUpdate()
    {
        while (true)
        {
            SkillCardUpdate();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SkillCardUpdate()
    {
        activePlayer = combatSystem.activePlayer;
        skill = activePlayer.skills[skillNumber];
        nameText.text = skill.ToString();
        damage.text = skill.effectValue.ToString();
        SPCost.text = skill.SPCost.ToString();
        description.text = skill.skillDescription;
    }

    IEnumerator SkillCardAppear()
    {
        while (activePlayer = null)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        while (activePlayer != null)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    } 
    void OnMouseDown()
    {
        if (skill.targetingType == Skill.TargetingType.Untargeted)
        {
            skill.Activate();
        }
        else
        {
            combatSystem.activeSkill = skill;
        }
    }
}
