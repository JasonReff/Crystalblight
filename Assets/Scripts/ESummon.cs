using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESummon : MonoBehaviour
{

public void SetLoc(int loc)
    {
        GetStats();
        int eNumber = Int32.Parse(this.name[1].ToString());
        PlayerPrefs.SetInt("E" + eNumber + "-Loc", loc);
        GameObject Vill = GameObject.Find("E" + eNumber + "");
        string e1Name = PlayerPrefs.GetString("E" + eNumber + "-Name");
        LoadSprite.FindSprite(Vill, e1Name);
        GameObject VillHp = GameObject.Find("E" + eNumber + "-Hp");
        GameObject VillHpBack = GameObject.Find("E" + eNumber + "-HpBack");
        GameObject VillGuard = GameObject.Find("E" + eNumber + "-Guard");
        GameObject VillStatus0 = GameObject.Find("E" + eNumber + "Status0");
        GameObject VillStatus0X = GameObject.Find("E" + eNumber + "Status0X");
        Vector3 E1LocQuards = GameObject.Find("E-Block-" + loc.ToString()).transform.position;
        Vill.transform.position = E1LocQuards + new Vector3(0, +67, -3);
        SpriteRenderer sprite = Vill.GetComponent<SpriteRenderer>();
        int l = loc + 4;
        l = l / 4;
        sprite.sortingLayerName = "Char" + l;
        VillHp.transform.position = E1LocQuards + new Vector3(-100, -17, 1);
        VillHp = VillHp.transform.GetChild(0).gameObject;
        sprite = VillHp.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Bar" + l;
        VillHpBack.transform.position = E1LocQuards + new Vector3(0, -17, 1);
        sprite = VillHpBack.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Back" + l;
        VillStatus0.transform.position = E1LocQuards + new Vector3(-40, 20, 1);
        sprite = VillStatus0.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Status" + 1;
        VillStatus0X.transform.position = E1LocQuards + new Vector3(-40, 20, 1);
        VillGuard.transform.position = E1LocQuards + new Vector3(-100, -17, 1);
        VillGuard = VillGuard.transform.GetChild(0).gameObject;
        sprite = VillGuard.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Guard" + l;
    }

    public void GetStats()
    {
        int eNumber = Int32.Parse(this.name[1].ToString());
        string eName = PlayerPrefs.GetString("E" + eNumber + "-Name");
        PlayerPrefs.SetString("E" + eNumber + "-Name", eName);
        PlayerPrefs.SetInt("E" + eNumber + "-CHP", PlayerPrefs.GetInt(eName + "-CHP"));
        PlayerPrefs.SetInt("E" + eNumber + "-HP", PlayerPrefs.GetInt(eName + "-HP"));
        PlayerPrefs.SetInt("E" + eNumber + "-CG", PlayerPrefs.GetInt(eName + "-CG"));
        PlayerPrefs.SetInt("E" + eNumber + "-Guard", PlayerPrefs.GetInt(eName + "-Guard"));
        PlayerPrefs.SetInt("E" + eNumber + "-Set", 1);
        PlayerPrefs.SetString("E" + eNumber + "Status0", PlayerPrefs.GetString(eName + "Status0"));
        PlayerPrefs.SetInt("E" + eNumber + "Status0X", PlayerPrefs.GetInt(eName + "Status0X"));
        PlayerPrefs.SetString("E" + eNumber + "Status1", PlayerPrefs.GetString(eName + "Status1"));
        PlayerPrefs.SetInt("E" + eNumber + "Status1X", PlayerPrefs.GetInt(eName + "Status1X"));
        PlayerPrefs.SetString("E" + eNumber + "Status2", PlayerPrefs.GetString(eName + "Status2"));
        PlayerPrefs.SetInt("E" + eNumber + "Status2X", PlayerPrefs.GetInt(eName + "Status2X"));
        PlayerPrefs.SetString("E" + eNumber + "Status3", PlayerPrefs.GetString(eName + "Status3"));
        PlayerPrefs.SetInt("E" + eNumber + "Status3X", PlayerPrefs.GetInt(eName + "Status3X"));
        PlayerPrefs.SetInt("E" + eNumber + "-Attack", PlayerPrefs.GetInt(eName + "-Attack"));
        PlayerPrefs.SetString("E" + eNumber + "-Weakness1", PlayerPrefs.GetString(eName + "-Weakness1"));
        PlayerPrefs.SetString("E" + eNumber + "-Weakness2", PlayerPrefs.GetString(eName + "-Weakness2"));
        PlayerPrefs.SetString("E" + eNumber + "-Resistance1", PlayerPrefs.GetString(eName + "-Resistance1"));
        PlayerPrefs.SetString("E" + eNumber + "-Resistance2", PlayerPrefs.GetString(eName + "-Resistance2"));
        PlayerPrefs.SetString("E" + eNumber + "-Resistance3", PlayerPrefs.GetString(eName + "-Resistance3"));
        PlayerPrefs.SetString("E" + eNumber + "-Skill1", PlayerPrefs.GetString(eName + "-Skill1"));
        PlayerPrefs.SetString("E" + eNumber + "-Skill2", PlayerPrefs.GetString(eName + "-Skill2"));
        PlayerPrefs.SetString("E" + eNumber + "-Skill3", PlayerPrefs.GetString(eName + "-Skill3"));
        PlayerPrefs.SetString("E" + eNumber + "-Skill4", PlayerPrefs.GetString(eName + "-Skill4"));
        PlayerPrefs.SetString("E" + eNumber + "-Skill5", PlayerPrefs.GetString(eName + "-Skill5"));
        PlayerPrefs.SetString("E" + eNumber + "-Skill6", PlayerPrefs.GetString(eName + "-Skill6"));
        GameObject targetHP = GameObject.Find("E" + eNumber + "-Hp");
        int PCHP = PlayerPrefs.GetInt("E" + eNumber + "-CHP");
        int PMax = PlayerPrefs.GetInt("E" + eNumber + "-HP");
        float Percent = ((float)PCHP / (float)PMax);
        targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        GameObject targetGuard = GameObject.Find("E" + eNumber + "-Guard");
        int PCGuard = PlayerPrefs.GetInt("E" + eNumber + "-CG");
        int PMaxGuard = PlayerPrefs.GetInt("E" + eNumber + "-Guard");
        float PercentGuard = ((float)PCGuard / (float)PMaxGuard);
        targetGuard.gameObject.transform.localScale = new Vector3(PercentGuard, 1, 1);
        GameObject sprite = GameObject.Find("E" + eNumber + "");
        LoadSprite.FindSprite(sprite, eName);
        BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
        Destroy(_boxCollider);
        _boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        // PlayerPrefs.SetInt("E" + eNumber + "-Guard", 100);
        PlayerPrefs.SetInt("E" + eNumber + "-AttL", 0);
    }
}
