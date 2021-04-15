using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Reaper : MonoBehaviour
{
    public Text textbox;
    public GameObject skillcard_A;
    public Text Damage_A;
    public GameObject skillcard_D;
    public Text Damage_D;
    public GameObject skillcard_1;
    public Text SName_1;
    public Text Damage_1;
    public Text Cost_1;
    public GameObject skillcard_2;
    public Text SName_2;
    public Text Damage_2;
    public Text Cost_2;
    public GameObject skillcard_3;
    public Text SName_3;
    public Text Damage_3;
    public Text Cost_3;
    public GameObject skillcard_4;
    public Text SName_4;
    public Text Damage_4;
    public Text Cost_4;
    public GameObject skillcard_M;
    public int Player;

    void OnMouseEnter()
    {
        if (PlayerPrefs.GetInt("Clicked") != 1)
        {
            if (PlayerPrefs.GetInt("setup") == 0)
            {
                textbox.text = PlayerPrefs.GetString("P" + PlayerPrefs.GetInt("ReaperP") + "-Name") + " HP: " + PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-CHP") +
                    "/" + PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-HP") + "    SP: " + PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-CSP") + "/"
                    + PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-SP") + "\n" + "Guard: " + PlayerPrefs.GetInt("P1-CG") + "/" + PlayerPrefs.GetInt("P1-Guard");
                //this moves cards
                if (PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-TurnTaken") == 0 && PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-CHP") > 0)
                {
                    Vector3 temp = new Vector3(-300 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_A.transform.position = temp;
                    Damage_A.text = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Attack").ToString();
                    temp = new Vector3(-200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_D.transform.position = temp;
                    temp = new Vector3(-100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_1.transform.position = temp;
                    Damage_1.text = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-S1-Damage").ToString();
                    Cost_1.text = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-S1-Cost").ToString();
                    SName_1.text = PlayerPrefs.GetString("P" + PlayerPrefs.GetInt("ReaperP") + "-Skill-1");
                    temp = new Vector3(0 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_2.transform.position = temp;
                    temp = new Vector3(100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_3.transform.position = temp;
                    temp = new Vector3(200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_4.transform.position = temp;
                    temp = new Vector3(300 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    skillcard_M.transform.position = temp;
                    //this handles movement on 4x4
                    int Loc = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Loc");
                    if (PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-CanMove") == 1)
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc - 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 1;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
                                    }
                                    offset = Loc + 4;
                                    if (PlayerPrefs.GetInt("Block-" + offset + "-Moveable") == 1)
                                    {
                                        IBlock = GameObject.Find("P-Block-" + offset);
                                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;

                                        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + offset + "-Moveable", 1);
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
                if (PlayerPrefs.GetInt("ReaperBig") == 0)
                {
                    PlayerPrefs.SetInt("ReaperBig", 1);
                    transform.localScale = transform.localScale * 1.1f;
                }
            }
        }
    }
    public void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("P"+PlayerPrefs.GetInt("ReaperP")+"-TurnTaken") == 0 && PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-CHP") > 0)
        {
            PlayerPrefs.SetInt("Clicked", 0);
            OnMouseExit();
            OnMouseEnter();
            PlayerPrefs.SetInt("P1-Clicked", 0);
            PlayerPrefs.SetInt("P2-Clicked", 0);
            PlayerPrefs.SetInt("P3-Clicked", 0);
            PlayerPrefs.SetInt("P4-Clicked", 0);
            PlayerPrefs.SetInt("Clicked", 1);
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Clicked", 1);
            //makes blocks clickable over him
            if (PlayerPrefs.GetInt("DownInFrame") == 0)
            {
                PlayerPrefs.SetInt("DownInFrame", 1);
                GameObject hero = GameObject.Find(PlayerPrefs.GetString("P1-Name"));
                hero.transform.position += new Vector3(0, 0, 2);
                if (PlayerPrefs.GetString("P2-Name") != "null")
                {
                    hero = GameObject.Find(PlayerPrefs.GetString("P2-Name"));
                    hero.transform.position += new Vector3(0, 0, 2);
                }
                if (PlayerPrefs.GetString("P3-Name") != "null")
                {
                    hero = GameObject.Find(PlayerPrefs.GetString("P3-Name"));
                    hero.transform.position += new Vector3(0, 0, 2);
                }
                if (PlayerPrefs.GetString("P4-Name") != "null")
                {
                    hero = GameObject.Find(PlayerPrefs.GetString("P4-Name"));
                    hero.transform.position += new Vector3(0, 0, 2);
                }
            }
        }
    }

    public void OnMouseExit()
    {
        if (PlayerPrefs.GetInt("Clicked") != 1)
        {
            for (int i = 0; i <= 25; i++)
            {
                PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("ReaperP") + "-Block-" + i + "-Moveable", 0);
            }
            //makes blocks clickable over him
            if (PlayerPrefs.GetInt("ReaperBig") == 1)
            {
                transform.localScale = transform.localScale / 1.1f;
                PlayerPrefs.SetInt("ReaperBig", 0);
            }
            if (PlayerPrefs.GetInt("DownInFrame") == 1)
            {
                PlayerPrefs.SetInt("DownInFrame", 0);
                GameObject hero = GameObject.Find(PlayerPrefs.GetString("P1-Name"));
                hero.transform.position += new Vector3(0, 0, -2);
                if (PlayerPrefs.GetString("P2-Name") != "null")
                {
                    hero = GameObject.Find(PlayerPrefs.GetString("P2-Name"));
                    hero.transform.position += new Vector3(0, 0, -2);
                }
                if (PlayerPrefs.GetString("P3-Name") != "null")
                {
                    hero = GameObject.Find(PlayerPrefs.GetString("P3-Name"));
                    hero.transform.position += new Vector3(0, 0, -2);
                }
                if (PlayerPrefs.GetString("P4-Name") != "null")
                {
                    hero = GameObject.Find(PlayerPrefs.GetString("P4-Name"));
                    hero.transform.position += new Vector3(0, 0, -2);
                }
            }
            textbox.text = "";
            Vector3 temp = new Vector3(-3000, 0, 0);
            skillcard_A.transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            skillcard_D.transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            skillcard_1.transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            skillcard_2.transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            skillcard_3.transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            skillcard_4.transform.position = temp;
            temp = new Vector3(-3000, 0, 0);
            skillcard_M.transform.position = temp;
            //handles move block color
            GameObject IBlock = GameObject.Find("P-Block-1");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            for (int i = 1; i <= 16; i++)
            {
                IBlock = GameObject.Find("P-Block-"+i);
                IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            }
        }
    }
}