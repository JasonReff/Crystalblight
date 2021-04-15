using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyTargetSkills : MonoBehaviour
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
            }
        }
    }

    public void OnMouseDown()
    {
        string activeSkill = PlayerPrefs.GetString("ActiveSkill");
        if (PlayerPrefs.GetString(activeSkill + "-Targeting") == "FriendlyTarget")
        {
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsWhiteSpace(c)));
            Invoke(activeSkill, 0.1f);
        }
    }

    void Damage(int p, int e, int E1CHP, int E1CG, int Att, string damageType)
    {
        //accuracyCheck
        int accuracyCheck = UnityEngine.Random.Range(1, 101);
        if (PlayerPrefs.GetInt("P" + p + "-Accuracy") - PlayerPrefs.GetInt("E" + e + "-Dodge") < accuracyCheck)
        {
            Miss(e);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            PlayerPrefs.SetString("ActiveSkill", "None");
            PlayerPrefs.SetInt("ENumber", 0);
            EndPlayerTurn();
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
            if (PlayerPrefs.GetInt("P" + p + "-CritRate") < critCheck)
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
        for (int p = 1; p <= 2; p++)
        {
            for (int i = 1; i <= 4; i++)
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

    void SpecialCheck(int amount, string special)
    {
        for (int i = 1; i <= 4; i++)
        {
            switch (special)
            {
                case "Bloodlust":
                    {
                        int specialMeter = PlayerPrefs.GetInt("P" + i + "-SpecialMeter");
                        int newSpecial = specialMeter + amount;
                        if (newSpecial >= PlayerPrefs.GetInt("P" + i + "-SpecialMax"))
                        {
                            newSpecial += PlayerPrefs.GetInt("P" + i + "-SpecialMax");
                        }
                        PlayerPrefs.SetInt("P" + i + "-SpecialMeter", specialMeter);
                        GameObject.Find("P" + i + "-SpecialMeter").transform.localScale = new Vector3((float)newSpecial / (float)specialMeter, 1, 1);
                        break;
                    }
                case "Poisoner":
                    {
                        break;
                    }
            }
        }
    }

    public int PassiveSkillCheck(string status, int p, int statusX)
    {
        if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Poisoner1" && status == "poison")
        {
            statusX++;
        }
        return statusX;
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