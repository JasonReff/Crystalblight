using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTileSkills : MonoBehaviour
{
    public void OnMouseDown()
    {
        string activeSkill = PlayerPrefs.GetString("ActiveSkill");
        if (PlayerPrefs.GetString(activeSkill + "-Targeting") == "EnemyTile" || PlayerPrefs.GetString(activeSkill + "-Targeting") == "EnemyRow" || PlayerPrefs.GetString(activeSkill + "-Targeting") == "EnemyColumn")
        {
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsWhiteSpace(c)));
            Invoke(activeSkill, 0.1f);
        }
    }

    public void EnemyRow()
    {
        int clickedTile = Int32.Parse(this.name[8].ToString());
        if (GameObject.Find("E-Block-25").name != null)
        {
            if (clickedTile == 1 || clickedTile == 2 || clickedTile == 3 || clickedTile == 4 || clickedTile == 5)
            {
                PlayerPrefs.SetInt("Tile1Targeted", 1);
                PlayerPrefs.SetInt("Tile2Targeted", 1);
                PlayerPrefs.SetInt("Tile3Targeted", 1);
                PlayerPrefs.SetInt("Tile4Targeted", 1);
                PlayerPrefs.SetInt("Tile5Targeted", 1);
            }
            else if (clickedTile == 6 || clickedTile == 7 || clickedTile == 8 || clickedTile == 9 || clickedTile == 10)
            {
                PlayerPrefs.SetInt("Tile6Targeted", 1);
                PlayerPrefs.SetInt("Tile7Targeted", 1);
                PlayerPrefs.SetInt("Tile8Targeted", 1);
                PlayerPrefs.SetInt("Tile9Targeted", 1);
                PlayerPrefs.SetInt("Tile10Targeted", 1);
            }
            else if (clickedTile == 11 || clickedTile == 12 || clickedTile == 13 || clickedTile == 14 || clickedTile == 15)
            {
                PlayerPrefs.SetInt("Tile11Targeted", 1);
                PlayerPrefs.SetInt("Tile12Targeted", 1);
                PlayerPrefs.SetInt("Tile13Targeted", 1);
                PlayerPrefs.SetInt("Tile14Targeted", 1);
                PlayerPrefs.SetInt("Tile15Targeted", 1);
            }
            else if (clickedTile == 16 || clickedTile == 17 || clickedTile == 18 || clickedTile == 19 || clickedTile == 20)
            {
                PlayerPrefs.SetInt("Tile16Targeted", 1);
                PlayerPrefs.SetInt("Tile17Targeted", 1);
                PlayerPrefs.SetInt("Tile18Targeted", 1);
                PlayerPrefs.SetInt("Tile19Targeted", 1);
                PlayerPrefs.SetInt("Tile20Targeted", 1);
            }
            else if (clickedTile == 21 || clickedTile == 22 || clickedTile == 23 || clickedTile == 24 || clickedTile == 25)
            {
                PlayerPrefs.SetInt("Tile21Targeted", 1);
                PlayerPrefs.SetInt("Tile22Targeted", 1);
                PlayerPrefs.SetInt("Tile23Targeted", 1);
                PlayerPrefs.SetInt("Tile24Targeted", 1);
                PlayerPrefs.SetInt("Tile25Targeted", 1);
            }
        }
        else if (GameObject.Find("E-Block-16").name != null)
        {
            if (clickedTile == 1 || clickedTile == 2 || clickedTile == 3 || clickedTile == 4)
            {
                PlayerPrefs.SetInt("Tile1Targeted", 1);
                PlayerPrefs.SetInt("Tile2Targeted", 1);
                PlayerPrefs.SetInt("Tile3Targeted", 1);
                PlayerPrefs.SetInt("Tile4Targeted", 1);
            }
            else if (clickedTile == 5 || clickedTile == 6 || clickedTile == 7 || clickedTile == 8)
            {
                PlayerPrefs.SetInt("Tile5Targeted", 1);
                PlayerPrefs.SetInt("Tile6Targeted", 1);
                PlayerPrefs.SetInt("Tile7Targeted", 1);
                PlayerPrefs.SetInt("Tile8Targeted", 1);
            }
            else if (clickedTile == 9 || clickedTile == 10 || clickedTile == 11 || clickedTile == 12)
            {
                PlayerPrefs.SetInt("Tile9Targeted", 1);
                PlayerPrefs.SetInt("Tile10Targeted", 1);
                PlayerPrefs.SetInt("Tile11Targeted", 1);
                PlayerPrefs.SetInt("Tile12Targeted", 1);
            }
            else if (clickedTile == 13 || clickedTile == 14 || clickedTile == 15 || clickedTile == 16)
            {
                PlayerPrefs.SetInt("Tile13Targeted", 1);
                PlayerPrefs.SetInt("Tile14Targeted", 1);
                PlayerPrefs.SetInt("Tile15Targeted", 1);
                PlayerPrefs.SetInt("Tile16Targeted", 1);
            }
        }
        else
        {
            if (clickedTile == 1 || clickedTile == 2 || clickedTile == 3)
            {
                PlayerPrefs.SetInt("Tile1Targeted", 1);
                PlayerPrefs.SetInt("Tile2Targeted", 1);
                PlayerPrefs.SetInt("Tile3Targeted", 1);
            }
            else if (clickedTile == 4 || clickedTile == 5 || clickedTile == 6)
            {
                PlayerPrefs.SetInt("Tile4Targeted", 1);
                PlayerPrefs.SetInt("Tile5Targeted", 1);
                PlayerPrefs.SetInt("Tile6Targeted", 1);
            }
            else if (clickedTile == 7 || clickedTile == 8 || clickedTile == 9)
            {
                PlayerPrefs.SetInt("Tile7Targeted", 1);
                PlayerPrefs.SetInt("Tile8Targeted", 1);
                PlayerPrefs.SetInt("Tile9Targeted", 1);
            }
        }
}

    public void EnemyColumn()
    {
        int clickedTile = Int32.Parse(this.name[8].ToString());
        if (GameObject.Find("E-Block-25").name != null)
        {
            if (clickedTile == 1 || clickedTile == 6 || clickedTile == 11 || clickedTile == 16 || clickedTile == 21)
            {
                PlayerPrefs.SetInt("Tile1Targeted", 1);
                PlayerPrefs.SetInt("Tile6Targeted", 1);
                PlayerPrefs.SetInt("Tile11Targeted", 1);
                PlayerPrefs.SetInt("Tile16Targeted", 1);
                PlayerPrefs.SetInt("Tile21Targeted", 1);
            }
            else if (clickedTile == 2 || clickedTile == 7 || clickedTile == 12 || clickedTile == 17 || clickedTile == 22)
            {
                PlayerPrefs.SetInt("Tile2Targeted", 1);
                PlayerPrefs.SetInt("Tile7Targeted", 1);
                PlayerPrefs.SetInt("Tile12Targeted", 1);
                PlayerPrefs.SetInt("Tile17Targeted", 1);
                PlayerPrefs.SetInt("Tile22Targeted", 1);
            }
            else if (clickedTile == 3 || clickedTile == 8 || clickedTile == 13 || clickedTile == 18 || clickedTile == 23)
            {
                PlayerPrefs.SetInt("Tile3Targeted", 1);
                PlayerPrefs.SetInt("Tile8Targeted", 1);
                PlayerPrefs.SetInt("Tile13Targeted", 1);
                PlayerPrefs.SetInt("Tile18Targeted", 1);
                PlayerPrefs.SetInt("Tile23Targeted", 1);
            }
            else if (clickedTile == 4 || clickedTile == 9 || clickedTile == 14 || clickedTile == 19 || clickedTile == 24)
            {
                PlayerPrefs.SetInt("Tile4Targeted", 1);
                PlayerPrefs.SetInt("Tile9Targeted", 1);
                PlayerPrefs.SetInt("Tile14Targeted", 1);
                PlayerPrefs.SetInt("Tile19Targeted", 1);
                PlayerPrefs.SetInt("Tile24Targeted", 1);
            }
            else if (clickedTile == 5 || clickedTile == 10 || clickedTile == 15 || clickedTile == 20 || clickedTile == 25)
            {
                PlayerPrefs.SetInt("Tile5Targeted", 1);
                PlayerPrefs.SetInt("Tile10Targeted", 1);
                PlayerPrefs.SetInt("Tile15Targeted", 1);
                PlayerPrefs.SetInt("Tile20Targeted", 1);
                PlayerPrefs.SetInt("Tile25Targeted", 1);
            }
        }
        else if (GameObject.Find("E-Block-16").name != null)
        {
            if (clickedTile == 1 || clickedTile == 5 || clickedTile == 9 || clickedTile == 13)
            {
                PlayerPrefs.SetInt("Tile1Targeted", 1);
                PlayerPrefs.SetInt("Tile5Targeted", 1);
                PlayerPrefs.SetInt("Tile9Targeted", 1);
                PlayerPrefs.SetInt("Tile13Targeted", 1);
            }
            else if (clickedTile == 2 || clickedTile == 6 || clickedTile == 10 || clickedTile == 14)
            {
                PlayerPrefs.SetInt("Tile2Targeted", 1);
                PlayerPrefs.SetInt("Tile6Targeted", 1);
                PlayerPrefs.SetInt("Tile10Targeted", 1);
                PlayerPrefs.SetInt("Tile14Targeted", 1);
            }
            else if (clickedTile == 3 || clickedTile == 7 || clickedTile == 11 || clickedTile == 15)
            {
                PlayerPrefs.SetInt("Tile3Targeted", 1);
                PlayerPrefs.SetInt("Tile7Targeted", 1);
                PlayerPrefs.SetInt("Tile11Targeted", 1);
                PlayerPrefs.SetInt("Tile15Targeted", 1);
            }
            else if (clickedTile == 4 || clickedTile == 8 || clickedTile == 12 || clickedTile == 16)
            {
                PlayerPrefs.SetInt("Tile4Targeted", 1);
                PlayerPrefs.SetInt("Tile8Targeted", 1);
                PlayerPrefs.SetInt("Tile12Targeted", 1);
                PlayerPrefs.SetInt("Tile16Targeted", 1);
            }
        }
        else
        {
            if (clickedTile == 1 || clickedTile == 4 || clickedTile == 7)
            {
                PlayerPrefs.SetInt("Tile1Targeted", 1);
                PlayerPrefs.SetInt("Tile4Targeted", 1);
                PlayerPrefs.SetInt("Tile7Targeted", 1);
            }
            else if (clickedTile == 2 || clickedTile == 5 || clickedTile == 8)
            {
                PlayerPrefs.SetInt("Tile2Targeted", 1);
                PlayerPrefs.SetInt("Tile5Targeted", 1);
                PlayerPrefs.SetInt("Tile8Targeted", 1);
            }
            else if (clickedTile == 3 || clickedTile == 6 || clickedTile == 9)
            {
                PlayerPrefs.SetInt("Tile3Targeted", 1);
                PlayerPrefs.SetInt("Tile6Targeted", 1);
                PlayerPrefs.SetInt("Tile9Targeted", 1);
            }
        }
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

    void EndSkill(int p)
    {
        GameObject hero = GameObject.Find("P" + p);
        hero.GetComponent<SpriteRenderer>().color = Color.grey;
        PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        EndPlayerTurn();
    }

    void FastSkill(int p)
    {
        SingleTargetSkills.FastSkill(p);
    }

    void SkillReset()
    {
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
        PlayerPrefs.SetInt("PNumber", 0);
        for (int x = 1; x <= 25; x++) { PlayerPrefs.SetInt("Tile" + x + "Targeted", 0); }
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
            Invoke("ETakeTurn", 0.0f);
            Turns = 0;
            PlayerPrefs.SetInt("Turns", Turns);
        }
    }

    void AncientChampion()
    {
        int p = Target();
        EnemyColumn();
        for (int x = 1; x <= 25; x++)
        {
            if (PlayerPrefs.GetInt("Tile" + x + "Targeted") == 1)
            {
                for (int e = 1; e <= 8; e++)
                {
                    if (PlayerPrefs.GetInt("E" + e + "-Loc") == x)
                    {
                        Damage(p, e, 6 + 2 * PlayerPrefs.GetInt("P" + p + "-INT"), "Magic");
                        StatusEffect.InflictStatusEnemy("jammed", e, 2);
                    }
                }
            }
        }
        StatusEffect.InflictStatusCharacter("decoy", p, 2);
        SingleTargetSkills.SpecialCharge(p, 2, "Ancient Defender");
        EndSkill(p);
        SkillReset();
    }

}
