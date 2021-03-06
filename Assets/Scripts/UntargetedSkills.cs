using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntargetedSkills : MonoBehaviour
{
    public void OnMouseDown()
    {
        string activeSkill = PlayerPrefs.GetString("ActiveSkill");
        if (PlayerPrefs.GetString(activeSkill + "-Targeting") == "Untargeted")
        {
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsWhiteSpace(c)));
            Invoke(activeSkill, 0.1f);
        }
    }

    void Bolster()
    {
        int p = Target();
        GuardGain(p, 3 + 3 * PlayerPrefs.GetInt("P" + p + "-END"));
        SPSpend(p, 3);
        EndSkill(p);
        SkillReset();
    }

    void AetherCloak()
    {
        int p = Target();
        GuardGain(p, 5 + 2 * PlayerPrefs.GetInt("P" + p + "-END"));
        SPSpend(p, 7);
        StatusEffect.InflictStatusCharacter("ethereal", p, 2);
        EndSkill(p);
        SkillReset();
    }

    void Taunt()
    {
        int p = Target();
        GuardGain(p, 4 + 3 * PlayerPrefs.GetInt("P" + p + "-END"));
        SPSpend(p, 5);
        StatusEffect.InflictStatusCharacter("decoy", p, 1);
        SingleTargetSkills.SpecialCharge(p, 1, "Ancient Defender");
        StatusEffect.InflictStatusCharacter("steadfast", p, 1);
        EndSkill(p);
        SkillReset();
    }

    void Subjugate()
    {
        int p = Target();
        GuardGain(p, 5 * PlayerPrefs.GetInt("P" + p + "-END"));
        DamageAll(p, 20 + PlayerPrefs.GetInt("P" + p + "-STR"), "Physical");
        SPSpend(p, 26);
        EndSkill(p);
        SkillReset();
    }

    void AetherDome()
    {
        int p = Target();
        for (int p2 = 1; p2 <= 4; p2++)
        {
            if (PlayerPrefs.GetInt("P" + p2 + "-CHP") > 0)
            {
                GuardGain(p2, 5 + 3 * PlayerPrefs.GetInt("P" + p + "-END"));
            }
        }
        SPSpend(p, 18);
        EndSkill(p);
        SkillReset();
    }

    void Decoy()
    {
        int p = Target();
        SPSpend(p, 3);
        StatusEffect.InflictStatusCharacter("decoy", p, 2);
        SingleTargetSkills.SpecialCharge(p, 2, "Ancient Defender");
        EndSkill(p);
        SkillReset();
    }

    void Lambaste()
    {
        int p = Target();
        SPSpend(p, 5);
        StatusEffect.InflictStatusCharacter("decoy", p, 2);
        SingleTargetSkills.SpecialCharge(p, 2, "Ancient Defender");
        StatusEffect.InflictStatusCharacter("counter", p, 2);
        SingleTargetSkills.SpecialCharge(p, 2, "Counterstrike");
        EndSkill(p);
        SkillReset();
    }

    void SpikeShield()
    {
        int p = Target();
        SPSpend(p, 6);
        StatusEffect.InflictStatusCharacter("shield", p, 1);
        StatusEffect.InflictStatusCharacter("counter", p, 1);
        SingleTargetSkills.SpecialCharge(p, 1, "Counterstrike");
        EndSkill(p);
        SkillReset();
    }

    void StandYourGround()
    {
        int p = Target();
        SPSpend(p, 5);
        StatusEffect.InflictStatusCharacter("decoy", p, 3);
        SingleTargetSkills.SpecialCharge(p, 3, "Ancient Defender");
        StatusEffect.StatusLockCharacter("decoy", p);
        EndSkill(p);
        SkillReset();
    }

    void Riposte()
    {
        int p = Target();
        SPSpend(p, 3);
        StatusEffect.InflictStatusCharacter("counter", p, 1);
        SingleTargetSkills.SpecialCharge(p, 1, "Counterstrike");
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played") == 1)
        {
            EndSkill(p);
        }
        else
        {
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            PlayerPrefs.SetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played", 1);
        }
        SkillReset();
    }

    void GetBehindMe()
    {
        int p = Target();
        if (p != 0)
        {
            SPSpend(p, 25);
            StatusEffect.InflictStatusCharacter("decoy", p, PlayerPrefs.GetInt("P" + p + "-END"));
            SingleTargetSkills.SpecialCharge(p, PlayerPrefs.GetInt("P" + p + "-END"), "Ancient Defender");
            int loc = PlayerPrefs.GetInt("P" + p + "-Loc");
            int Coll = CollumnNumber()
            for (int q = 1; q <= 4; q++)
            {
                if (q != p)
                {
                    if ((PlayerPrefs.GetInt("P" + q + "-Loc") - 1) % 5 < (loc % Coll) - 1)
                    {
                        PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                    }
                }
            }
            EndSkill(p);
        }
        SkillReset();
    }

    void AetherField()
    {
        int p = Target();
        SPSpend(p, 10);
        for (int p2 = 1; p2 <= 4; p2++)
        {
            if (PlayerPrefs.GetString("P" + p2 + "-Name") != "null")
            {
                StatusEffect.InflictStatusCharacter("counter", p2, 1);
                SingleTargetSkills.SpecialCharge(p, 1, "Counterstrike");
            }
        }
        EndSkill(p);
        SkillReset();
    }

    void Embolden()
    {
        int p = Target();
        SPSpend(p, 18);
        StatusEffect.InflictStatusCharacter("counter", p, PlayerPrefs.GetInt("P" + p + "-END"));
        SingleTargetSkills.SpecialCharge(p, PlayerPrefs.GetInt("P" + p + "-END"), "Counterstrike");
        for (int e = 1; e <= 8; e++)
        {
            if (PlayerPrefs.GetString("E" + e + "-Name") != "null")
            {
                StatusEffect.InflictStatusEnemy("weakened", e, 2);
            }
        }
        EndSkill(p);
        SkillReset();
    }

    void ManaShell()
    {
        int p = Target();
        SPSpend(p, 16);
        StatusEffect.InflictStatusCharacter("counter", p, 3);
        SingleTargetSkills.SpecialCharge(p, 3, "Counterstrike");
        GuardGain(p, 4 * PlayerPrefs.GetInt("P" + p + "-END"));
        EndSkill(p);
        SkillReset();
    }

    void WilloftheAncients()
    {
        int p = Target();
        int decoy = 0;
        int status = 0;
        for (int i = 0; i <= 3; i++)
        {
            if (PlayerPrefs.GetString("P" + p + "Status" + i) == "decoy")
            {
                decoy = PlayerPrefs.GetInt("P" + p + "Status" + i + "X");
                status = i;
            }
        }
        PlayerPrefs.SetString("P" + p + "Status" + status, "null");
        PlayerPrefs.SetInt("P" + p + "Status" + status + "X", 0);
        GuardGain(p, 10 * decoy);
        SingleTargetSkills.UltFinish(p);
        EndSkill(p);
        SkillReset();
    }

    void EmberRain()
    {
        int p = Target();
        SPSpend(p, 4);
        for (int e = 1; e <= 8; e++)
        {
            if (PlayerPrefs.GetString("E" + e + "-Name") != "null")
            {
                StatusEffect.InflictStatusEnemy("burning", e, 2);
            }
        }
        EndSkill(p);
        SkillReset();
    }

    void HeatSeekers()
    {
        int p = Target();
        for (int x = 1; x <= 2; x++)
        {
            int e = RandomEnemy();
            int damage = 7 + PlayerPrefs.GetInt("P" + p + "-INT");
            Damage(p, e, damage, "Fire");
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
        }
        SPSpend(p, 6);
        EndSkill(p);
        SkillReset();
    }

    void Inferno()
    {
        int p = Target();
        SPSpend(p, 20);
        DamageAll(p, 25 + 3 * PlayerPrefs.GetInt("P" + p + "-INT"), "Fire");
        StatusEffect.InflictStatusCharacter("burning", p, 3);
        EndSkill(p);
        SkillReset();
    }

    void EndSkill(int p)
    {
        GameObject hero = GameObject.Find("P" + p);
        hero.GetComponent<SpriteRenderer>().color = Color.grey;
        PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        EndPlayerTurn();
    }

    void SkillReset()
    {
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
        PlayerPrefs.SetInt("PNumber", 0);
    }

    void GuardGain(int p, int guardGain)
    {
        int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
        int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
        if (guardGain > (p1MaxGuard - p1CG)) { guardGain = p1MaxGuard - p1CG; }
        p1CG += guardGain;
        if (p1CG >= p1MaxGuard)
        {
            p1CG = p1MaxGuard;
        }
        PlayerPrefs.SetInt("P" + p + "-CG", p1CG);
        SingleTargetSkills.SpecialCharge(p, guardGain, "Iron Will");
        PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + guardGain);
        GameObject GBar = GameObject.Find("P" + p + "-Guard");
        float PercentG = ((float)p1CG / (float)p1MaxGuard);
        GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
    }

    void DamageAll(int p, int attack, string damageType)
    {
        for (int e = 1; e <= 8; e++)
        {
            if (PlayerPrefs.GetInt("E" + e + "-CHP") > 0)
            {
                Damage(p, e, attack, damageType);
            }
        }
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
    void SPSpend(int p, int SPCost)
    {
        int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
        int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
        P1CSP = P1CSP - SPCost;
        if (P1CSP < 0) { P1CSP = 0; }
        PlayerPrefs.SetInt("P" + p + "-CSP", P1CSP);
        float PercentSP = ((float)P1CSP / (float)P1SP);
        GameObject SPBar = GameObject.Find("P" + p + "-Sp");
        SPBar.gameObject.transform.localScale = new Vector3(PercentSP, 1, 1);
    }

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

    void Damage(int p, int e, int Att, string damageType)
    {
        SingleTargetSkills singleTargetSkills = GameObject.Find("E1").GetComponent<SingleTargetSkills>();
        singleTargetSkills.Damage(p, e, Att, damageType);
    }

    public void ETakeTurn()
    {
        GameObject.Find("E1").GetComponent<E1>().TakeTurn();
    }

    public int CollumnNumber()
    {
        if (GameObject.Find("P" + p + "-Block-25").name != null)
        {
            return 5;
        }
        else if (GameObject.Find("P" + p + "-Block-16").name != null)
        {
            return 4;
        }
        else
        {
            return 3;
        }
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
    }

    void EndPlayerTurn()
    {
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

    void FastSkill(int p)
    {
        SingleTargetSkills.FastSkill(p);
    }
}
