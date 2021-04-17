using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntargetedSkills : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
            int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int guardGain = 3 + 3 * PlayerPrefs.GetInt("P" + p + "-END");
            if (guardGain > (p1MaxGuard - p1CG)) { guardGain = p1MaxGuard - p1CG; }
            p1CG += guardGain;
            if (p1CG >= p1MaxGuard)
            {
                p1CG = p1MaxGuard;
            }
            PlayerPrefs.SetInt("P" + p + "-CG", p1CG);
            GameObject GBar = GameObject.Find("P" + p + "-Guard");
            float PercentG = ((float)p1CG / (float)p1MaxGuard);
            GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
            SPSpend(p, P1CSP, P1SP, 3);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void AetherCloak()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
            int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int guardGain = 5 + 2 * PlayerPrefs.GetInt("P" + p + "-END");
            if (guardGain > (p1MaxGuard - p1CG)) { guardGain = p1MaxGuard - p1CG; }
            p1CG += guardGain;
            if (p1CG >= p1MaxGuard)
            {
                p1CG = p1MaxGuard;
            }
            PlayerPrefs.SetInt("P" + p + "-CG", p1CG);
            GameObject GBar = GameObject.Find("P" + p + "-Guard");
            float PercentG = ((float)p1CG / (float)p1MaxGuard);
            GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
            SPSpend(p, P1CSP, P1SP, 7);
            StatusEffect.InflictStatusCharacter("ethereal", p, 2);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Taunt()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
            int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int guardGain = 4 + 3 * PlayerPrefs.GetInt("P" + p + "-END");
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
            SPSpend(p, P1CSP, P1SP, 5);
            StatusEffect.InflictStatusCharacter("decoy", p, 1);
            SingleTargetSkills.SpecialCharge(p, 1, "Ancient Defender");
            StatusEffect.InflictStatusCharacter("steadfast", p, 1);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Subjugate()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int guard = PlayerPrefs.GetInt("P" + p + "-CG");
            int maxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int guardGain = 5 * PlayerPrefs.GetInt("P" + p + "-END");
            if (guardGain > (maxGuard - guard)) { guardGain = maxGuard - guard; }
            guard += guardGain;
            if (guard >= maxGuard)
            {
                guard = maxGuard;
            }
            SingleTargetSkills.SpecialCharge(p, guardGain, "Iron Will");
            PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + guardGain);
            GameObject guardBar = GameObject.Find("P" + p + "-Guard");
            float percent = (float)guard / (float)maxGuard;
            guardBar.transform.localScale = new Vector3(percent, 1, 1);
            DamageAll(p, 20 + PlayerPrefs.GetInt("P" + p + "-STR"), "Physical");
            SPSpend(p, P1CSP, P1SP, 26);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void AetherDome()
    {
        int playerCharacter = Target();
        if (playerCharacter != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            GameObject hero = GameObject.Find("P" + playerCharacter);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            for (int p = 1; p <= 4; p++)
            {
                if (PlayerPrefs.GetInt("P" + p + "-CHP") > 0)
                {
                    int guard = PlayerPrefs.GetInt("P" + p + "-CG");
                    int maxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
                    int guardGain = 5 + 3 * PlayerPrefs.GetInt("P" + playerCharacter + "-END");
                    if (guardGain > (maxGuard - guard)) { guardGain = maxGuard - guard; }
                    guard += guardGain;
                    if (guard > maxGuard)
                    {
                        guard = maxGuard;
                    }
                    SingleTargetSkills.SpecialCharge(p, guardGain, "Iron Will");
                    PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + guardGain);
                    GameObject guardBar = GameObject.Find("P" + p + "-Guard");
                    float percent = (float)guard / (float)maxGuard;
                    guardBar.transform.localScale = new Vector3(percent, 1, 1);
                }
            }
            int P1CSP = PlayerPrefs.GetInt("P" + playerCharacter + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + playerCharacter + "-SP");
            SPSpend(playerCharacter, P1CSP, P1SP, 18);
            PlayerPrefs.SetInt("P" + playerCharacter + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Decoy()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 3);
            StatusEffect.InflictStatusCharacter("decoy", p, 2);
            SingleTargetSkills.SpecialCharge(p, 2, "Ancient Defender");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Lambaste()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 5);
            StatusEffect.InflictStatusCharacter("decoy", p, 2);
            SingleTargetSkills.SpecialCharge(p, 2, "Ancient Defender");
            StatusEffect.InflictStatusCharacter("counter", p, 2);
            SingleTargetSkills.SpecialCharge(p, 2, "Counterstrike");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void SpikeShield()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 6);
            StatusEffect.InflictStatusCharacter("shield", p, 1);
            StatusEffect.InflictStatusCharacter("counter", p, 1);
            SingleTargetSkills.SpecialCharge(p, 1, "Counterstrike");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void StandYourGround()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            int SPCost = 5;
            SPSpend(p, P1CSP, P1SP, SPCost);
            StatusEffect.InflictStatusCharacter("decoy", p, 3);
            SingleTargetSkills.SpecialCharge(p, 3, "Ancient Defender");
            StatusEffect.StatusLockCharacter("decoy", p);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Riposte()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 3);
            StatusEffect.InflictStatusCharacter("counter", p, 1);
            SingleTargetSkills.SpecialCharge(p, 1, "Counterstrike");
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
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

    void GetBehindMe()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 25);
            StatusEffect.InflictStatusCharacter("decoy", p, PlayerPrefs.GetInt("P" + p + "-END"));
            SingleTargetSkills.SpecialCharge(p, PlayerPrefs.GetInt("P" + p + "-END"), "Ancient Defender");
            int loc = PlayerPrefs.GetInt("P" + p + "-Loc");
            if (GameObject.Find("P" + p + "-Block-25").name != null)
            {
                if (loc == 1 || loc == 6 || loc == 11 || loc == 16 || loc == 21)
                {

                }
                else if (loc == 2 || loc == 7 || loc == 12 || loc == 17 || loc == 22)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 6 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 11 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 16 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 21)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
                else if (loc == 3 || loc == 8 || loc == 13 || loc == 18 || loc == 23)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 2 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 6 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 7 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 11 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 12 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 16 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 17 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 21 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 22)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
                else if (loc == 4 || loc == 9 || loc == 14 || loc == 19 || loc == 24)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 2 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 3 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 6 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 7 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 8 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 11 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 12 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 13 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 16 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 17 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 18 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 21 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 22 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 23)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
                else if (loc == 5 || loc == 10 || loc == 15 || loc == 20 || loc == 25)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 2 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 3 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 4 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 6 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 7 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 8 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 9 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 11 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 12 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 13 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 14 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 16 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 17 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 18 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 19 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 21 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 22 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 23 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 24)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
            }
            else if (GameObject.Find("P" + p + "-Block-16") != null)
            {
                if (loc == 1 || loc == 5 || loc == 9 || loc == 13)
                {

                }
                else if (loc == 2 || loc == 6 || loc == 10 || loc == 14)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 5 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 9 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 13)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
                else if (loc == 3 || loc == 7 || loc == 11 || loc == 15)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 2 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 5 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 6 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 9 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 10 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 13 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 14)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
                else if (loc == 4 || loc == 8 || loc == 12 || loc == 16)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 2 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 3 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 5 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 6 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 7 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 9 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 10 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 11 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 13 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 14 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 15)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
            }
            else
            {
                if (loc == 1 || loc == 4 || loc == 7)
                {

                }
                else if (loc == 2 || loc == 5 || loc == 8)
                {
                    for (int q = 1; q <= 4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 4 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 7)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
                else if (loc == 3 || loc == 6 || loc == 9)
                {
                    for (int q = 1; q <=4; q++)
                    {
                        if (q != p)
                        {
                            if (PlayerPrefs.GetInt("P" + q + "-Loc") == 1 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 2 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 4 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 5 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 7 ||
                                PlayerPrefs.GetInt("P" + q + "-Loc") == 8)
                            {
                                PlayerPrefs.SetInt("P" + q + "CombatSTRGained", PlayerPrefs.GetInt("P" + q + "CombatSTRGained") + 3);
                            }
                        }
                    }
                }
            }
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void AetherField()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 10);
            for (int p2 = 1; p2 <= 4; p2++)
            {
                if (PlayerPrefs.GetString("P" + p2 + "-Name") != "null")
                {
                    StatusEffect.InflictStatusCharacter("counter", p2, 1);
                    SingleTargetSkills.SpecialCharge(p, 1, "Counterstrike");
                }
            }
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Embolden()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 18);
            StatusEffect.InflictStatusCharacter("counter", p, PlayerPrefs.GetInt("P" + p + "-END"));
            SingleTargetSkills.SpecialCharge(p, PlayerPrefs.GetInt("P" + p + "-END"), "Counterstrike");
            for (int e = 1; e <= 8; e++)
            {
                if (PlayerPrefs.GetString("E" + e + "-Name") != "null")
                {
                    StatusEffect.InflictStatusEnemy("weakened", e, 2);
                }
            }
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void ManaShell()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 16);
            StatusEffect.InflictStatusCharacter("counter", p, 3);
            SingleTargetSkills.SpecialCharge(p, 3, "Counterstrike");
            int guard = PlayerPrefs.GetInt("P" + p + "-CG");
            int maxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int guardGain = 4 * PlayerPrefs.GetInt("P" + p + "-END");
            if (guardGain > (maxGuard - guard)) { guardGain = maxGuard - guard; }
            guard += guardGain;
            if (guard > maxGuard)
            {
                guard = maxGuard;
            }
            SingleTargetSkills.SpecialCharge(p, guardGain, "Iron Will");
            PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + guardGain);
            GameObject guardBar = GameObject.Find("P" + p + "-Guard");
            float percent = (float)guard / (float)maxGuard;
            guardBar.transform.localScale = new Vector3(percent, 1, 1);
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void WilloftheAncients()
    {
        int p = Target();
        if (p != 0)
        {
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
            int guard = PlayerPrefs.GetInt("P" + p + "-CG");
            int maxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
            int guardGain = 10 * decoy;
            if (guardGain > maxGuard - guard) { guardGain = maxGuard - guard; }
            guard += guardGain;
            PlayerPrefs.SetInt("P" + p + "-CG", guard);
            PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + guardGain);
            GameObject guardBar = GameObject.Find("P" + p + "-Guard");
            float percent = (float)guard / (float)maxGuard;
            guardBar.transform.localScale = new Vector3(percent, 1, 1);
            SingleTargetSkills.UltFinish(p);
        }
    }

    void EmberRain()
    {
        int p = Target();
        if (p != 0)
        {
            GameObject hero = GameObject.Find("P" + p);
            int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
            int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
            SPSpend(p, P1CSP, P1SP, 4);
            for (int e = 1; e <= 8; e++)
            {
                if (PlayerPrefs.GetString("E" + e + "-Name") != "null")
                {
                    StatusEffect.InflictStatusEnemy("burning", e, 2);
                }
            }
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void HeatSeekers()
    {
        int p = Target();
        if (p != 0)
        {
            for (int x = 1; x <=2; x++)
            {
                int e = RandomEnemy();
                int e1CHP = PlayerPrefs.GetInt("E" + e + "-CHP");
                int e1CG = PlayerPrefs.GetInt("E" + e + "-CG");
                int damage = 7 + PlayerPrefs.GetInt("P" + p + "-INT");
                Damage(p, e, e1CHP, e1CG, damage, "Fire");
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
            SPSpend(p, PlayerPrefs.GetInt("P" + p + "-CSP"), PlayerPrefs.GetInt("P" + p + "-SP"), 6);
            GameObject hero = GameObject.Find("P" + p);
            hero.GetComponent<SpriteRenderer>().color = Color.grey;
            PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
            EndPlayerTurn();
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void Inferno()
    {
        int p = Target();
        if (p != 0)
        {
            int damage = 25 + 3 * PlayerPrefs.GetInt("P" + p + "-INT");
            SPSpend(p, PlayerPrefs.GetInt("P" + p + "-CSP"), PlayerPrefs.GetInt("P" + p + "-SP"), 20);
            DamageAll(p, damage, "Fire");
            StatusEffect.InflictStatusCharacter("burning", p, 3);
            EndSkill(p);
        }
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
    }

    void EndSkill(int p)
    {
        GameObject hero = GameObject.Find("P" + p);
        hero.GetComponent<SpriteRenderer>().color = Color.grey;
        PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        EndPlayerTurn();
    }

    void DamageAll(int p, int attack, string damageType)
    {
        for (int e = 1; e <= 8; e++)
        {
            if (PlayerPrefs.GetInt("E" + e + "-CHP") > 0)
            {
                Damage(p, e, PlayerPrefs.GetInt("E" + e + "-CHP"), PlayerPrefs.GetInt("E" + e + "-CG"), attack, damageType);
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
    void SPSpend(int p, int P1CSP, int P1SP, int SPCost)
    {
        P1CSP = P1CSP - SPCost;
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

    void Damage(int p, int e, int E1CHP, int E1CG, int Att, string damageType)
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

    public void ETakeTurn()
    {
        GameObject.Find("E1").GetComponent<E1>().TakeTurn();
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

    public int PassiveSkillCheck(string status, int p, int statusX)
    {
        if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Poisoner1" && status == "poison")
        {
            statusX++;
        }
        return statusX;
    }
}
