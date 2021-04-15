using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Linq;

public class IvryWardon : MonoBehaviour
{
    public Text textbox;
    public Animator anim;
    public GameObject GBar;
    public GameObject HPBar;
    public GameObject InputDiss;
    public GameObject HPBack;
    public GameObject EBar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("E-Block-1-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-2-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-3-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-4-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-5-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-6-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-7-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-8-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-9-Moveable", 1);
        PlayerPrefs.SetInt("E1-Loc", 0);
        SetLoc();
        int P1CHP = PlayerPrefs.GetInt("P1-CHP");
        int P1Max = PlayerPrefs.GetInt("P1-HP");
        float PercentHP = ((float)P1CHP / (float)P1Max);
        HPBar.gameObject.transform.localScale = new Vector3(PercentHP, 1, 1);
        int P1CG = PlayerPrefs.GetInt("P1-CG");
        int P1MaxG = PlayerPrefs.GetInt("P1-Guard");
        PercentHP = ((float)P1CG / (float)P1MaxG);
        GBar.gameObject.transform.localScale = new Vector3(PercentHP, 1, 1);
        anim = anim.GetComponent<Animator>();
        if (PlayerPrefs.GetInt("IW-Set") != 1)
        {
            PlayerPrefs.SetInt("IW-CHP", 40);
            PlayerPrefs.SetInt("IW-HP", 40);
            PlayerPrefs.SetInt("IW-CG", 50);
            PlayerPrefs.SetInt("IW-Set", 1);
        }
        ChooseAttack();
    }

    void SetLoc()
    {
        int time = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = time;
        // the seed a number in that range
        int Loc = 0;
        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-0-Moveable", 0);
        while (Loc == 0)
        {
            Loc = UnityEngine.Random.Range(1, 9);
            if (PlayerPrefs.GetInt("E-Block-" + Loc.ToString() + "-Moveable") == 0)
            {
                Loc = 0;
            }
        }
        PlayerPrefs.SetInt("E1-Loc", Loc);
        Vector3 E1LocQuards = new Vector3(0, 0, 0);
        switch (Loc)
        {
            //420 80 -3
            //238
            //0 -163
            //-100 -163
            case 1:
                {
                    E1LocQuards = new Vector3(182, -158, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 2:
                {
                    E1LocQuards = new Vector3(420, -158, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 3:
                {
                    E1LocQuards = new Vector3(658, -158, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0); 
                    break;
                }
            case 4:
                {
                    E1LocQuards = new Vector3(182, 80, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 5:
                {
                    E1LocQuards = new Vector3(420, 80, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 6:
                {
                    E1LocQuards = new Vector3(658, 80, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 7:
                {
                    E1LocQuards = new Vector3(182, 318, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 8:
                {
                    E1LocQuards = new Vector3(420, 80, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            case 9:
                {
                    E1LocQuards = new Vector3(658, 80, -3);
                    transform.position = E1LocQuards;
                    EBar.gameObject.transform.position = E1LocQuards + new Vector3(-100, -163, 0);
                    HPBack.gameObject.transform.position = E1LocQuards + new Vector3(0, -163, 0);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void OnMouseEnter()
    {
        textbox.text = "Ivory Warden" + " HP: " + PlayerPrefs.GetInt("IW-CHP") + "/" + "40" + "\n" + "Intent: " + PlayerPrefs.GetString("IW-CAtt") + " 14 Damage";
        string Block = "P-Block-" + PlayerPrefs.GetInt("P1-Loc").ToString();
        GameObject IBlock = GameObject.FindGameObjectWithTag(Block);
        IBlock.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseDown()
    {
        PlayerPrefs.SetInt("Clicked", 1);
    }

    public void OnMouseExit()
    {
        if (PlayerPrefs.GetInt("Clicked") != 1)
        {
            textbox.text = "";
            string Block = "P-Block-" + PlayerPrefs.GetInt("P1-Loc").ToString();
            GameObject IBlock = GameObject.FindGameObjectWithTag(Block);
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
        }
    }
    public void ChooseAttack()
    {
        //just handles basic attack for now
        PlayerPrefs.SetString("IW-CAtt", "Basic Attack");
        PlayerPrefs.SetInt("IW-AttL", 5);
    }
    public void AttackCloud()
    {
        Move();
        Vector3 EBox5 = new Vector3(0, 0, 0);
        switch (PlayerPrefs.GetInt("P1-Loc"))
        {
            case 1:
                {
                    EBox5 = new Vector3(-672, -147, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 2:
                {
                    EBox5 = new Vector3(-434, -147, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 3:
                {
                    EBox5 = new Vector3(-196, -147, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 4:
                {
                    EBox5 = new Vector3(-672, 91, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 5:
                {
                    EBox5 = new Vector3(-434, 91, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 6:
                {
                    EBox5 = new Vector3(-196, 91, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 7:
                {
                    EBox5 = new Vector3(-672, 329, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 8:
                {
                    EBox5 = new Vector3(-434, 329, -2);
                    anim.transform.position = EBox5;
                    break;
                }
            case 9:
                {
                    EBox5 = new Vector3(-196, 329, -2);
                    anim.transform.position = EBox5;
                    break;
                }

            default:
                {
                    EBox5 = new Vector3(0,0,0);
                    anim.transform.position = EBox5;
                    break;
                }
        }
        anim.SetTrigger("Play");
        Invoke("EndAnimation", 1.6f);
        int P1CHP = PlayerPrefs.GetInt("P1-CHP");
        int P1CG = PlayerPrefs.GetInt("P1-CG");
        if (PlayerPrefs.GetInt("P1-Guarding") == 1)
        {
            P1CG = P1CG - 7;
        }
        else
        {
            P1CG = P1CG - 7;
            P1CHP = P1CHP - 7;
        }
        if (P1CG < 0)
        {
            P1CHP = P1CHP + P1CG;
            PlayerPrefs.SetInt("P1-CG", 0);
            P1CG = 0;
        }
        else
        {
            PlayerPrefs.SetInt("P1-CG", P1CG);
        }
        PlayerPrefs.SetInt("P1-CHP", P1CHP);
        int P1Max = PlayerPrefs.GetInt("P1-HP");
        float Percent = ((float)P1CHP / (float)P1Max);
        HPBar.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        P1Max = PlayerPrefs.GetInt("P1-Guard");
        Percent = ((float)P1CG / (float)P1Max);
        GBar.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        if (P1CHP < 0)
        {
            //change to game over
            Application.LoadLevel("GameOver");
        }
    }

    void Move()
    {
        int time = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = time;
        int rando;
        int value;
        Vector3 E1LocQuards = new Vector3(0, 0, 0);
        switch (PlayerPrefs.GetInt("E1-Loc"))
        {
            case 1:
                {
                    rando = UnityEngine.Random.Range(0, 1);
                    if (rando == 0 && PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 2);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (rando == 1 && PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 4);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 2);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 4);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    break;
                }
            case 2:
                {
                    int[] array = new int[] { 0, 1, 2 };
                    List<int> list = array.ToList();
                    ////list.AddRange(array);
                    rando = UnityEngine.Random.Range(0, list.Count);
                    value = list[rando];
                    list.RemoveAt(rando);
                    if (value == 0 && PlayerPrefs.GetInt("E-Block-1-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 1);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 5);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 2 && PlayerPrefs.GetInt("E-Block-3-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 3);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else
                    {
                        rando = UnityEngine.Random.Range(0, list.Count);
                        value = list[rando];
                        list.RemoveAt(rando);
                        if (value == 0 && PlayerPrefs.GetInt("E-Block-1-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(-238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 1);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, 238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 5);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 2 && PlayerPrefs.GetInt("E-Block-3-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 3);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else
                        {
                            rando = UnityEngine.Random.Range(0, list.Count);
                            value = list[rando];
                            list.RemoveAt(rando);
                            if (value == 0 && PlayerPrefs.GetInt("E-Block-1-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(-238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 1);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, 238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 5);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 2 && PlayerPrefs.GetInt("E-Block-3-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 3);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                        }
                    }
                    break;
                }
            case 3:
                {
                    rando = UnityEngine.Random.Range(0, 1);
                    if (rando == 0 && PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 2);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (rando == 1 && PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 6);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 2);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 6);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    break;
                }
            case 4:
                {
                    int[] array = new int[] { 0, 1, 2 };
                    List<int> list = array.ToList();
                    //list.AddRange(array);
                    rando = UnityEngine.Random.Range(0, list.Count);
                    value = list[rando];
                    list.RemoveAt(rando);
                    if (value == 0 && PlayerPrefs.GetInt("E-Block-1-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 1);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 5);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 2 && PlayerPrefs.GetInt("E-Block-7-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 7);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else
                    {
                        rando = UnityEngine.Random.Range(0, list.Count);
                        value = list[rando];
                        list.RemoveAt(rando);
                        if (value == 0 && PlayerPrefs.GetInt("E-Block-1-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, -238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 1);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 5);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 2 && PlayerPrefs.GetInt("E-Block-7-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, 238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 7);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else
                        {
                            rando = UnityEngine.Random.Range(0, list.Count);
                            value = list[rando];
                            list.RemoveAt(rando);
                            if (value == 0 && PlayerPrefs.GetInt("E-Block-1-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, -238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 1);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 5);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 2 && PlayerPrefs.GetInt("E-Block-7-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, 238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 7);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                        }
                    }
                    break;
                }
            case 5:
                {
                    int[] array = new int[] { 0, 1, 2, 3 };
                    List<int> list = array.ToList();
                    //list.AddRange(array);
                    rando = UnityEngine.Random.Range(0, list.Count);
                    value = list[rando];
                    list.RemoveAt(rando);
                    if (value == 0 && PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 4);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 1 && PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 8);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 2 && PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 2);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 3 && PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 6);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else
                    {
                        rando = UnityEngine.Random.Range(0, list.Count);
                        value = list[rando];
                        list.RemoveAt(rando);
                        if (value == 0 && PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(-238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 4);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 1 && PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, 238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 8);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 2 && PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, -238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 2);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 3 && PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 6);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else
                        {
                            rando = UnityEngine.Random.Range(0, list.Count);
                            value = list[rando];
                            list.RemoveAt(rando);
                            if (value == 0 && PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(-238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 4);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 1 && PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, 238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 8);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 2 && PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, -238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 2);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 3 && PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 6);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else
                            {
                                rando = UnityEngine.Random.Range(0, list.Count);
                                value = list[rando];
                                list.RemoveAt(rando);
                                if (value == 0 && PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                                {
                                    E1LocQuards = new Vector3(-238, 0, 0);
                                    transform.position += E1LocQuards;
                                    EBar.gameObject.transform.position += E1LocQuards;
                                    HPBack.gameObject.transform.position += E1LocQuards;
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                    PlayerPrefs.SetInt("E1-Loc", 4);
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                                }
                                else if (value == 1 && PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                                {
                                    E1LocQuards = new Vector3(0, 238, 0);
                                    transform.position += E1LocQuards;
                                    EBar.gameObject.transform.position += E1LocQuards;
                                    HPBack.gameObject.transform.position += E1LocQuards;
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                    PlayerPrefs.SetInt("E1-Loc", 8);
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                                }
                                else if (value == 2 && PlayerPrefs.GetInt("E-Block-2-Moveable") == 1)
                                {
                                    E1LocQuards = new Vector3(0, -238, 0);
                                    transform.position += E1LocQuards;
                                    EBar.gameObject.transform.position += E1LocQuards;
                                    HPBack.gameObject.transform.position += E1LocQuards;
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                    PlayerPrefs.SetInt("E1-Loc", 2);
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                                }
                                else if (value == 3 && PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                                {
                                    E1LocQuards = new Vector3(238, 0, 0);
                                    transform.position += E1LocQuards;
                                    EBar.gameObject.transform.position += E1LocQuards;
                                    HPBack.gameObject.transform.position += E1LocQuards;
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                    PlayerPrefs.SetInt("E1-Loc", 6);
                                    PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                                }
                            }
                        }
                    }
                    break;
                }
            case 6:
                {
                    int[] array = new int[] { 0, 1, 2 };
                    List<int> list = array.ToList();
                    //list.AddRange(array);
                    rando = UnityEngine.Random.Range(0, list.Count);
                    value = list[rando];
                    list.RemoveAt(rando);
                    if (value == 0 && PlayerPrefs.GetInt("E-Block-3-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 3);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 5);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 2 && PlayerPrefs.GetInt("E-Block-9-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, 238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 9);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else
                    {
                        rando = UnityEngine.Random.Range(0, list.Count);
                        value = list[rando];
                        list.RemoveAt(rando);
                        if (value == 0 && PlayerPrefs.GetInt("E-Block-3-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, -238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 3);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(-238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 5);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 2 && PlayerPrefs.GetInt("E-Block-9-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, 238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 9);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else
                        {
                            rando = UnityEngine.Random.Range(0, list.Count);
                            value = list[rando];
                            list.RemoveAt(rando);
                            if (value == 0 && PlayerPrefs.GetInt("E-Block-3-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, -238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 3);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 1 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(-238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 5);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 2 && PlayerPrefs.GetInt("E-Block-9-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, 238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 9);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                        }
                    }
                    break;
                }
            case 7:
                {
                    rando = UnityEngine.Random.Range(0, 1);
                    if (rando == 0 && PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 8);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (rando == 1 && PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 4);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 8);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-4-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 4);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    break;
                }
            case 8:
                {
                    int[] array = new int[] { 0, 1, 2 };
                    List<int> list = array.ToList();
                    //list.AddRange(array);
                    rando = UnityEngine.Random.Range(0, list.Count);
                    value = list[rando];
                    list.RemoveAt(rando);
                    if (value == 0 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 5);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 1 && PlayerPrefs.GetInt("E-Block-7-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 7);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (value == 2 && PlayerPrefs.GetInt("E-Block-9-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 9);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else
                    {
                        rando = UnityEngine.Random.Range(0, list.Count);
                        value = list[rando];
                        list.RemoveAt(rando);
                        if (value == 0 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(0, -238, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 5);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 1 && PlayerPrefs.GetInt("E-Block-7-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(-238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 7);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else if (value == 2 && PlayerPrefs.GetInt("E-Block-9-Moveable") == 1)
                        {
                            E1LocQuards = new Vector3(238, 0, 0);
                            transform.position += E1LocQuards;
                            EBar.gameObject.transform.position += E1LocQuards;
                            HPBack.gameObject.transform.position += E1LocQuards;
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                            PlayerPrefs.SetInt("E1-Loc", 9);
                            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                        }
                        else
                        {
                            rando = UnityEngine.Random.Range(0, list.Count);
                            value = list[rando];
                            list.RemoveAt(rando);
                            if (value == 0 && PlayerPrefs.GetInt("E-Block-5-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(0, -238, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 5);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 1 && PlayerPrefs.GetInt("E-Block-7-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(-238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 7);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                            else if (value == 2 && PlayerPrefs.GetInt("E-Block-9-Moveable") == 1)
                            {
                                E1LocQuards = new Vector3(238, 0, 0);
                                transform.position += E1LocQuards;
                                EBar.gameObject.transform.position += E1LocQuards;
                                HPBack.gameObject.transform.position += E1LocQuards;
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                                PlayerPrefs.SetInt("E1-Loc", 9);
                                PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                            }
                        }
                    }
                    break;
                }
            case 9:
                {
                    rando = UnityEngine.Random.Range(0, 1);
                    if (rando == 0 && PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 8);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (rando == 1 && PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 6);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-8-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(-238, 0, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 8);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    else if (PlayerPrefs.GetInt("E-Block-6-Moveable") == 1)
                    {
                        E1LocQuards = new Vector3(0, -238, 0);
                        transform.position += E1LocQuards;
                        EBar.gameObject.transform.position += E1LocQuards;
                        HPBack.gameObject.transform.position += E1LocQuards;
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
                        PlayerPrefs.SetInt("E1-Loc", 6);
                        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 0);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void EndAnimation()
    {
        PlayerPrefs.SetInt("P1-CanMove", 1);
        Vector3 ScreenPos = new Vector3(0, -192, -100);
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimation2", 0.1f);
    }
    public void EndAnimation2()
    {
        Vector3 ScreenPos = new Vector3(0, 246, -100);
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimation3", 0.1f);
    }
    public void EndAnimation3()
    {
        Vector3 temp = new Vector3(-5000, 0, 0);
        anim.transform.position = temp;
        InputDiss.transform.position = temp;
        PlayerPrefs.SetInt("P1-Guarding", 0);
    }
}
