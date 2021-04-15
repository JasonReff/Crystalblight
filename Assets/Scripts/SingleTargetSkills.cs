using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleTargetSkills : MonoBehaviour
{
    // This script acts as a skill library
    // OnMouseDown reads the skill and calls it
    private void Start()
    {
        for (int p = 1; p <= 2; p++)
        {
            for (int i = 1; i <= 4; i++)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("P" + p + "-Skill-" + i) + "-Played", 0);
                PlayerPrefs.SetInt("P" + p + "CombatGuardGained", 0);
            }
        }
    }

    public void OnMouseDown()
    {
        string activeSkill = PlayerPrefs.GetString("ActiveSkill");
        if (PlayerPrefs.GetString(activeSkill + "-Targeting") == "SingleTarget" || activeSkill == "Attack")
        {
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsWhiteSpace(c)));
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsSymbol(c)));
            Invoke(activeSkill, 0.1f);
        }
    }

    //The following is a set of dummy skills for reuse of code

    //The following are real skills
    void Attack()
    {

        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("slasher");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimation", 1.8f);
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int Att = PlayerPrefs.GetInt("P" + p + "-Attack");
            if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Flamebearer1")
            {
                StatusEffect.InflictStatusEnemy("burning", e, 1);
            }
            else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Flamebearer2")
            {
                StatusEffect.InflictStatusEnemy("burning", e, 2);
                int sp = PlayerPrefs.GetInt("P" + p + "-CSP");
                sp += 1;
                if (sp >= PlayerPrefs.GetInt("P" + p + "-SP")) { sp = PlayerPrefs.GetInt("P" + p + "-SP"); }
                float PercentSP = ((float)sp / (float)PlayerPrefs.GetInt("P" + p + "-SP"));
                GameObject SPBar = GameObject.Find("P" + p + "-Sp");
                SPBar.gameObject.transform.localScale = new Vector3(PercentSP, 1, 1);
            }
            else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Flamebearer3")
            {
                StatusEffect.InflictStatusEnemy("burning", e, 3);
                int sp = PlayerPrefs.GetInt("P" + p + "-CSP");
                sp += 2;
                if (sp >= PlayerPrefs.GetInt("P" + p + "-SP")) { sp = PlayerPrefs.GetInt("P" + p + "-SP"); }
                float PercentSP = ((float)sp / (float)PlayerPrefs.GetInt("P" + p + "-SP"));
                GameObject SPBar = GameObject.Find("P" + p + "-Sp");
                SPBar.gameObject.transform.localScale = new Vector3(PercentSP, 1, 1);
            }
            string damageType = PlayerPrefs.GetString("P" + p + "AttackDamageType");
            Damage(p, e, E1CHP, E1CG, Att, damageType);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Damage(int p, int e, int E1CHP, int E1CG, int Att, string damageType)
    {
        //accuracyCheck
        int accuracyCheck = UnityEngine.Random.Range(1, 101);
        if (PlayerPrefs.GetInt("P" + p + "-Accuracy") - PlayerPrefs.GetInt("E" + e + "-Dodge") < accuracyCheck)
        {
            Miss(e);
            /*PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            PlayerPrefs.SetString("ActiveSkill", "None");
            PlayerPrefs.SetInt("ENumber", 0);
            EndPlayerTurn();*/
        }
        else
        {

            if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Bloodlust1")
            {
                Att += 3;
            }
            if (PlayerPrefs.GetString("E" + e + "-Weakness1") == damageType || PlayerPrefs.GetString("E" + e + "-Weakness2") == damageType)
            {
                Att = (int)Math.Round((float)Att * 1.5, 1);
            }
            if (PlayerPrefs.GetString("E" + e + "-Resistance1") == damageType || PlayerPrefs.GetString("E" + e + "-Resistance2") == damageType || PlayerPrefs.GetString("E" + e + "-Resistance3") == damageType)
            {
                Att = (int)Math.Round((float)Att * 0.75, 1);
            }
            int critCheck = UnityEngine.Random.Range(1, 101);
            if (PlayerPrefs.GetInt("P" + p + "-CritRate") > critCheck)
            {
                Att = (int)Math.Round((float)Att * 1.5, 1);
                Crit(e);
            }
            if (PlayerPrefs.GetString("E" + e + "Status0") == "steadfast" || PlayerPrefs.GetString("E" + e + "Status1") == "steadfast" || PlayerPrefs.GetString("E" + e + "Status2") == "steadfast" || PlayerPrefs.GetString("E" + e + "Status3") == "steadfast")
            {
                E1CG -= Att;
            }
            else if (PlayerPrefs.GetString("E" + e + "Status0") == "vulnerable" || PlayerPrefs.GetString("E" + e + "Status1") == "vulnerable" || PlayerPrefs.GetString("E" + e + "Status2") == "vulnerable" || PlayerPrefs.GetString("E" + e + "Status3") == "vulnerable")
            {
                E1CHP -= Att;
            }
            else
            {
                E1CG = E1CG - ((Att / 2) + (Att % 2));
                E1CHP = E1CHP - Att / 2;
            }
            if (E1CG < 0)
            {
                E1CHP = E1CHP + E1CG;
                E1CG = 0;
            }
            GameObject GBar = GameObject.Find("E" + e + "-Guard");
            PlayerPrefs.SetInt("E" + e + "-CG", E1CG);
            int E1MaxG = PlayerPrefs.GetInt("E" + e + "-Guard");
            float PercentG = ((float)E1CG / (float)E1MaxG);
            GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
            GameObject Bar = GameObject.Find("E" + e + "-Hp");
            if (E1CHP > 0)
            {
                PlayerPrefs.SetInt("E" + e + "-CHP", E1CHP);
                int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                float PercentHP = ((float)E1CHP / (float)E1Max);
                Bar.gameObject.transform.localScale = new Vector3(PercentHP, 1, 1);
            }
            else
            {
                PlayerPrefs.SetInt("E" + e + "-CHP", 0);
                int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                float PercentHP = 0;
                Bar.gameObject.transform.localScale = new Vector3(PercentHP, 1, 1);
                GameObject enemy = GameObject.Find("E" + e);
                enemy.GetComponent<SpriteRenderer>().color = Color.black;
                if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                {
                    //change to map
                    RewardsScreen.RewardDisplay("standard");
                    PlayerPrefs.SetInt("E1-Set", 0);
                    //Application.LoadLevel("Win");
                }
                else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                {
                    //change to map
                    RewardsScreen.RewardDisplay("standard");
                    PlayerPrefs.SetInt("E1-Set", 0);
                    //Application.LoadLevel("Win");
                }

            }
        }
    }
    //Temporary skill

    public int Target()
    {
        int p = 0;
        if (PlayerPrefs.GetInt("P1-Targeting") == 1)
        {
            p = 1;
            PlayerPrefs.SetInt("P1-Targeting", 0);
        }
        else if (PlayerPrefs.GetInt("P2-Targeting") == 1)
        {
            p = 2;
            PlayerPrefs.SetInt("P2-Targeting", 0);
        }
        else if (PlayerPrefs.GetInt("P3-Targeting") == 1)
        {
            p = 3;
            PlayerPrefs.SetInt("P3-Targeting", 0);
        }
        else if (PlayerPrefs.GetInt("P4-Targeting") == 1)
        {
            p = 4;
            PlayerPrefs.SetInt("P4-Targeting", 0);
        }
        return p;

    }

    int RandomEnemy()
    {
        int enemyCount = 0;
        for (int i = 1; i <= 4; i++)
        {
            if (PlayerPrefs.GetString("E" + i + "-Name") != "null")
            {
                enemyCount++;
            }
        }
        int e = 0;
        do
        {
            e = UnityEngine.Random.Range(1, enemyCount + 1);
        }
        while (PlayerPrefs.GetInt("E" + e + "-CHP") <= 0);
        return e;
    }
    void SPSpend(int p, int P1CSP, int P1SP, int SPCost)
    {
        P1CSP = P1CSP - SPCost;
        PlayerPrefs.SetInt("P" + p + "-CSP", P1CSP);
        float PercentSP = ((float)P1CSP / (float)P1SP);
        GameObject SPBar = GameObject.Find("P" + p + "-Sp");
        SPBar.gameObject.transform.localScale = new Vector3(PercentSP, 1, 1);
    }

    void Fira()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int Att = PlayerPrefs.GetInt("P" + p + "-INT") * 30;
            string damageType = "Fire";
            int SPCost = 12;
            SPSpend(p, P1CSP, P1SP, SPCost);
            Damage(p, e, E1CHP, E1CG, Att, damageType);
            int collision = Push(e);
            Collision(e, collision, 10, "null", 0);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void QuickSlice()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int Att = PlayerPrefs.GetInt("P" + p + "-DEX") + 3;
            string damageType = "Physical";
            int SPCost = 4;
            SPSpend(p, P1CSP, P1SP, SPCost);
            Damage(p, e, E1CHP, E1CG, Att, damageType);
            if (PlayerPrefs.GetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played") == 1)
            {
                hero.GetComponent<SpriteRenderer>().color = Color.grey;
                PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
                EndPlayerTurn();
            }
            else
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played", 1);
            }
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void IronCleaver()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int Att = PlayerPrefs.GetInt("P" + p + "CombatGuardGained");
            string damageType = "Physical";
            Damage(p, e, E1CHP, E1CG, Att, damageType);
            int collision = Push(e);
            Collision(e, collision, 10, "null", 0);
            UltFinish(p);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Poison()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 5;
            string status = "poison";
            int statusX = 5;
            SPSpend(p, P1CSP, P1SP, SPCost);
            StatusEffect.InflictStatusEnemy(status, e, statusX);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void EldritchArmor()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
            int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int guard = 4 * PlayerPrefs.GetInt("P" + p + "-END");
            p1CG += guard;
            if (p1CG >= p1MaxGuard)
            {
                guard = p1MaxGuard - p1CG;
                p1CG = p1MaxGuard;
            }
            PlayerPrefs.SetInt("P" + p + "-CG", p1CG);
            GameObject GBar = GameObject.Find("P" + p + "-Guard");
            float PercentG = ((float)p1CG / (float)p1MaxGuard);
            GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 5;
            SPSpend(p, P1CSP, P1SP, SPCost);
            SpecialCharge(p, guard, "Iron Will");
            StatusEffect.InflictStatusEnemy("alarm", e, 2);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void EnergyAbsorption()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int enemyGuard = PlayerPrefs.GetInt("E" + e + "-CG");
            int enemyMaxGuard = PlayerPrefs.GetInt("E" + e + "-Guard");
            int absorption = 3 * PlayerPrefs.GetInt("P" + p + "-INT");
            if (enemyGuard >= absorption)
            {
                enemyGuard -= absorption;
            }
            else
            {
                absorption = enemyGuard;
                enemyGuard = 0;
            }
            int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
            int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            p1CG += absorption;
            int guard = absorption;
            if (p1CG >= p1MaxGuard)
            {
                guard = p1MaxGuard - p1CG;
                p1CG = p1MaxGuard;
            }
            PlayerPrefs.SetInt("P" + p + "-CG", p1CG);
            GameObject GBar = GameObject.Find("P" + p + "-Guard");
            float PercentG = ((float)p1CG / (float)p1MaxGuard);
            GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
            float enemyPercent = (float)enemyGuard / (float)enemyMaxGuard;
            GameObject enemyGuardBar = GameObject.Find("E" + e + "-Guard");
            enemyGuardBar.transform.localScale = new Vector3(enemyPercent, 1, 1);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 5;
            SPSpend(p, P1CSP, P1SP, SPCost);
            SpecialCharge(p, guard, "Iron Will");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void BraveSword()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 4;
            Damage(p, e, E1CHP, E1CG, 5 + 2 * PlayerPrefs.GetInt("P" + p + "-STR"), "Physical");
            SPSpend(p, P1CSP, P1SP, SPCost);
            StatusEffect.InflictStatusCharacter("decoy", p, 1);
            SpecialCharge(p, 1, "Ancient Champion");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Backswing()
    {
        int p = Target();
        if (p != 0)
        {
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 8;
            Damage(p, e, E1CHP, E1CG, 10 + 2 * PlayerPrefs.GetInt("P" + p + "-STR"), "Physical");
            SPSpend(p, P1CSP, P1SP, SPCost);
            StatusEffect.InflictStatusCharacter("counter", p, 1);
            SpecialCharge(p, 1, "Counterstrike");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void TitansClash()
    {
        int p = Target();
        if (p != 0)
        {
            int e = PlayerPrefs.GetInt("ENumber");
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int decoy = 0;
            for (int x = 0; x <= 3; x++)
            {
                if (PlayerPrefs.GetString("P" + p + "-Status" + x) == "decoy")
                {
                    decoy = PlayerPrefs.GetInt("P" + p + "-Status" + x + "X");
                }
            }
            int damage = 14 * decoy;
            Damage(p, e, E1CHP, E1CG, damage, "Physical");
            SPSpend(p, P1CSP, P1SP, 22);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }


    void HeatBlast()
    {
        int p = Target();
        if (p != 0)
        {
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 3;
            int damage = 8 + PlayerPrefs.GetInt("P" + p + "-INT");
            if (GameObject.Find("E-Block-25") != null)
            {
                if (PlayerPrefs.GetInt("E" + e + "-Loc") == 1 || PlayerPrefs.GetInt("E" + e + "-Loc") == 6 || PlayerPrefs.GetInt("E" + e + "-Loc") == 11 || PlayerPrefs.GetInt("E" + e + "-Loc") == 16 || PlayerPrefs.GetInt("E" + e + "-Loc") == 21)
                {
                    damage += 5;
                }
            }
            else if (GameObject.Find("E-Block-16") != null)
            {
                if (PlayerPrefs.GetInt("E" + e + "-Loc") == 1 || PlayerPrefs.GetInt("E" + e + "-Loc") == 5 || PlayerPrefs.GetInt("E" + e + "-Loc") == 9 || PlayerPrefs.GetInt("E" + e + "-Loc") == 13)
                {
                    damage += 5;
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("E" + e + "-Loc") == 1 || PlayerPrefs.GetInt("E" + e + "-Loc") == 4 || PlayerPrefs.GetInt("E" + e + "-Loc") == 7)
                {
                    damage += 5;
                }
            }
            Damage(p, e, E1CHP, E1CG, damage, "Fire");
            SPSpend(p, P1CSP, P1SP, SPCost);
            PlayerPrefs.SetInt("Processing", 1);
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void ThirdDegree()
    {
        int p = Target();
        if (p != 0)
        {
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 12;
            int damage = 16 + 2*PlayerPrefs.GetInt("P" + p + "-INT");
            Damage(p, e, E1CHP, E1CG, damage, "Fire");
            SPSpend(p, P1CSP, P1SP, SPCost);
            StatusEffect.InflictStatusEnemy("scarred", e, 4);
            PlayerPrefs.SetInt("Processing", 1);
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Combustion()
    {
        int p = Target();
        if (p != 0)
        {
            int e = PlayerPrefs.GetInt("ENumber");
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int E1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
            int E1CG = PlayerPrefs.GetInt("E" + e + "-CG");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 10;
            int damage = 11 + PlayerPrefs.GetInt("P" + p + "-INT");
            Damage(p, e, E1CHP, E1CG, damage, "Fire");
            SPSpend(p, P1CSP, P1SP, SPCost);
            for (int i = 0; i <= 3; i++)
            {
                if (PlayerPrefs.GetString("E" + e + "Status" + i) == "burning")
                {
                    Damage(p, e, E1CHP, E1CG, 10, "Explosive");
                    StatusEffect.StatusLockEnemy("burning", e);
                }
            }
            PlayerPrefs.SetInt("Processing", 1);
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    //used for default
    void None()
    {
    }

    //used for turn order
    public void ETakeTurn()
    {
        SendMessage("TakeTurn");
    }

    //used for animations
    public void EndAnimation()
    {
        Vector3 ScreenPos = new Vector3(0, -192, -100);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimation2", 0.1f);
    }
    public void EndAnimation2()
    {
        Vector3 ScreenPos = new Vector3(0, 246, -100);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimation3", 0.1f);
    }
    public void EndAnimation3()
    {
        Vector3 temp = new Vector3(-5000, 0, 0);
        GameObject animg = GameObject.Find("slasher");
        animg.transform.position = temp;
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = temp;
        InputDiss = GameObject.Find("PDiss");
        InputDiss.transform.position = temp;
        PlayerPrefs.SetInt("Processing", 0);
    }
    public void EndAnimationFire()
    {
        Vector3 ScreenPos = new Vector3(0, -192, -100);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimation2Fire", 0.1f);
    }
    public void EndAnimation2Fire()
    {
        Vector3 ScreenPos = new Vector3(0, 246, -100);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimation3Fire", 0.1f);
    }
    public void EndAnimation3Fire()
    {
        Vector3 temp = new Vector3(-5000, 0, 0);
        GameObject animg = GameObject.Find("Fire");
        animg.transform.position = temp;
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = temp;
        InputDiss = GameObject.Find("PDiss");
        InputDiss.transform.position = temp;
        PlayerPrefs.SetInt("Processing", 0);
        /*EndPlayerTurn();
        else
        {
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = temp;
            InputDiss = GameObject.Find("PDiss");
            InputDiss.transform.position = temp;
            PlayerPrefs.SetInt("Processing", 0);
        }*/
    }

    public void EndPlayerTurn()
    {
        for (int p = 1; p<=2; p++)
        {
            for (int i = 1; i <=4; i++)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("P" + p + "-Skill-" + i) + "-Played", 0);
            }
        }
        int Turns = PlayerPrefs.GetInt("Turns");
        Turns++;
        //add more for more players
        if (PlayerPrefs.GetInt("P1-CHP") <= 0)
        {
            Turns++;
        }
        if (PlayerPrefs.GetInt("P2-CHP") <= 0)
        {
            Turns++;
        }
        PlayerPrefs.SetInt("Turns", Turns);
        GameObject Backround = GameObject.Find("background");
        Backround.GetComponent<unclick>().OnMouseDown();
        if (Turns == 2)
        {
            Vector3 screenPos = new Vector3(0, 246, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = screenPos;
            StatusEffect.StatusTickEnd("P1");
            StatusEffect.StatusTickEnd("P2");
            Invoke("ETakeTurn", 0.0f);
            Turns = 0;
            PlayerPrefs.SetInt("Turns", Turns);
        }
    }

    void Miss(int e)
    {
        Vector3 loc = GameObject.Find("E" + e.ToString()).transform.localPosition;
        GameObject.Find("Miss").transform.localPosition = loc;
        Invoke("MissMove", 1.0f);
    }

    void MissMove()
    {
        GameObject.Find("Miss").transform.localPosition = new Vector3(-3000, 0, -1);
    }

    void Crit(int e)
    {
        Vector3 loc = GameObject.Find("E" + e.ToString()).transform.localPosition;
        GameObject.Find("Crit").transform.localPosition = loc;
        Invoke("CritMove", 1.0f);
    }

    void CritMove()
    {
        GameObject.Find("Crit").transform.localPosition = new Vector3(-3000, 0, -1);
    }

    public static void UltSwitch(int p)
    {
        
            int special = PlayerPrefs.GetInt("P" + p + "-SpecialMeter");
            int specialMax = PlayerPrefs.GetInt("P" + p + "-SpecialMax");
            GameObject specialMeter = GameObject.Find("Special");
            specialMeter.transform.localScale = new Vector3((float)special / (float)specialMax, 1, 1);
            if (special == specialMax)
            {
                GameObject.Find("A-Text").GetComponent<Text>().text = PlayerPrefs.GetString("P" + p + "-Ultimate");
            }
            else
            {
            GameObject.Find("A-Text").GetComponent<Text>().text = "Attack";
            }
        
    }

    public static void UltFinish(int p)
    {
        PlayerPrefs.SetInt("P" + p + "-SpecialMeter", 0);
        PlayerPrefs.SetInt("P" + p + "-SpecialMax", (int)(1.5 * PlayerPrefs.GetInt("P" + p + "-SpecialMax")));
        GameObject specialMeter = GameObject.Find("Special");
        specialMeter.transform.localScale = new Vector3(0, 1, 1);
    }

    public static void SpecialCharge(int p, int amount, string specialName)
    {
        if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == specialName)
        {
            int special = PlayerPrefs.GetInt("P" + p + "-Special");
            int specialMax = PlayerPrefs.GetInt("P" + p + "-SpecialMax");
            special += amount;
            if (special >= specialMax) { special = specialMax; }
            GameObject specialBar = GameObject.Find("Special");
            float specialPercent = (float)special / (float)specialMax;
            specialBar.transform.localScale = new Vector3(specialPercent, 1, 1);
        }
    }

    int Push(int e)
    {
        int collision = 0;
        GameObject Vill = this.gameObject;
    int loc = PlayerPrefs.GetInt("E" + e + "-Loc");
    loc = loc + 1;
        int m = PlayerPrefs.GetInt("E-Block-" + loc + "-Moveable");
        if (loc != 5 && loc != 9 && loc != 13 && loc != 17 && m == 1)
        {
            SendMessage("MoveTo", loc);
        }
        if (m == 0)
        {
            collision = 1;
        }
        return collision;
    }

    int Pull(int e)
    {
        int collision = 0;
        GameObject Vill = this.gameObject;
        int loc = PlayerPrefs.GetInt("E" + e + "-Loc");
        loc = loc - 1;
        int m = PlayerPrefs.GetInt("E-Block-" + loc + "-Moveable");
        if (loc != 0 && loc != 4 && loc != 8 && loc != 12 && m == 1)
        {
            SendMessage("MoveTo", loc);
        }
        if (m == 0)
        {
            collision = 2;
        }
        return collision;
    }

    void Collision(int e, int collision, int damage, string status, int statusX)
    {
        int loc = 0;
        if (collision == 1)
        {
            loc = PlayerPrefs.GetInt("E" + e + "-Loc") + 1;
            for (int i = 1; i <= 4; i++)
            {
                if (loc == PlayerPrefs.GetInt("E" + i + "Loc"))
                {
                    StatusEffect.InflictStatusEnemy(status, e, statusX);
                    StatusEffect.InflictStatusEnemy(status, i, statusX);
                    int e1HP = PlayerPrefs.GetInt("E" + e + "-CHP");
                    int e2HP = PlayerPrefs.GetInt("E" + i + "-CHP");
                    e1HP -= damage;
                    e2HP -= damage;
                    if (e1HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", e1HP);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = ((float)e1HP / (float)E1Max);
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + e);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                    if (e2HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", e2HP);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = ((float)e2HP / (float)E1Max);
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + i);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                }
            }
        }
        if (collision == 2)
        {
            loc = PlayerPrefs.GetInt("E" + e + "-Loc") - 1;
            for (int i = 1; i <= 4; i++)
            {
                if (loc == PlayerPrefs.GetInt("E" + i + "Loc"))
                {
                    StatusEffect.InflictStatusEnemy(status, e, statusX);
                    StatusEffect.InflictStatusEnemy(status, i, statusX);
                    int e1HP = PlayerPrefs.GetInt("E" + e + "-CHP");
                    int e2HP = PlayerPrefs.GetInt("E" + i + "-CHP");
                    e1HP -= damage;
                    e2HP -= damage;
                    if (e1HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", e1HP);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = ((float)e1HP / (float)E1Max);
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + e);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                    if (e2HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", e2HP);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = ((float)e2HP / (float)E1Max);
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + i);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                }
            }
        }
    }
}