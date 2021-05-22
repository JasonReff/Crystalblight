using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Text textbox;

    public bool clicked;
    public bool turnTaken;
    public int eNumber;
    public int location;
    public new string name;
    public int health;
    public int maxHealth;
    public int guard;
    public int maxGuard;
    public int guardGain;
    public int attack;
    public int accuracy;
    public int dodge;
    public int critrate;
    public List<Skill.DamageType> weaknesses;
    public List<Skill.DamageType> resistances;
    public List<EnemySkill> enemySkills;
    public List<StatusEffect> statusEffects;
    public Skill.DamageType damageType;

    public int target;

    public GameObject HPBar;
    public GameObject GuardBar;
    void Awake()
    {
        clicked = false;
        turnTaken = false;
        eNumber = Int32.Parse(this.gameObject.name[1].ToString());
        string tile = PlayerPrefs.GetString("CurrentTile");
        if (tile[0] == 'C')
        {
            int combatNumber = 0;
            if (tile.Length == 7)
                {
                    combatNumber = Int32.Parse(tile[6].ToString());
                }
            if (tile.Length == 8)
                {
                    combatNumber = Int32.Parse(tile[6].ToString() + tile[7].ToString());
                }
            name = PlayerPrefs.GetString("Combat" + combatNumber + "E" + eNumber + "-Name");
        }
        if (tile[0] == 'M')
        {
            name = PlayerPrefs.GetString("MinibossE" + eNumber + "-Name");
        }
        if (tile[0] == 'B')
        {
            name = PlayerPrefs.GetString("BossE" + eNumber + "-Name");
        }
        PlayerPrefs.SetInt("E" + eNumber + "-Loc", 0);
        SetLoc();
        RetrieveStats();
        PlayerPrefs.SetInt("E" + eNumber + "-AttL", 0);
        ChooseAttack();
        InvokeRepeating("CheckIfAlive", 0f, 0.3f);
        InvokeRepeating("UpdateStats", 0f, 0.3f);
    }

    void CheckIfAlive()
    {
        if (health <= 0)
        {
            StartCoroutine(FadeOut());
            Destroy(this);
            CancelInvoke();
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1; f > 0; f -= 0.2f)
        {
            Color color = this.GetComponent<SpriteRenderer>().color;
            this.GetComponent<SpriteRenderer>().color = new Color (color.r, color.g, color.b, f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void UpdateStats()
    {
        UpdateLocation();
        HPBar.transform.localScale = new Vector3 (health / maxHealth, 1, 1);
        GuardBar.transform.localScale = new Vector3(health / maxHealth, 1, 1);
        if (clicked == true) { this.gameObject.tag = "clicked"; } else { this.gameObject.tag = "Untagged"; }
    }

    void UpdateLocation()
    {
        Vector3 tile = GameObject.Find("E-Block-" + location).transform.position;
        this.transform.position = tile + new Vector3(0, 67, -2);
    }
    void SetLoc()
    {
        int time = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = time;
        // the seed a number in that range
        int Loc = 0;
        while (Loc == 0)
        {
            Loc = UnityEngine.Random.Range(1, 16);
            if (GameObject.Find("E-Block-" + Loc).GetComponent<PBlock>().movable == false)
            {
                Loc = 0;
            }
            GameObject.Find("E-Block-" + Loc).GetComponent<PBlock>().movable = false;
        }
        location = Loc;
        GameObject Vill = GameObject.Find("E" + eNumber);
        LoadSprite.FindSprite(Vill, name);
        Vector3 E1LocQuards = GameObject.Find("E-Block-" + Loc.ToString()).transform.position;
        Vill.transform.position = E1LocQuards + new Vector3(0, +67, -3);
    }
    void OnMouseEnter()
    {
        if (name.Substring(name.Length - 8) == "(Stage1)" || name.Substring(name.Length - 8) == "(Stage2)" || name.Substring(name.Length - 8) == "(Stage3)")
        {
            name = name.Remove(name.Length - 9, 9);
        }
        textbox.text = name + " Guard: " + PlayerPrefs.GetInt("E1-CG") + "/" + PlayerPrefs.GetInt("E1-Guard") + " HP: " + PlayerPrefs.GetInt("E1-CHP")
            + "/" + PlayerPrefs.GetInt("E1-HP") + "\n" + "Intent: " + PlayerPrefs.GetString("E1-CAtt") + " " + PlayerPrefs.GetInt("E1-Attack");
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
        for (int p = 1; p <= 25; p++) { if (GameObject.Find("P" + p) != null) { GameObject.Find("P" + p).GetComponent<Character>().clicked = false; } }
        for (int e = 1; e <= 25; e++) { if (GameObject.Find("E" + e) != null) { GameObject.Find("E" + e).GetComponent<Enemy>().clicked = false; } }
        clicked = true;
    }
    public void GiveTurn()
    {
        for (int p = 1; p <= 25; p++) { if (GameObject.Find("P" + p) != null) { GameObject.Find("P" + p).GetComponent<Character>().clicked = false; } }
        for (int p = 1; p<= 25; p++) { if (GameObject.Find("P" + p) != null) { GameObject.Find("P" + p).GetComponent<Character>().canMove = true; } }
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
        if (PlayerPrefs.GetString("E1StartUp") == "null")
            {
            int choice = UnityEngine.Random.Range(1, 4);
            PlayerPrefs.SetInt("E1-Choice", choice);
            if (choice == 1)
            {
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
            if (choice == 2)
            {
                PlayerPrefs.SetString("E1-CAtt", "Defend");
                PlayerPrefs.SetInt("E1-AttP", 0);
                PlayerPrefs.SetInt("E1-AttL", 0);
            }
            if (choice == 3)
            {
                int skillChoice;
                do
                {
                    skillChoice = UnityEngine.Random.Range(1, 7);
                }
                while (PlayerPrefs.GetString("E1-Skill" + skillChoice) == "null");
                PlayerPrefs.SetString("E1-CAtt", PlayerPrefs.GetString("E1-Skill" + skillChoice));
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
        }
        else
        {
            PlayerPrefs.SetString("E1-CAtt", PlayerPrefs.GetString("E1StartUp"));
            int time = (int)System.DateTime.Now.Ticks;
            UnityEngine.Random.seed = time;
            int p = PlayerPrefs.GetInt("E1-AttP");
            while (PlayerPrefs.GetInt("P" + p + "-CHP") == 0)
            {
                p = UnityEngine.Random.Range(1, 3);
                PlayerPrefs.SetInt("E1-AttP", p);
                PlayerPrefs.SetInt("E1-AttL", PlayerPrefs.GetInt("P" + p + "-Loc"));
            }
        }
    }
    public void TakeTurn()
    {
        for (int e = 1; e <= 8; e++)
        {
            StatusEffect.StatusTickStart("E" + e);
        }
        GameObject PlayerTurn = GameObject.Find("EnemyTurn");
        PlayerTurn.GetComponent<PlayerTurn>().Begin();
        //forgot C lmao
        if (PlayerPrefs.GetInt("E1-CHP") > 0)
        {
            Invoke("Move", 3.8f);
            int choice = PlayerPrefs.GetInt("E1-Choice");
            if (choice == 1) { Invoke("Attack", 3.9f);}
            if (choice == 2) { Invoke("Defend", 3.9f);}
            if (choice == 3) { Invoke("Skill", 3.9f);}
            Invoke("ChooseAttack", 4.0f);
        }
        else
        {
            GameObject E2 = GameObject.Find("E2");
            E2.GetComponent<E2>().TakeTurn2();
        }
    }

    public void Attack()
    {
        Damage(target, this.attack);
    }
    public void Damage(int p, int damage)
    {
        Character target = GameObject.Find("P" + p).GetComponent<Character>();
        int PCHP = target.health;
        int PCG = target.guard;
        StartCoroutine(Animation(damageType));
        if (target.weakness1 == damageType || target.weakness2 == damageType)
        {
            damage = (int)Math.Round((float)damage * 1.5, 1);
        }
        if (target.resistance1 == damageType || PlayerPrefs.GetString("P" + p + "-Resistance2") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance3") == damageType)
        {
            damage = (int)Math.Round((float)damage * 0.75, 1);
        }
        if (target.status0 == "steadfast" || target.status1 == "steadfast" || target.status2 == "steadfast" || target.status3 == "steadfast")
        {
            PCG -= damage;
        }
        else if (target.status0 == "vulnerable" || target.status1 == "vulnerable" || target.status2 == "vulnerable" || target.status3 == "vulnerable")
        {
            PCHP -= damage;
        }
        else
        {
            PCG = PCG - ((damage / 2) + (damage % 2));
            PCHP = PCHP - ((damage / 2));
        }
        if (PCG < 0)
        {
            PCHP = PCHP + PCG;
            PCG = 0;
        }
        target.health = PCHP;
        target.guard = PCG;
        EndTurn();
    }

    public void Defend()
    {
        guard += guardGain;
        if (guard > maxGuard)
        {
            guard = maxGuard;
        }
        StatusEffect.InflictStatusEnemy("steadfast", eNumber, 1);
        EndTurn();
    }

    public void Skill() 
    {
        string skill = String.Concat(PlayerPrefs.GetString("E1-CAtt").Where(c => !Char.IsWhiteSpace(c)));
        SendMessage(skill);
        EndTurn();
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
        GameObject Vill = GameObject.Find("E1");
        Vector3 E1LocQuards = GameObject.Find("E-Block-" + dest.ToString()).transform.position;
        Vill.transform.position = E1LocQuards + new Vector3(0, +67, -2);
        SpriteRenderer sprite = Vill.GetComponent<SpriteRenderer>();
        int layer = dest + 3;
        layer = layer / 4;
        sprite.sortingLayerName = "Char" + layer;
        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E1-Loc") + "-Moveable", 1);
        PlayerPrefs.SetInt("E1-Loc", dest);
        PlayerPrefs.SetInt("E-Block-" + dest + "-Moveable", 0);
    }

    IEnumerator Animation(string animation)
    {
        GameObject effect = GameObject.Find("SkillEffect");
        Animator anim = effect.GetComponent<Animator>();
        GameObject target = GameObject.Find("P" + PlayerPrefs.GetInt("E1-AttP"));
        effect.transform.position = target.transform.position;
        anim.SetBool(animation, true);
        anim.SetBool("null", false);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = new Vector3(0, 0, -100);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool(animation, false);
        anim.SetBool("null", true);
        LoadSprite.FindSprite(effect, "null");
        InputDiss.transform.position = new Vector3(0, -2000, -100);
    }

    public void EndTurn()
    {
        StatusEffect.StatusTickEnd("E1");
        if (GameObject.Find("E2") != null)
        {
            GameObject E2 = GameObject.Find("E2");
            E2.GetComponent<E2>().TakeTurn2();
        }
        else
        {
            GiveTurn();
        }
    }
}