using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Combat : MonoBehaviour
{
    private void Start()
    {
        LoadSprite.FindSprite(GameObject.Find("P1"), PlayerPrefs.GetString("P1-Name"));
        BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
        Destroy(_boxCollider);
        _boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        LoadSprite.FindSprite(GameObject.Find("P1Holo"), PlayerPrefs.GetString("P1-Name"));
    }

    void OnMouseEnter()
    {
        if (PlayerPrefs.GetInt("Clicked") != 1)
        {
            if (PlayerPrefs.GetInt("setup") == 0)
            {
                GameObject.Find("CharStatBox").GetComponent<Text>().text = PlayerPrefs.GetString("P1-Name") + " HP: " + PlayerPrefs.GetInt("P1-CHP") +
                "/" + PlayerPrefs.GetInt("P1-HP") + "    SP: " + PlayerPrefs.GetInt("P1-CSP") + "/"
                + PlayerPrefs.GetInt("P1-SP") + "\n" + "Guard: " + PlayerPrefs.GetInt("P1-CG") + "/" + PlayerPrefs.GetInt("P1-Guard");
                if (PlayerPrefs.GetInt("P1-TurnTaken") == 0 && PlayerPrefs.GetInt("P1-CHP") > 0)
                {
                    //this moves cards
                    SingleTargetSkills.UltSwitch(1);
                    Vector3 temp = new Vector3(-300 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-A").transform.position = temp;
                    GameObject.Find("A-Damage").GetComponent<Text>().text = PlayerPrefs.GetInt("P1-Attack").ToString();
                    GameObject.Find("Special").transform.position = temp + new Vector3(0, 120, 0);
                    GameObject.Find("SpecialBack").transform.position = temp + new Vector3(0, 120, 0);
                    temp = new Vector3(-200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-D").transform.position = temp;
                    temp = new Vector3(-100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-1").transform.position = temp;
                    GameObject.Find("1-Damage").GetComponent<Text>().text = PlayerPrefs.GetInt("P1-S1-Damage").ToString();
                    GameObject.Find("1-Cost").GetComponent<Text>().text = PlayerPrefs.GetInt("P1-S1-Cost").ToString();
                    GameObject.Find("1-Text").GetComponent<Text>().text = PlayerPrefs.GetString("P1-Skill-1");
                    temp = new Vector3(0 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-2").transform.position = temp;
                    temp = new Vector3(100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-3").transform.position = temp;
                    temp = new Vector3(200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-4").transform.position = temp;
                    temp = new Vector3(300 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-M").transform.position = temp;
                    //this handles movement on 4x4
                    int Loc = PlayerPrefs.GetInt("P1-Loc");
                    if (PlayerPrefs.GetInt("P1-CanMove") == 1)
                    {
                        GameObject IBlock = GameObject.Find("P-Block-1");
                        int offset = 0;
                        switch (Loc)
                        {
                            case 1:
                                {
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 13:
                                {
                                    offset = Loc - 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 16:
                                {
                                    offset = Loc - 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 2:
                            case 3:
                                {
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 5:
                            case 9:
                                {
                                    offset = Loc - 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 8:
                            case 12:
                                {
                                    offset = Loc - 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 14:
                            case 15:
                                {
                                    offset = Loc - 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            case 6:
                            case 7:
                            case 10:
                            case 11:
                                {
                                    offset = Loc - 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P1-Block-" + offset + "-Moveable", 1);
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
                if (PlayerPrefs.GetInt("P1Big") == 0)
                {
                    PlayerPrefs.SetInt("P1Big", 1);
                    transform.localScale = transform.localScale * 1.1f;
                }
            }
        }
    }
    public void OnMouseDown()
    {
        if (PlayerPrefs.GetString("ActiveSkill") != "None" && PlayerPrefs.GetString(PlayerPrefs.GetString("ActiveSkill") + "-Targeting") != "FriendlyTargetOther")
        {
            PlayerPrefs.SetInt("PNumber", 1);
        }
        else if (PlayerPrefs.GetString("ActiveSkill") != "None" && PlayerPrefs.GetString(PlayerPrefs.GetString("ActiveSkill") + "-Targeting") == "FriendlyTargetOther" && PlayerPrefs.GetInt("P1-Clicked") == 0)
        {
            PlayerPrefs.SetInt("PNumber", 1);
        }
        else 
        {
            if (PlayerPrefs.GetInt("P1-TurnTaken") == 0 && PlayerPrefs.GetInt("P1-CHP") > 0)
            {
                PlayerPrefs.SetInt("Clicked", 0);
                OnMouseExit();
                OnMouseEnter();
                PlayerPrefs.SetInt("P1-Clicked", 0);
                PlayerPrefs.SetInt("P2-Clicked", 0);
                PlayerPrefs.SetInt("P3-Clicked", 0);
                PlayerPrefs.SetInt("P4-Clicked", 0);
                PlayerPrefs.SetInt("Clicked", 1);
                PlayerPrefs.SetInt("P1-Clicked", 1);
                //makes blocks clickable over him
                if (PlayerPrefs.GetInt("DownInFrame") == 0)
                {
                    PlayerPrefs.SetInt("DownInFrame", 1);
                    GameObject hero = GameObject.Find("P1");
                    hero.transform.position += new Vector3(0, 0, 2);
                    if (PlayerPrefs.GetString("P2-Name") != "null")
                    {
                        hero = GameObject.Find("P2");
                        hero.transform.position += new Vector3(0, 0, 2);
                    }
                    if (PlayerPrefs.GetString("P3-Name") != "null")
                    {
                        hero = GameObject.Find("P3");
                        hero.transform.position += new Vector3(0, 0, 2);
                    }
                    if (PlayerPrefs.GetString("P4-Name") != "null")
                    {
                        hero = GameObject.Find("P4");
                        hero.transform.position += new Vector3(0, 0, 2);
                    }
                }
            }
        }
    }

    public void OnMouseExit()
    {
        //makes blocks clickable over him
        if (PlayerPrefs.GetInt("Clicked") != 1)
        {
            for (int i = 0; i <= 25; i++)
            {
                PlayerPrefs.SetInt("P1-Block-" + i + "-Moveable", 0);
            }
            //makes blocks clickable over him
            if (PlayerPrefs.GetInt("P1Big") == 1)
            {
                transform.localScale = transform.localScale / 1.1f;
                PlayerPrefs.SetInt("P1Big", 0);
            }
            if (PlayerPrefs.GetInt("DownInFrame") == 1)
            {
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
            }
            GameObject.Find("CharStatBox").GetComponent<Text>().text = "";
            Vector3 temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-A").transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-D").transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-1").transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-2").transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-3").transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-4").transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            GameObject.Find("skillcard-M").transform.position = temp;
            //handles move block color
            GameObject IBlock = GameObject.Find("P-Block-1");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            for (int i = 2; i <= 16; i++)
            {
                IBlock = GameObject.Find("P-Block-" + i);
                IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            }
        }
    }
}