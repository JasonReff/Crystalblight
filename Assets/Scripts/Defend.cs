using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Defend : MonoBehaviour
{
    public Enemy e1;
    public GameObject shield;
    public GameObject Bar;
    public Text textbox;
    public GameObject InputDiss;
    //defend does not work right now
    void OnMouseDown()
    {
        PlayerPrefs.SetInt("Clicked", 0);
        int p = Clicked();
        PlayerPrefs.SetInt("Processing", 1);
        GameObject hero = GameObject.Find("P" + p);
        hero.GetComponent<SpriteRenderer>().color = Color.grey;
        GameObject charstatbox = GameObject.Find("CharStatBox");
        charstatbox.GetComponent<Text>().text = "";
        int PCurrentGuard = PlayerPrefs.GetInt("P" + p + "-CG");
        int PMaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
        int PAddedGuard = 2 * PlayerPrefs.GetInt("P" + p + "-END");
        PCurrentGuard += PAddedGuard;
        if (PCurrentGuard > PMaxGuard)
        {
            PCurrentGuard = PMaxGuard;
        }
        SingleTargetSkills.SpecialCharge(p, PAddedGuard, "Iron Will");
        PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + PAddedGuard);
        GameObject GBar = GameObject.Find("P" + p + "-Guard");
        float PercentG = ((float)PCurrentGuard / (float)PMaxGuard);
        GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
        PlayerPrefs.SetInt("P" + p + "-CG", PCurrentGuard);
        StatusEffect.InflictStatusCharacter("steadfast", p, 1);
        PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
        for (int i = 0; i <= 3; i++)
        {
            if (PlayerPrefs.GetString("P" + p + "Status" + i) == "burning")
            {
                PlayerPrefs.SetString("P" + p + "Status" + i, "null");
                PlayerPrefs.SetInt("P" + p + "Status" + i + "X", 0);
            }
        }
        if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Iron Will1")
        {
            int e = RandomEnemy();
            Damage(p, e, PlayerPrefs.GetInt("E" + e + "-CHP"), PlayerPrefs.GetInt("E" + e + "-CG"), 3, "Magic");
        }
        else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Iron Will2")
        {
            int e = RandomEnemy();
            Damage(p, e, PlayerPrefs.GetInt("E" + e + "-CHP"), PlayerPrefs.GetInt("E" + e + "-CG"), 5, "Magic");
        }
        else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Iron Will3")
        {
            int e = RandomEnemy();
            Damage(p, e, PlayerPrefs.GetInt("E" + e + "-CHP"), PlayerPrefs.GetInt("E" + e + "-CG"), 8, "Magic");
        }
        else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Counterstrike2")
        {
            int e = RandomEnemy();
            StatusEffect.InflictStatusEnemy("alarm", e, 1);
        }
        else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Counterstrike3")
        {
            int e = RandomEnemy();
            StatusEffect.InflictStatusEnemy("alarm", e, 2);
        }
        EndPlayerTurn();
    }

    public void EndPlayerTurn()
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
            e1.TakeTurn();
            Turns = 0;
            PlayerPrefs.SetInt("Turns", Turns);
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

    void Damage(int p, int e, int E1CHP, int E1CG, int Att, string damageType)
    {
        if (PlayerPrefs.GetString("E" + e + "-Weakness1") == damageType || PlayerPrefs.GetString("E" + e + "-Weakness2") == damageType)
        {
            Att = (int)Math.Round((float)Att * 1.5, 1);
        }
        if (PlayerPrefs.GetString("E" + e + "-Resistance1") == damageType || PlayerPrefs.GetString("E" + e + "-Resistance2") == damageType || PlayerPrefs.GetString("E" + e + "-Resistance3") == damageType)
        {
            Att = (int)Math.Round((float)Att * 0.75, 1);
        }
        if (PlayerPrefs.GetString("E" + e + "Status0") == "steadfast" || PlayerPrefs.GetString("E" + e + "Status1") == "steadfast" || PlayerPrefs.GetString("E" + e + "Status2") == "steadfast" || PlayerPrefs.GetString("E" + e + "Status3") == "steadfast")
        {
            E1CG -= Att;
        }
        else
        { E1CG = E1CG - ((Att / 2) + (Att % 2)); }
        if (E1CG < 0)
        {
            E1CHP = E1CHP + E1CG;
            E1CG = 0;
        }
        E1CHP = E1CHP - Att / 2;
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
    public int Clicked()
    {
        int p = 0;
        if (PlayerPrefs.GetInt("P1-Clicked") == 1)
        {
            p = 1;
            PlayerPrefs.SetInt("P1-Clicked", 0);
        }
        else if (PlayerPrefs.GetInt("P2-Clicked") == 1)
        {
            p = 2;
            PlayerPrefs.SetInt("P2-Clicked", 0);
        }
        else if (PlayerPrefs.GetInt("P3-Clicked") == 1)
        {
            p = 3;
            PlayerPrefs.SetInt("P3-Clicked", 0);
        }
        else if (PlayerPrefs.GetInt("P4-Clicked") == 1)
        {
            p = 4;
            PlayerPrefs.SetInt("P4-Clicked", 0);
        }
        return p;
    }
    public void EndAnimation()
    {
        Vector3 temp = new Vector3(-3000, 0, 0);
        shield.transform.position = temp;
    }
}