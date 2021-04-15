/*using System;
using System.Collections;*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Specialized;*/

public class LordKalor : MonoBehaviour
{
    public Text textbox;

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
        PlayerPrefs.SetInt("E-Block-10-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-11-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-12-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-13-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-14-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-15-Moveable", 1);
        PlayerPrefs.SetInt("E-Block-16-Moveable", 1);
        PlayerPrefs.SetInt("E1-Loc", 0);
        SetLoc();
        ChooseAttack();
        if (PlayerPrefs.GetInt("E1-Set") != 1)
        {
            PlayerPrefs.SetInt("E1-CHP", 180);
            PlayerPrefs.SetInt("E1-HP", 180);
            PlayerPrefs.SetInt("E1-CG", 100);
            PlayerPrefs.SetInt("E1-Guard", 100);
            PlayerPrefs.SetInt("E1-Set", 1);
            PlayerPrefs.SetString("E1Status0", "null");
            PlayerPrefs.SetInt("E1Status0X", 0);
            PlayerPrefs.SetString("E1Status1", "null");
            PlayerPrefs.SetInt("E1Status1X", 0);
            PlayerPrefs.SetString("E1Status2", "null");
            PlayerPrefs.SetInt("E1Status2X", 0);
            PlayerPrefs.SetString("E1Status3", "null");
            PlayerPrefs.SetInt("E1Status3X", 0);
            GameObject targetHP = GameObject.Find("E1-Hp");
            int PCHP = PlayerPrefs.GetInt("E1-CHP");
            int PMax = PlayerPrefs.GetInt("E1-HP");
            float Percent = ((float)PCHP / (float)PMax);
            targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
            // PlayerPrefs.SetInt("E1-Guard", 100);
            PlayerPrefs.SetInt("E1-AttL", 0);
        }
    }
    //used for initial movement
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
            Loc = UnityEngine.Random.Range(1, 16);
            if (PlayerPrefs.GetInt("E-Block-" + Loc.ToString() + "-Moveable") == 0)
            {
                Loc = 0;
            }
            PlayerPrefs.SetInt("E-Block-" + Loc.ToString() + "-Moveable", 0);
        }
        PlayerPrefs.SetInt("E1-Loc", Loc);
        GameObject Vill = GameObject.Find("Lord Kalor");
        GameObject VillHp = GameObject.Find("E1-Hp");
        GameObject VillHpBack = GameObject.Find("E1-HpBack");
        GameObject VillGuard = GameObject.Find("E1-Guard");
        GameObject VillStatus0 = GameObject.Find("E1Status0");
        GameObject VillStatus0X = GameObject.Find("E1Status0X");
        Vector3 E1LocQuards = GameObject.Find("E-Block-" + Loc.ToString()).transform.position;
        Vill.transform.position = E1LocQuards + new Vector3(0, +67, -3);
        SpriteRenderer sprite = Vill.GetComponent<SpriteRenderer>();
        int l = Loc + 4;
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
    void OnMouseEnter()
    {
        textbox.text = "Lord Kalor" + " Guard: " + PlayerPrefs.GetInt("E1-CG") + "/" + "100" + " HP: " + PlayerPrefs.GetInt("E1-CHP")
            + "/" + "180" + "\n" + "Intent: " + PlayerPrefs.GetString("E1-CAtt") + " 22 Damage";
        int targ = PlayerPrefs.GetInt("E1-AttL");
        if (targ != 0)
        {
            GameObject IBlock = GameObject.Find("P-Block-" + targ);
            IBlock.GetComponent<SpriteRenderer>().color = Color.red;
        }
        int p = 0;
        if (PlayerPrefs.GetInt("P1-Targeting") == 1)
        {
            p = 1;
        }
        else if (PlayerPrefs.GetInt("P2-Targeting") == 1)
        {
            p = 2;
        }
        else if (PlayerPrefs.GetInt("P3-Targeting") == 1)
        {
            p = 3;
        }
        else if (PlayerPrefs.GetInt("P4-Targeting") == 1)
        {
            p = 4;
        }
        if (p != 0)
        {
            GameObject Hand = GameObject.Find("Hand");
            Hand.transform.position = transform.position + new Vector3(-150, 0, 0);
        }
    }
    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("ENumber", 1);
    }
    public void GiveTurn()
    {
        PlayerPrefs.SetInt("P1-TurnTaken", 0);
        PlayerPrefs.SetInt("P2-TurnTaken", 0);
        PlayerPrefs.SetInt("P3-TurnTaken", 0);
        PlayerPrefs.SetInt("P4-TurnTaken", 0);
        PlayerPrefs.SetInt("P1-CanMove", 1);
        PlayerPrefs.SetInt("P2-CanMove", 1);
        PlayerPrefs.SetInt("P3-CanMove", 1);
        PlayerPrefs.SetInt("P4-CanMove", 1);
        //add more for more players
        GameObject hero = GameObject.Find(PlayerPrefs.GetString("P1-Name"));
        if (PlayerPrefs.GetInt("P1-CHP") > 0)
        {
            hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
        hero = GameObject.Find(PlayerPrefs.GetString("P2-Name"));
        if (PlayerPrefs.GetInt("P2-CHP") > 0)
        {
            hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
        GameObject PDiss = GameObject.Find("PDiss");
        PDiss.transform.position = new Vector3(-3000, 0, 0);
        GameObject PlayerTurn = GameObject.Find("PlayerTurn");
        PlayerTurn.GetComponent<PlayerTurn>().Begin();
    }
    public void OnMouseExit()
    {
        if (PlayerPrefs.GetInt("Clicked") != 1)
        {
            GameObject IBlock;
            textbox.text = "";
            for (int i = 1; i <= 16; i++)
            {
                IBlock = GameObject.Find("P-Block-" + i);
                IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            }
        }
        GameObject Hand = GameObject.Find("Hand");
        Hand.transform.position = new Vector3(-5000, 0, 0);
    }
    public void ChooseAttack()
    {
        //just handles basic attack for now
        PlayerPrefs.SetString("E1-CAtt", "Basic Attack");
        int time = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = time;
        int p = 0;
        while (PlayerPrefs.GetInt("P" + p + "-CHP") == 0)
        {
            p = UnityEngine.Random.Range(1, 3);
            PlayerPrefs.SetInt("E1-AttP", p);
            PlayerPrefs.SetInt("E1-AttL", PlayerPrefs.GetInt("P" + p + "-Loc"));
        }
    }
    public void TakeTurn()
    {
        GameObject PlayerTurn = GameObject.Find("EnemyTurn");
        PlayerTurn.GetComponent<PlayerTurn>().Begin();
        Invoke("Move", 3.8f);
        Invoke("Attack", 3.9f);
        Invoke("ChooseAttack", 4.0f);
    }
    public void Attack()
    {
        GameObject target = GameObject.Find(PlayerPrefs.GetString("P" + PlayerPrefs.GetInt("E1-AttP") + "-Name"));
        GameObject targetHP = GameObject.Find("P"+PlayerPrefs.GetInt("E1-AttP")+"-Hp");
        GameObject targetG = GameObject.Find("P" + PlayerPrefs.GetInt("E1-AttP") + "-Guard");
        GameObject animg = GameObject.Find("slasher");
        Animator anim = animg.GetComponent<Animator>();
        animg.transform.position = targetHP.transform.position + new Vector3(100, +100, 0); ;
        anim.SetTrigger("Play");
        Invoke("EndAnimation", 1.6f);
        int p = PlayerPrefs.GetInt("E1-AttP");
        int PCHP = PlayerPrefs.GetInt("P"+PlayerPrefs.GetInt("E1-AttP")+"-CHP");
        int PCG = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-CG");
        int Att = 10;
        if ("P" + p + "Status0" == "steadfast" || "P" + p + "Status1" == "steadfast" || "P" + p + "Status2" == "steadfast" || "P" + p + "Status3" == "steadfast")
        {
            PCG -= Att;
        }
        else
        {
            PCG = PCG - ((Att / 2) + (Att % 2));
        }
            if (PCG < 0)
        {
            PCHP = PCHP + PCG;
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-CG", 0);
            PCG = 0;
        }
        else
        {
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-CG", PCG);
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
        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-CHP", PCHP);
        int PMax = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-HP");
        float Percent = ((float)PCHP / (float)PMax);
        targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        PMax = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E1-AttP") + "-Guard");
        Percent = ((float)PCG / (float)PMax);
        targetG.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
    }
    public void Move()
    {
        //4x4 movement
        int time = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = time;
        int rando1 = 0;
        int rando2 = 0;
        int rando3 = 0;
        int rando4 = 0;
        List<int> used = new List<int>();
        rando1 = UnityEngine.Random.Range(0, 4);
        used.Add(rando1);
        rando2 = UnityEngine.Random.Range(0, 4);
        while (used.Contains(rando2))
        {
            rando2 = UnityEngine.Random.Range(0, 4);
        }
        used.Add(rando2);
        rando3 = UnityEngine.Random.Range(0, 4);
        while (used.Contains(rando3))
        {
            rando3 = UnityEngine.Random.Range(0, 4);
        }
        used.Add(rando3);
        rando4 = UnityEngine.Random.Range(0, 4);
        while (used.Contains(rando4))
        {
            rando4 = UnityEngine.Random.Range(0, 4);
        }
        int offset = 0;
        int whilebreak = 0;
        int i = 0;
        int left = PlayerPrefs.GetInt("E1-Loc") - 1;
        int up = PlayerPrefs.GetInt("E1-Loc") + 4;
        int down = PlayerPrefs.GetInt("E1-Loc") - 4;
        int right = PlayerPrefs.GetInt("E1-Loc") + 1;
        Vector3 E1LocQuards = new Vector3(0, 0, 0);
        switch (PlayerPrefs.GetInt("E1-Loc"))
        {
            case 1:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + right + "-Moveable") == 1)
                        {
                            MoveTo(right);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + up + "-Moveable") == 1)
                        {
                            MoveTo(up);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 4:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + left + "-Moveable") == 1)
                        {
                            MoveTo(left);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + up + "-Moveable") == 1)
                        {
                            MoveTo(up);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 13:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + right + "-Moveable") == 1)
                        {
                            MoveTo(right);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + down + "-Moveable") == 1)
                        {
                            MoveTo(down);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 16:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + left + "-Moveable") == 1)
                        {
                            MoveTo(left);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + down + "-Moveable") == 1)
                        {
                            MoveTo(down);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 2:
            case 3:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + left + "-Moveable") == 1)
                        {
                            MoveTo(left);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + right + "-Moveable") == 1)
                        {
                            MoveTo(right);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + up + "-Moveable") == 1)
                        {
                            MoveTo(up);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 5:
            case 9:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + right + "-Moveable") == 1)
                        {
                            MoveTo(right);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + up + "-Moveable") == 1)
                        {
                            MoveTo(up);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + down + "-Moveable") == 1)
                        {
                            MoveTo(down);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 8:
            case 12:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + left + "-Moveable") == 1)
                        {
                            MoveTo(left);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + up + "-Moveable") == 1)
                        {
                            MoveTo(up);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + down + "-Moveable") == 1)
                        {
                            MoveTo(down);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 14:
            case 15:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + left + "-Moveable") == 1)
                        {
                            MoveTo(left);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + right + "-Moveable") == 1)
                        {
                            MoveTo(right);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + down + "-Moveable") == 1)
                        {
                            MoveTo(down);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            case 6:
            case 7:
            case 10:
            case 11:
                {
                    while (whilebreak == 0)
                    {
                        if (used[i] == 0 && PlayerPrefs.GetInt("E-Block-" + left + "-Moveable") == 1)
                        {
                            MoveTo(left);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + right + "-Moveable") == 1)
                        {
                            MoveTo(right);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + up + "-Moveable") == 1)
                        {
                            MoveTo(up);
                            whilebreak = 1;
                        }
                        else if (used[i] == 1 && PlayerPrefs.GetInt("E-Block-" + down + "-Moveable") == 1)
                        {
                            MoveTo(down);
                            whilebreak = 1;
                        }
                        i++;
                        if (i > 4)
                        {
                            whilebreak = 1;
                        }
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    public void MoveTo(int dest)
    {
        GameObject Vill = GameObject.Find("Lord Kalor");
        GameObject VillHp = GameObject.Find("E1-Hp");
        GameObject VillHpBack = GameObject.Find("E1-HpBack");
        GameObject VillGuard = GameObject.Find("E1-Guard");
        GameObject Vill1Status0 = GameObject.Find("E1Status0");
        GameObject VillStatus0X = GameObject.Find("E1Status0X");
        Vector3 E1LocQuards = GameObject.Find("E-Block-" + dest.ToString()).transform.position;
        Vill.transform.position = E1LocQuards + new Vector3(0, +67, -2);
        SpriteRenderer sprite = Vill.GetComponent<SpriteRenderer>();
        int layer = dest + 3;
        layer = layer / 4;
        sprite.sortingLayerName = "Char" + layer;
        VillHp.transform.position = E1LocQuards + new Vector3(-100, -17, 1);
        VillHp = VillHp.transform.GetChild(0).gameObject;
        sprite = VillHp.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Bar" + layer;
        VillHpBack.transform.position = E1LocQuards + new Vector3(0, -17, 1);
        sprite = VillHpBack.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Back" + layer;
        Vill1Status0.transform.position = E1LocQuards + new Vector3(-40, 20, 1);
        sprite = Vill1Status0.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Status" + layer;
        VillStatus0X.transform.position = E1LocQuards + new Vector3(-40, 20, 1);
        VillGuard.transform.position = E1LocQuards + new Vector3(-100, -17, 1);
        VillGuard = VillGuard.transform.GetChild(0).gameObject;
        sprite = VillGuard.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Guard" + layer;
        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
        PlayerPrefs.SetInt("E1-Loc", dest);
        PlayerPrefs.SetInt("E-Block-" + dest + "-Moveable", 0);
    }
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
        EndTurn();

    }

    public void EndTurn()
    {
        StatusEffect.StatusTickEnd("E1");
        GameObject E2 = GameObject.Find("Sapphire Guardian");
        E2.GetComponent<SapphireGuardian>().TakeTurn2();
    }
}
