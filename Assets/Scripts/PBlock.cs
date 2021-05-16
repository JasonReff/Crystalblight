using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class PBlock : MonoBehaviour
{
    public unclick unclick;

    public char side;
    public int tileNumber;
    public bool movable;
    public bool clicked;
    public int standingPlayer;

    private void Start()
    {
        side = this.gameObject.name[0];
        tileNumber = Int32.Parse(this.gameObject.name.Substring(8));
        movable = true;
    }

    void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("setup") == 1)
        {
            place();
        }
        else
        {
            move();
        }
    }

    void place()
    {
        //code to fine what player is clicked (if any)
        int p = 0;
        for (int player = 1; p <= 25; p++)
        {
            if (GameObject.Find("P" + player) != null)
            { if (GameObject.Find("P" + player).GetComponent<P1Combat>().clicked == true) { p = player; break; } }
        }
        if (p != 0)
        {
            //work on moveable
            //finds the stuff of whatever hero is clicked
            GameObject Hero = GameObject.Find("P" + p);
            GameObject HeroHp = GameObject.Find("P" + p + "-Hp");
            GameObject HeroHpBack = GameObject.Find("P" + p + "-HpBack");
            GameObject HeroSp = GameObject.Find("P" + p + "-Sp");
            GameObject HeroSpBack = GameObject.Find("P" + p + "-SpBack");
            GameObject HeroGuard = GameObject.Find("P" + p + "-Guard");
            //code to get current block
            string n = name;
            if (n.Length == 9)
            {
                n = n[8].ToString();
            }
            else
            {
                n = n[8].ToString() + n[9].ToString();
            }
            if (PlayerPrefs.GetInt("P" + p + "-CanMove") == 1 && PlayerPrefs.GetInt("Block-" + n + "-Moveable") == 1)
            {
                int l = Int32.Parse(n) + 4;
                l = l / 4;
                //decomment this to make them unable to move on first turn
                //PlayerPrefs.SetInt("P" + p + "-CanMove", 0);
                PlayerPrefs.SetInt("Block-" + n + "-Moveable", 0);
                PlayerPrefs.GetInt("Block-" + PlayerPrefs.GetInt("P" + p + "-Loc") + "-Moveable", 1);
                GameObject HeroHollo = GameObject.Find("P" + p + "Holo");
                HeroHollo.transform.position = new Vector3(-3000, 0, 0);
                Vector3 temp = transform.position;
                Hero.transform.position = temp + new Vector3(0, +67, 1);
                SpriteRenderer sprite = Hero.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Char" + l;
                HeroHp.transform.position = temp + new Vector3(-100, -17, 1);
                HeroHp = HeroHp.transform.GetChild(0).gameObject;
                sprite = HeroHp.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Bar" + l;
                HeroHpBack.transform.position = temp + new Vector3(0, -17, 1);
                sprite = HeroHpBack.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Back" + l;
                HeroSp.transform.position = temp + new Vector3(-100, -45, 1);
                HeroSp = HeroSp.transform.GetChild(0).gameObject;
                sprite = HeroSp.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Bar" + l;
                HeroSpBack.transform.position = temp + new Vector3(0, -45, 1);
                sprite = HeroSpBack.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Back" + l;
                HeroGuard.transform.position = temp + new Vector3(-100, -17, 1);
                HeroGuard = HeroGuard.transform.GetChild(0).gameObject;
                sprite = HeroGuard.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Guard" + l;
                GameObject statusSlot0 = GameObject.Find("P" + p + "Status0");
                statusSlot0.transform.position = temp + new Vector3(-40, 20, 1);
                statusSlot0 = statusSlot0.transform.gameObject;
                sprite = statusSlot0.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot0X = GameObject.Find("P" + p + "Status0X");
                statusSlot0X.transform.position = temp + new Vector3(-40, 20, 1);
                GameObject statusSlot1 = GameObject.Find("P" + p + "Status1");
                statusSlot1.transform.position = temp + new Vector3(-30, 20, 1);
                statusSlot1 = statusSlot0.transform.gameObject;
                sprite = statusSlot1.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot1X = GameObject.Find("P" + p + "Status1X");
                statusSlot1X.transform.position = temp + new Vector3(-30, 20, 1);
                GameObject statusSlot2 = GameObject.Find("P" + p + "Status2");
                statusSlot2.transform.position = temp + new Vector3(-20, 20, 1);
                statusSlot2 = statusSlot2.transform.gameObject;
                sprite = statusSlot2.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot2X = GameObject.Find("P" + p + "Status2X");
                statusSlot2X.transform.position = temp + new Vector3(-20, 20, 1);
                GameObject statusSlot3 = GameObject.Find("P" + p + "Status3");
                statusSlot3.transform.position = temp + new Vector3(-10, 20, 1);
                statusSlot3 = statusSlot3.transform.gameObject;
                sprite = statusSlot3.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot3X = GameObject.Find("P" + p + "Status3X");
                statusSlot3X.transform.position = temp + new Vector3(-10, 20, 1);
                PlayerPrefs.SetInt("P" + p + "-Loc", Int32.Parse(n));
                PlayerPrefs.SetInt("P" + p + "-Clicked", 0);
                p = p + 1;
                PlayerPrefs.SetInt("Clicked", 1);
                PlayerPrefs.SetInt("P" + p + "-Clicked", 1);
                //change for more players
                if (p > 2)
                {
                    PlayerPrefs.SetInt("Clicked", 0);
                    PlayerPrefs.SetInt("P" + p + "-Clicked", 0);
                    PlayerPrefs.SetInt("setup", 0);
                    PlayerPrefs.SetInt("DownInFrame", 0);
                    GameObject hero = GameObject.Find("P1");
                    hero.transform.position += new Vector3(0, 0, -2);
                    if (PlayerPrefs.GetString("P2-Name") != "null")
                    {
                        hero = GameObject.Find("P2");
                        hero.transform.position += new Vector3(0, 0, -2);
                    }
                    if (PlayerPrefs.GetString("P3-Name") != "null")
                    {
                        hero = GameObject.Find("P3");
                        hero.transform.position += new Vector3(0, 0, -2);
                    }
                    if (PlayerPrefs.GetString("P4-Name") != "null")
                    {
                        hero = GameObject.Find("P4");
                        hero.transform.position += new Vector3(0, 0, -2);
                    }
                    PlayerPrefs.SetInt("E1-AttL", PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-Loc"));
                    PlayerPrefs.SetInt("E2-AttL", PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-Loc"));
                }
            }
            else
            {
                PlayerPrefs.SetInt("Clicked", 0);
                PlayerPrefs.SetInt("P1-Clicked", 0);
                GameObject LordKalor = GameObject.Find("Lord Kalor");
                LordKalor.GetComponent<LordKalor>().ChooseAttack();
                unclick.OnMouseDown();
            }
        }
    }

    void move()
    {
        //code to fine what player is clicked (if any)
        int p = 0;
        for (int player = 1; p <= 25; p++)
        {
            if (GameObject.Find("P" + player) != null)
            { if (GameObject.Find("P" + player).GetComponent<P1Combat>().clicked == true) { p = player; break; } }
        }
        if (p != 0)
        {
            //work on moveable
            //finds the stuff of whatever hero is clicked
            GameObject Hero = GameObject.Find("P" + p);
            GameObject HeroHp = GameObject.Find("P" + p + "-Hp");
            GameObject HeroHpBack = GameObject.Find("P" + p + "-HpBack");
            GameObject HeroSp = GameObject.Find("P" + p + "-Sp");
            GameObject HeroSpBack = GameObject.Find("P" + p + "-SpBack");
            GameObject HeroGuard = GameObject.Find("P" + p + "-Guard");
            //code to get current block unsure if will work
            string n = name;
            if (n.Length == 9)
            {
                n = n[8].ToString();
            }
            else
            {
                n = n[8].ToString() + n[9].ToString();
            }
            if (PlayerPrefs.GetInt("P" + p + "-CanMove") == 1 && PlayerPrefs.GetInt("P" + p + "-Block-" + n + "-Moveable") == 1 && PlayerPrefs.GetInt("Block-" + n + "-Moveable") == 1)
            {
                int l = Int32.Parse(n) + 4;
                l = l / 4;
                for (int i = 0; i <= 15; i++)
                {
                    PlayerPrefs.SetInt("P" + p + "-Block-" + i + "-Moveable", 0);
                }
                PlayerPrefs.SetInt("P" + p + "-CanMove", 0);
                PlayerPrefs.SetInt("Block-" + n + "-Moveable", 0);
                PlayerPrefs.SetInt("Block-" + PlayerPrefs.GetInt("P" + p + "-Loc") + "-Moveable", 1);
                PlayerPrefs.SetInt("P" + p + "-Block-" + n + "-Moveable", 0);
                PlayerPrefs.GetInt("P" + p + "-Block-" + PlayerPrefs.GetInt("P" + p + "-Loc") + "-Moveable", 1);
                Vector3 temp = transform.position;
                Hero.transform.position = temp + new Vector3(0, +67, 1);
                SpriteRenderer sprite = Hero.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Char" + l;
                HeroHp.transform.position = temp + new Vector3(-100, -17, 1);
                HeroHp = HeroHp.transform.GetChild(0).gameObject;
                sprite = HeroHp.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Bar" + l;
                HeroHpBack.transform.position = temp + new Vector3(0, -17, 1);
                sprite = HeroHpBack.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Back" + l;
                HeroSp.transform.position = temp + new Vector3(-100, -45, 1);
                HeroSp = HeroSp.transform.GetChild(0).gameObject;
                sprite = HeroSp.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Bar" + l;
                HeroSpBack.transform.position = temp + new Vector3(0, -45, 1);
                sprite = HeroSpBack.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Back" + l;
                HeroGuard.transform.position = temp + new Vector3(-100, -17, 1);
                HeroGuard = HeroGuard.transform.GetChild(0).gameObject;
                sprite = HeroGuard.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Guard" + l;
                GameObject statusSlot0 = GameObject.Find("P" + p + "Status0");
                statusSlot0.transform.position = temp + new Vector3(-40, 20, 1);
                statusSlot0 = statusSlot0.transform.gameObject;
                sprite = statusSlot0.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot0X = GameObject.Find("P" + p + "Status0X");
                statusSlot0X.transform.position = temp + new Vector3(-40, 20, 1);
                GameObject statusSlot1 = GameObject.Find("P" + p + "Status1");
                statusSlot1.transform.position = temp + new Vector3(-30, 20, 1);
                statusSlot1 = statusSlot0.transform.gameObject;
                sprite = statusSlot1.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot1X = GameObject.Find("P" + p + "Status1X");
                statusSlot1X.transform.position = temp + new Vector3(-30, 20, 1);
                GameObject statusSlot2 = GameObject.Find("P" + p + "Status2");
                statusSlot2.transform.position = temp + new Vector3(-20, 20, 1);
                statusSlot2 = statusSlot2.transform.gameObject;
                sprite = statusSlot2.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot2X = GameObject.Find("P" + p + "Status2X");
                statusSlot2X.transform.position = temp + new Vector3(-20, 20, 1);
                GameObject statusSlot3 = GameObject.Find("P" + p + "Status3");
                statusSlot3.transform.position = temp + new Vector3(-10, 20, 1);
                statusSlot3 = statusSlot3.transform.gameObject;
                sprite = statusSlot3.GetComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Status" + l;
                GameObject statusSlot3X = GameObject.Find("P" + p + "Status3X");
                statusSlot3X.transform.position = temp + new Vector3(-10, 20, 1);
                PlayerPrefs.SetInt("P" + p + "-Loc", Int32.Parse(n));
                PlayerPrefs.SetInt("E1-AttL", PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-Loc"));
                PlayerPrefs.SetInt("E2-AttL", PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-Loc"));
                unclick.OnMouseDown();
                //add more for more charaters
                if (p == 1)
                {
                    Hero.GetComponent<P1Combat>().OnMouseDown();
                }
                else if (p == 2)
                {
                    Hero.GetComponent<P2Combat>().OnMouseDown();
                }
                /*
                 * this code throws an error until yo make the P3 and P4 combat scripts
                else if (p == 3)
                {
                    Hero.GetComponent<P3Combat>().OnMouseDown();
                }
                else if (p == 4)
                {
                    Hero.GetComponent<P4Combat>().OnMouseDown();
                }
                */
            }
            else
            {
                PlayerPrefs.SetInt("Clicked", 0);
                PlayerPrefs.SetInt("P1-Clicked", 0);
                unclick.OnMouseDown();
            }
        }
    }
    void OnMouseEnter()
    {
        if (PlayerPrefs.GetInt("setup") == 1)
        {
            int p = 0;
            if (PlayerPrefs.GetInt("P1-Clicked") == 1)
            {
                p = 1;
            }
            else if (PlayerPrefs.GetInt("P2-Clicked") == 1)
            {
                p = 2;
            }
            else if (PlayerPrefs.GetInt("P3-Clicked") == 1)
            {
                p = 3;
            }
            else if (PlayerPrefs.GetInt("P4-Clicked") == 1)
            {
                p = 4;
            }
            GameObject HeroHollo = GameObject.Find("P" + p + "Holo");
            Vector3 temp = transform.position;
            HeroHollo.transform.position = temp + new Vector3(0, +67, 1);
        }
    }
    void OnMouseExit()
    {
        if (PlayerPrefs.GetInt("setup") == 1)
        {
            int p = 0;
            if (PlayerPrefs.GetInt("P1-Clicked") == 1)
            {
                p = 1;
            }
            else if (PlayerPrefs.GetInt("P2-Clicked") == 1)
            {
                p = 2;
            }
            else if (PlayerPrefs.GetInt("P3-Clicked") == 1)
            {
                p = 3;
            }
            else if (PlayerPrefs.GetInt("P4-Clicked") == 1)
            {
                p = 4;
            }
            GameObject HeroHollo = GameObject.Find("P" + p + "Holo");
            Vector3 temp = transform.position;
            HeroHollo.transform.position = temp + new Vector3(-3000, +67, 1);
        }
    }
}