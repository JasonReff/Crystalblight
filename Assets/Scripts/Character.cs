using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public bool clicked;
    public bool targeting;
    public bool turnTaken;
    public bool canMove;
    public int pNumber;
    public new string name;
    public int location;
    public int health;
    public int maxHealth;
    public int SP;
    public int maxSP;
    public int guard;
    public int maxGuard;
    public int special;
    public int maxSpecial;
    public int attackDamage;
    public int accuracy;
    public int dodge;
    public int critrate;
    public List<Skill.DamageType> weaknesses;
    public List<Skill.DamageType> resistances;
    public string passiveSkill;
    public List<Skill> skills;
    public List<StatusEffect> statuses;
    public string equippedRune;
    public string equippedSigil;
    public string equippedVeil;

    public int vitality;
    public int strength;
    public int intelligence;
    public int dexterity;
    public int endurance;

    public int stageNumber;
    public int combatGuardGained;

    public GameObject HPBar;
    public GameObject SPBar;
    public GameObject GuardBar;

    public CombatSystem combatSystem;

    public Character(int characterNumber, string characterName, int startingVitality, int startingStrength, int startingIntelligence, int startingDexterity, int startingEndurance, Skill startingSkill)
    {
        pNumber = characterNumber;
        name = characterName;
        skills.Add(startingSkill);
        vitality = startingVitality;
        strength = startingStrength;
        intelligence = startingIntelligence;
        dexterity = startingDexterity;
        endurance = startingEndurance;
        maxHealth = 40 + (20 * vitality);
        health = maxHealth;
        maxSP = 30 + (10 * intelligence);
        SP = maxSP;
        attackDamage = 5 + 2 * strength;
        maxGuard = 10 * endurance;
        accuracy = 85 + 2 * dexterity;
        critrate = 5 + 2 * dexterity;
        dodge = 5 + dexterity;
        Skill attack = new Skill.Attack(attackDamage);
        skills.Add(attack);
        Skill defend = new Skill.Defend(endurance);
        skills.Add(defend);
        skills.Add(startingSkill);
    }

    public void GetCharacterData(Character character)
    {
        clicked = character.clicked;
        name = character.name;
        skills = character.skills;
        passiveSkill = character.passiveSkill;
        statuses = character.statuses;
        vitality = character.vitality;
        strength = character.strength;
        intelligence = character.intelligence;
        dexterity = character.dexterity;
        endurance = character.endurance;
        maxHealth = character.maxHealth;
        health = character.health;
        special = character.special;
        maxSpecial = character.maxSpecial;
        SP = character.SP;
        maxSP = character.maxSP;
        attackDamage = character.attackDamage;
        maxGuard = character.maxGuard;
        accuracy = character.accuracy;
        critrate = character.critrate;
        dodge = character.dodge;
        weaknesses = character.weaknesses;
        resistances = character.resistances;
    }
    
    private void Awake()
    {
        clicked = false;
        targeting = false;
        turnTaken = false;
        pNumber = Int32.Parse(this.gameObject.name[1].ToString());
        RetrieveStats();
        LoadSprite.FindSprite(this.gameObject, PlayerPrefs.GetString("P" + pNumber + "-Name"));
        BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
        Destroy(_boxCollider);
        _boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        LoadSprite.FindSprite(GameObject.Find("P" + pNumber + "Holo"), PlayerPrefs.GetString("P" + pNumber + "-Name"));
        InvokeRepeating("CheckIfAlive", 0f, 0.2f);
        InvokeRepeating("UpdateStats", 0f, 0.2f);
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
            this.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void UpdateStats()
    {
        UpdateLocation();
        HPBar.transform.localScale = new Vector3(health / maxHealth, 1, 1);
        SPBar.transform.localScale = new Vector3(SP / maxSP, 1, 1);
        GuardBar.transform.localScale = new Vector3(health / maxHealth, 1, 1);
        if (turnTaken == true) { this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray; }
        else { this.gameObject.GetComponent<SpriteRenderer>().color = Color.white; }
        if (clicked == true) { this.gameObject.tag = "clicked"; } else { this.gameObject.tag = "Untagged"; }
    }

    void UpdateLocation()
    {
        Vector3 tile = GameObject.Find("P-Block-" + location).transform.position;
        this.transform.position = tile + new Vector3(0, 67, -2);
    }
    void OnMouseEnter()
    {
        if (clicked == false)
        {
            if (PlayerPrefs.GetInt("setup") == 0)
            {
                GameObject.Find("CharStatBox").GetComponent<Text>().text = name + " HP: " + health +
                "/" + maxHealth + "    SP: " + SP + "/"
                + maxSP + "\n" + "Guard: " + guard + "/" + maxGuard;
                if (turnTaken == false)
                {
                    //this moves cards
                    SingleTargetSkills.UltSwitch(pNumber);
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
                    GameObject.Find("1-Text").GetComponent<Text>().text = skill1;
                    temp = new Vector3(0 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-2").transform.position = temp;
                    GameObject.Find("2-Text").GetComponent<Text>().text = skill2;
                    temp = new Vector3(100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-3").transform.position = temp;
                    GameObject.Find("3-Text").GetComponent<Text>().text = skill3;
                    temp = new Vector3(200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-4").transform.position = temp;
                    GameObject.Find("4-Text").GetComponent<Text>().text = skill4;
                    temp = new Vector3(300 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
                    GameObject.Find("skillcard-M").transform.position = temp;
                    GameObject.Find("M-Text").GetComponent<Text>().text = PlayerPrefs.GetString("InventoryItem" + PlayerPrefs.GetInt("ActiveItem"));
                    if (canMove == true) 
                    {
                        int left = 0;
                        int right = 0;
                        int up = 0;
                        int down = 0;
                        int[] adjacentTiles = new int[] {left, right, up, down};
                        switch (stageNumber)
                        {
                                case 3:
                                    up = location + 5;
                                    if (up > 25) { up = 0; }
                                    right = location + 1;
                                    if (right%5 == 1) { right = 0; }
                                    left = location - 1;
                                    if (left%5 == 0) { left = 0; }
                                    down = location - 5;
                                    if (down < 1) { down = 0; }
                                    break;
                                case 2:
                                    up = location + 4;
                                    if (up > 16) { up = 0; }
                                    right = location + 1;
                                    if (right%4 == 1) { right = 0; }
                                    left = location - 1;
                                    if (left%4 == 0) { left = 0; }
                                    down = location - 4;
                                    if (down < 1) { down = 0; }
                                    break;
                                case 1:
                                    up = location + 3;
                                    if (up > 9) { up = 0; }
                                    right = location + 1;
                                    if (right%3 == 1) { right = 0; }
                                    left = location - 1;
                                    if (left%3 == 0) { left = 0; }
                                    down = location - 3;
                                    if (down < 1) { down = 0; }
                                    break;
                        }
                        for (int t = 0; t <= 3; t++)
                        {
                        int tile = adjacentTiles[t];
                        if (tile != 0 && GameObject.Find("P-Block-" + tile).GetComponent<PBlock>().movable == true)
                        {
                            GameObject.Find("P-Block-" + tile).GetComponent<SpriteRenderer>().color = Color.green;
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
        if (combatSystem.activeSkill != null && combatSystem.skillTargeting != "FriendlyTargetOther")
        {
            PlayerPrefs.SetInt("PNumber", pNumber);
        }
        else if (combatSystem.activeSkill != null && combatSystem.skillTargeting == "FriendlyTargetOther" && clicked == false)
        {
            PlayerPrefs.SetInt("PNumber", pNumber);
        }
        else 
        {
            if (turnTaken == false)
            {
                OnMouseExit();
                OnMouseEnter();
                for (int p = 1; p <= 25; p++) 
                { 
                    if (GameObject.Find("P" + p) != null) 
                    { 
                        GameObject.Find("P" + p).GetComponent<Character>().clicked = false; 
                    } 
                }
                for (int e = 1; e <= 25; e++)
                {
                    if (GameObject.Find("E" + e) != null)
                    {
                        GameObject.Find("E" + e).GetComponent<Enemy>().clicked = false;
                    }
                }
                clicked = true;
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
        if (clicked == false)
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