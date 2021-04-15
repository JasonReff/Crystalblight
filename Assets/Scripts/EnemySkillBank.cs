using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillBank : MonoBehaviour
{
    //this script acts as a skill bank for all enemy skills, to be called by other enemy scripts
    public void Stab()
    {
        Damage(16, "Physical");
    }
    public void Hammer()
    {
        Damage(15, "Explosive");
        SplashDamage(15, "Explosive");
    }
    public void FireBreath()
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        int p = PlayerPrefs.GetInt("E" + eNumber + "-AttP");
        StatusEffect.InflictStatusCharacter("burning", p, 5);
        Adjacency(p, PlayerPrefs.GetInt("P" + p + "-Loc"));
        SplashStatus(p, PlayerPrefs.GetInt("P" + p + "-Loc"), "burning", 3);
    }
    public void Dream()
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        int p = PlayerPrefs.GetInt("E" + eNumber + "-AttP");
        StatusEffect.InflictStatusCharacter("poison", p, 5);
        StatusEffect.InflictStatusCharacter("vulnerable", p, 3);
    }
    public void Hex()
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        int p = PlayerPrefs.GetInt("E" + eNumber + "-AttP");
        Damage(10, "Magic");
        StatusEffect.InflictStatusCharacter("vulnerable", p, 3);
    }

    public void Grow()
    {
        Summon("Crystal Grub");
    }
    void Damage(int Att, string damageType)
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        GameObject target = GameObject.Find(PlayerPrefs.GetString("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-Name"));
        GameObject targetHP = GameObject.Find("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-Hp");
        GameObject targetG = GameObject.Find("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-Guard");
        int p = PlayerPrefs.GetInt("E" + eNumber + "-AttP");
        int PCHP = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CHP");
        int PCG = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CG");
        if (PlayerPrefs.GetString("P" + p + "-Weakness1") == damageType || PlayerPrefs.GetString("P" + p + "-Weakness2") == damageType)
        {
            Att = (int)Math.Round((float)Att * 1.5, 1);
        }
        if (PlayerPrefs.GetString("P" + p + "-Resistance1") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance2") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance3") == damageType)
        {
            Att = (int)Math.Round((float)Att * 0.75, 1);
        }
        if (PlayerPrefs.GetString("P" + p + "Status0") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status1") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status2") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status3") == "steadfast")
        {
            PCG -= Att;
        }
        else if (PlayerPrefs.GetString("P" + p + "Status0") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status1") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status2") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status3") == "vulnerable")
        {
            PCHP -= Att;
        }
        else
        {
            PCG = PCG - ((Att / 2) + (Att % 2));
            PCHP = PCHP - ((Att / 2));
        }
        if (PCG < 0)
        {
            PCHP = PCHP + PCG;
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CG", 0);
            PCG = 0;
        }
        else
        {
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CG", PCG);
        }
        if (PCHP <= 0)
        {
            target.GetComponent<SpriteRenderer>().color = Color.black;
            if (PlayerPrefs.GetInt("P1-CHP") == 0 && PlayerPrefs.GetInt("P2-CHP") == 0)
            {
                Application.LoadLevel("GameOver");
            }
            PCHP = 0;
        }
        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CHP", PCHP);
        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CG", PCG);
        int PMax = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-HP");
        float Percent = ((float)PCHP / (float)PMax);
        targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        PMax = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-Guard");
        Percent = ((float)PCG / (float)PMax);
        targetG.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
    }
    void SplashDamage(int Att, string damageType)
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        int p = PlayerPrefs.GetInt("E" + eNumber + "-AttP");
        int loc = PlayerPrefs.GetInt("P" + p + "-Loc");
        GameObject target = GameObject.Find(PlayerPrefs.GetString("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-Name"));
        Adjacency(p, loc);
        for (int i = 1; i <= 4; i++)
        {
            if (PlayerPrefs.GetInt("P" + i + "-Adjacency") == 1)
            {
                int PCHP = PlayerPrefs.GetInt("P" + i + "-CHP");
                int PCG = PlayerPrefs.GetInt("P" + i + "-CG");
                damageType = "Explosive";
                int AttDamage = Att;
                if (PlayerPrefs.GetString("P" + p + "-Weakness1") == damageType || PlayerPrefs.GetString("P" + p + "-Weakness2") == damageType)
                {
                    AttDamage = (int)Math.Round((float)Att * 1.5, 1);
                }
                if (PlayerPrefs.GetString("P" + p + "-Resistance1") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance2") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance3") == damageType)
                {
                    AttDamage = (int)Math.Round((float)Att * 0.75, 1);
                }
                if (PlayerPrefs.GetString("P" + p + "Status0") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status1") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status2") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status3") == "steadfast")
                {
                    PCG -= AttDamage;
                }
                else if (PlayerPrefs.GetString("P" + p + "Status0") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status1") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status2") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status3") == "vulnerable")
                {
                    PCHP -= AttDamage;
                }
                else
                {
                    PCG = PCG - ((AttDamage / 2) + (AttDamage % 2));
                    PCHP = PCHP - ((AttDamage / 2));
                }
                if (PCG < 0)
                {
                    PCHP = PCHP + PCG;
                    PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CG", 0);
                    PCG = 0;
                }
                else
                {
                    PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E" + eNumber + "-AttP") + "-CG", PCG);
                }
                if (PCHP <= 0)
                {
                    target.GetComponent<SpriteRenderer>().color = Color.black;
                    if (PlayerPrefs.GetInt("P1-CHP") == 0 && PlayerPrefs.GetInt("P2-CHP") == 0)
                    {
                        Application.LoadLevel("GameOver");
                    }
                    PCHP = 0;
                }
                PlayerPrefs.SetInt("P" + i + "-CHP", PCHP);
                PlayerPrefs.SetInt("P" + i + "-CG", PCG);
                int PMax = PlayerPrefs.GetInt("P" + i + "-HP");
                float Percent = ((float)PCHP / (float)PMax);
                GameObject targetHP = GameObject.Find("P" + i + "-Hp");
                targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
                PMax = PlayerPrefs.GetInt("P" + i + "-Guard");
                Percent = ((float)PCG / (float)PMax);
                GameObject targetG = GameObject.Find("P" + i + "-Guard");
                targetG.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
            }
        }
    }
    void SplashStatus(int p, int loc, string status, int statusX)
    {
        Adjacency(p, loc);
        for (int i = 1; i<=4; i++)
        {
            if (PlayerPrefs.GetInt("P" + i + "-Adjacency") == 1)
            {
                StatusEffect.InflictStatusCharacter(status, i, statusX);
            }
        }
    }

    void Adjacency(int p, int loc)
    {
        int pLoc = PlayerPrefs.GetInt("P" + p + "-Loc");
        if (pLoc == 1)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 5 || pLoc == 9)
        {
            for (int i = 1; i<=4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 4 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc-4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 13)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 4)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 4)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 8 || pLoc == 12)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 4 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 16)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 2 || pLoc == 3)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else if (pLoc == 14 || pLoc == 15)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
        else
        {
            for (int i = 1; i <= 4; i++)
            {
                if (PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 1 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc - 4 || PlayerPrefs.GetInt("P" + i + "-Loc") == pLoc + 4)
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("P" + i + "-Adjacency", 0);
                }
            }
        }
    }

    void Summon(string summonName)
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        int loc = PlayerPrefs.GetInt("E" + eNumber + "-Loc");
        int newENumber;
        int enemyLimit = 0;
        for (int i = 1; i <= 8; i++)
        {
            if (PlayerPrefs.GetString("E" + i + "-Name") != "null")
            {
                enemyLimit++;
            }
        }
        if (enemyLimit == 8)
        {

        }
        else
        {
            do
            {
                newENumber = UnityEngine.Random.Range(1, 9);
            }
            while (GameObject.Find("E" + newENumber.ToString()).name != "null");
            int random = UnityEngine.Random.Range(1, 5);
            if (random == 1 && PlayerPrefs.GetInt("E-Block-" + (loc - 1) + "-Moveable") == 1)
            {
                GameObject summon = GameObject.Find("E" + newENumber.ToString());
                LoadSprite.FindSprite(summon, summonName);
                PlayerPrefs.SetString("E" + newENumber + "-Name", summonName);
                summon.GetComponent<ESummon>().SetLoc(loc - 1);
            }
            else if (random == 2 && PlayerPrefs.GetInt("E-Block-" + (loc + 4) + "-Moveable") == 1)
            {
                GameObject summon = GameObject.Find("E" + newENumber.ToString());
                LoadSprite.FindSprite(summon, summonName);
                PlayerPrefs.SetString("E" + newENumber + "-Name", summonName);
                summon.GetComponent<ESummon>().SetLoc(loc + 4);
            }
            else if (random == 3 && PlayerPrefs.GetInt("E-Block-" + (loc - 4) + "-Moveable") == 1)
            {
                GameObject summon = GameObject.Find("E" + newENumber.ToString());
                LoadSprite.FindSprite(summon, summonName);
                PlayerPrefs.SetString("E" + newENumber + "-Name", summonName);
                summon.GetComponent<ESummon>().SetLoc(loc - 4);
            }
            else if (random == 4 && PlayerPrefs.GetInt("E-Block-" + (loc + 1) + "-Moveable") == 1)
            {
                GameObject summon = GameObject.Find("E" + newENumber.ToString());
                LoadSprite.FindSprite(summon, summonName);
                PlayerPrefs.SetString("E" + newENumber + "-Name", summonName);
                summon.GetComponent<ESummon>().SetLoc(loc + 1);
            }
            else
            {

            }
        }
    }
}
