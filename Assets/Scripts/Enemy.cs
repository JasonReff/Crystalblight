using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;

[Serializable]
public class Enemy : MonoBehaviour
{
    public Text textbox;

    public bool clicked;
    public bool turnTaken;
    public int eNumber;
    public CombatTile location;
    public new string name;
    public int health;
    public int maxHealth;
    public int guard;
    public int maxGuard;
    public int guardGain;
    public int attackDamage;
    public int accuracy;
    public int dodge;
    public int critrate;
    public int XP;
    public List<Skill.DamageType> weaknesses;
    public List<Skill.DamageType> resistances;
    public List<EnemySkill> enemySkills;
    public List<StatusEffect> statusEffects;
    public Skill.DamageType damageType;

    public int target;

    public GameObject HPBar;
    public GameObject GuardBar;

    public CombatSystem combatSystem;

    public Enemy()
    {

    }
    
    public Enemy(string enemyName)
    {
        name = enemyName;
        string fileName = "EnemyData.csv";
        maxHealth = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "MaxHealth"));
        health = maxHealth;
        maxGuard = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "MaxGuard"));
        guard = maxGuard;
        guardGain = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "GuardGain"));
        attackDamage = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "AttackDamage"));
        accuracy = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "Accuracy"));
        dodge = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "Dodge"));
        critrate = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "CritRate"));
        XP = Int32.Parse(ReadPref.FindFromCSV(fileName, name + "XP"));
        EnemySkill attack = new EnemyAttack();
        enemySkills.Add(attack);
        EnemySkill defend = new EnemyDefend();
        enemySkills.Add(defend);

    }

    void CheckIfAlive()
    {
        if (health <= 0)
        {
            StartCoroutine(FadeOut());
            Destroy(gameObject);
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
        CombatTileSet tileSet = combatSystem.tileSets.Find(x => x.characterOrEnemy == CombatTileSet.CharacterOrEnemy.Enemy);
        List<CombatTile> emptyTiles = tileSet.tiles.FindAll(x => x.movable == true);
        int randomEmptyTile = UnityEngine.Random.Range(0, emptyTiles.Count - 1);
        CombatTile newLocation = tileSet.tiles[randomEmptyTile];
        location = newLocation;
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
}