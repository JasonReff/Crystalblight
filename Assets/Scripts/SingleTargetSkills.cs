using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SingleTargetSkills : MonoBehaviour
{
    private void Start()
    {
        for (int p = 1; p <= 2; p++)
        {
            for (int i = 1; i <= 4; i++)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("P" + p + "-Skill-" + i) + "-Played", 0);
                PlayerPrefs.SetInt("P" + p + "CombatGuardGained", 0);
            }
        }

    }

    public void OnMouseDown()
    {
        string activeSkill = PlayerPrefs.GetString("ActiveSkill");
        if (PlayerPrefs.GetString(activeSkill + "-Targeting") == "SingleTarget" || activeSkill == "Attack")
        {
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsWhiteSpace(c)));
            activeSkill = String.Concat(activeSkill.Where(c => !Char.IsSymbol(c)));
            Invoke(activeSkill, 0.1f);
        }
    }

    public void UseSkill()
    {
        CombatSystem combatSystem = GameObject.Find("CombatSystem").GetComponent<CombatSystem>();
        string activeSkill = combatSystem.activeSkill;
        Invoke(activeSkill, 0f);
    }

    //The following are real skills
    void Attack()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int Att = PlayerPrefs.GetInt("P" + p + "-Attack");
        Flamebearer(p, e);
        string damageType = "Physical";//PlayerPrefs.GetString("P" + p + "AttackDamageType");
        Damage(p, e, Att, damageType);
        EndSkill(p);
        SkillReset();
    }

    public void Damage(int p, int e, int Att, string damageType)
    {
        //accuracyCheck
        Character player = GameObject.Find("P" + p).GetComponent<Character>();
        Enemy enemy = GameObject.Find("E" + e).GetComponent<Enemy>();
        int E1CHP = enemy.GetComponent<Enemy>().health;
        int E1CG = enemy.GetComponent<Enemy>().guard;
        int accuracyCheck = UnityEngine.Random.Range(1, 101);
        if (player.accuracy - enemy.dodge < accuracyCheck)
        {
            Miss(e);
        }
        else
        {
            StartCoroutine(Animation(damageType));
            if (enemy.weakness1 == damageType || enemy.weakness2 == damageType)
            {
                Att = (int)Math.Round((float)Att * 1.5, 1);
            }
            if (enemy.resistance1 == damageType
                || enemy.resistance2 == damageType
                || enemy.resistance3 == damageType)
            {
                Att = (int)Math.Round((float)Att * 0.75, 1);
            }
            int critCheck = UnityEngine.Random.Range(1, 101);
            if (player.critrate > critCheck)
            {
                Att = (int)Math.Round((float)Att * 1.5, 1);
                Crit(e);
            }
            if (damageType == "Fire")
            {
                if (player.status0 == "firestorm" ||
                    player.status1 == "firestorm" ||
                    player.status2 == "firestorm" ||
                    player.status3 == "firestorm")
                        { Att = 2 * Att;}
                SpecialCharge(p, Att, "Flamebearer");
            }
            if (PlayerPrefs.GetString("E" + e + "Status0") == "steadfast" ||
                PlayerPrefs.GetString("E" + e + "Status1") == "steadfast" || 
                PlayerPrefs.GetString("E" + e + "Status2") == "steadfast" || 
                PlayerPrefs.GetString("E" + e + "Status3") == "steadfast")
            {
                E1CG -= Att;
            }
            else if (PlayerPrefs.GetString("E" + e + "Status0") == "vulnerable" || PlayerPrefs.GetString("E" + e + "Status1") == "vulnerable" || PlayerPrefs.GetString("E" + e + "Status2") == "vulnerable" || PlayerPrefs.GetString("E" + e + "Status3") == "vulnerable")
            {
                E1CHP -= Att;
            }
            else
            {
                E1CG = E1CG - ((Att / 2) + (Att % 2));
                E1CHP = E1CHP - Att / 2;
            }
            if (E1CG < 0)
            {
                E1CHP = E1CHP + E1CG;
                E1CG = 0;
            }
            enemy.health = E1CHP;
            enemy.guard = E1CG;
        }
    }

    void HealSP(int player, int SPGain)
    {
        FriendlyTargetSkills.HealSP(player, SPGain);
    }
    public int Target()
    {
        int p = 0;
        for (int player = 1; player <= 25; player++)
        {
            if (GameObject.Find("P" + player) != null)
            {
                if (GameObject.Find("P" + player).GetComponent<Character>().targeting == true)
                {
                    p = player;
                    break;
                }
            }
        }
        return p;

    }

    int RandomEnemy()
    {
        int enemyCount = 0;
        for (int i = 1; i <= 4; i++)
        {
            if (PlayerPrefs.GetString("E" + i + "-Name") != "null")
            {
                enemyCount++;
            }
        }
        int e = 0;
        do
        {
            e = UnityEngine.Random.Range(1, enemyCount + 1);
        }
        while (PlayerPrefs.GetInt("E" + e + "-CHP") <= 0);
        return e;
    }
    public static void SPSpend(int p, int SPCost)
    {
        int P1CSP = PlayerPrefs.GetInt("P" + p + "-CSP");
        int P1SP = PlayerPrefs.GetInt("P" + p + "-SP");
        P1CSP = P1CSP - SPCost;
        PlayerPrefs.SetInt("P" + p + "-CSP", P1CSP);
        float PercentSP = ((float)P1CSP / (float)P1SP);
        GameObject SPBar = GameObject.Find("P" + p + "-Sp");
        SPBar.gameObject.transform.localScale = new Vector3(PercentSP, 1, 1);
    }

    public static void ItemUse(string itemName)
    {
        PlayerPrefs.SetInt(itemName + "Count", PlayerPrefs.GetInt(itemName + "Count") - 1);
        if (PlayerPrefs.GetInt(itemName + "Count") < 1)
        {
            int activeItemNumber = PlayerPrefs.GetInt("ActiveItem");
            PlayerPrefs.SetInt("ActiveItem", activeItemNumber++);
            //need a way to cycle to the next item with count 1 or higher
            //need a check for if there are no items in inventory
        }
    }

    void SkillReset()
    {
        PlayerPrefs.SetString("ActiveSkill", "None");
        PlayerPrefs.SetInt("ENumber", 0);
        PlayerPrefs.SetInt("PNumber", 0);
    }

    IEnumerator Animation(string animation)
    {
        PlayerPrefs.SetInt("Processing", 1);
        GameObject effect = GameObject.Find("SkillEffect");
        Animator anim = effect.GetComponent<Animator>();
        effect.transform.position = this.transform.position;
        anim.SetBool(animation, true);
        anim.SetBool("null", false);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = new Vector3(0, 0, -100);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool(animation, false);
        anim.SetBool("null", true);
        LoadSprite.FindSprite(effect, "null");
        InputDiss.transform.position = new Vector3(0, -2000, -100);
        PlayerPrefs.SetInt("Processing", 0);
    }

    //items
    void Matchstick()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        Damage(p, e, 5, "Fire");
        StatusEffect.InflictStatusEnemy("burning", e, 5);
        ItemUse("Matchstick");
        EndSkill(p);
        SkillReset();
    }

    void Fira()
    {
        int p = Target();
        if (p != 0)
        {
            PlayerPrefs.SetInt("Processing", 1);
            int e = PlayerPrefs.GetInt("ENumber");
            Vector3 EBox5 = this.transform.position;
            GameObject animg = GameObject.Find("Fire");
            Animator anim = animg.GetComponent<Animator>();
            animg.transform.position = EBox5;
            anim.SetTrigger("Play");
            Vector3 ScreenPos = new Vector3(0, -538, -100);
            GameObject InputDiss = GameObject.Find("InputDiss");
            InputDiss.transform.position = ScreenPos;
            Invoke("EndAnimationFire", 0.8f);
            int Att = PlayerPrefs.GetInt("P" + p + "-INT") * 30;
            string damageType = "Fire";
            SPSpend(p, 12);
            Damage(p, e, Att, damageType);
            int collision = Push(e);
            Collision(e, collision, 10, "null", 0);
            EndSkill(p);
        }
        SkillReset();
    }

    void QuickSlice()
    {
        int p = Target();
        PlayerPrefs.SetInt("Processing", 1);
        int e = PlayerPrefs.GetInt("ENumber");
        Vector3 EBox5 = this.transform.position;
        GameObject animg = GameObject.Find("Fire");
        Animator anim = animg.GetComponent<Animator>();
        animg.transform.position = EBox5;
        anim.SetTrigger("Play");
        Vector3 ScreenPos = new Vector3(0, -538, -100);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimationFire", 0.8f);
        int Att = PlayerPrefs.GetInt("P" + p + "-DEX") + 3;
        SPSpend(p, 4);
        Damage(p, e, Att, "Physical");
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played") == 1)
        {
            EndSkill(p);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played", 1);
        }
        SkillReset();
    }

    void IronCleaver()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        Damage(p, e, PlayerPrefs.GetInt("P" + p + "CombatGuardGained"), "Physical");
        UltFinish(p);
        EndSkill(p);
        SkillReset();
    }

    void Poison()
    {
        int p = Target();
        PlayerPrefs.SetInt("Processing", 1);
        int e = PlayerPrefs.GetInt("ENumber");
        Vector3 EBox5 = this.transform.position;
        GameObject animg = GameObject.Find("Fire");
        Animator anim = animg.GetComponent<Animator>();
        animg.transform.position = EBox5;
        anim.SetTrigger("Play");
        Vector3 ScreenPos = new Vector3(0, -538, -100);
        GameObject InputDiss = GameObject.Find("InputDiss");
        InputDiss.transform.position = ScreenPos;
        Invoke("EndAnimationFire", 0.8f);
        string status = "poison";
        SPSpend(p, 5);
        StatusEffect.InflictStatusEnemy(status, e, 5);
        EndSkill(p);
        SkillReset();
    }

    void EldritchArmor()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        GuardGain(p, 4 * PlayerPrefs.GetInt("P" + p + "-END"));
        SPSpend(p, 5);
        StatusEffect.InflictStatusEnemy("alarm", e, 2);
        EndSkill(p);
        SkillReset();
    }

    void EnergyAbsorption()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int enemyGuard = PlayerPrefs.GetInt("E" + e + "-CG");
        int enemyMaxGuard = PlayerPrefs.GetInt("E" + e + "-Guard");
        int absorption = 3 * PlayerPrefs.GetInt("P" + p + "-INT");
        if (enemyGuard >= absorption)
        {
            enemyGuard -= absorption;
        }
        else
        {
            absorption = enemyGuard;
            enemyGuard = 0;
        }
        float enemyPercent = (float)enemyGuard / (float)enemyMaxGuard;
        GameObject enemyGuardBar = GameObject.Find("E" + e + "-Guard");
        enemyGuardBar.transform.localScale = new Vector3(enemyPercent, 1, 1);
        GuardGain(p, absorption);
        SPSpend(p, 5);
        EndSkill(p);
        SkillReset();
    }

    void BraveSword()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        Invoke("EndAnimationFire", 0.8f);
        Damage(p, e, 5 + 2 * PlayerPrefs.GetInt("P" + p + "-STR"), "Physical");
        SPSpend(p, 4);
        StatusEffect.InflictStatusCharacter("decoy", p, 1);
        SpecialCharge(p, 1, "Ancient Champion");
        EndSkill(p);
        SkillReset();
    }

    void Backswing()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        Damage(p, e, 10 + 2 * PlayerPrefs.GetInt("P" + p + "-STR"), "Physical");
        SPSpend(p, 8);
        StatusEffect.InflictStatusCharacter("counter", p, 1);
        SpecialCharge(p, 1, "Counterstrike");
        EndSkill(p);
        SkillReset();
    }

    void TitansClash()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int decoy = 0;
        for (int x = 0; x <= 3; x++)
        {
            if (PlayerPrefs.GetString("P" + p + "-Status" + x) == "decoy")
            {
                decoy = PlayerPrefs.GetInt("P" + p + "-Status" + x + "X");
            }
        }
        Damage(p, e, 14 * decoy, "Physical");
        SPSpend(p, 22);
        EndSkill(p);
        SkillReset();
    }


    void HeatBlast()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int damage = 8 + PlayerPrefs.GetInt("P" + p + "-INT");
        if (GameObject.Find("E-Block-25") != null)
        {
            if (PlayerPrefs.GetInt("E" + e + "-Loc") == 1 || PlayerPrefs.GetInt("E" + e + "-Loc") == 6 || PlayerPrefs.GetInt("E" + e + "-Loc") == 11 || PlayerPrefs.GetInt("E" + e + "-Loc") == 16 || PlayerPrefs.GetInt("E" + e + "-Loc") == 21)
            {
                damage += 5;
            }
        }
        else if (GameObject.Find("E-Block-16") != null)
        {
            if (PlayerPrefs.GetInt("E" + e + "-Loc") == 1 || PlayerPrefs.GetInt("E" + e + "-Loc") == 5 || PlayerPrefs.GetInt("E" + e + "-Loc") == 9 || PlayerPrefs.GetInt("E" + e + "-Loc") == 13)
            {
                damage += 5;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("E" + e + "-Loc") == 1 || PlayerPrefs.GetInt("E" + e + "-Loc") == 4 || PlayerPrefs.GetInt("E" + e + "-Loc") == 7)
            {
                damage += 5;
            }
        }
        Damage(p, e, damage, "Fire");
        SPSpend(p, 3);
        EndSkill(p);
        SkillReset();
    }

    void ThirdDegree()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        Damage(p, e, 16 + 2 * PlayerPrefs.GetInt("P" + p + "-INT"), "Fire");
        SPSpend(p, 12);
        StatusEffect.InflictStatusEnemy("scarred", e, 4);
        EndSkill(p);
        SkillReset();
    }

    void Combustion()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        Damage(p, e, 11 + PlayerPrefs.GetInt("P" + p + "-INT"), "Fire");
        SPSpend(p, 10);
        for (int i = 0; i <= 3; i++)
        {
            if (PlayerPrefs.GetString("E" + e + "Status" + i) == "burning")
            {
                Damage(p, e, 10, "Explosive");
                StatusEffect.StatusLockEnemy("burning", e);
            }
        }
        EndSkill(p);
        SkillReset();
    }

    void Incinerate()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int damage = 25 + PlayerPrefs.GetInt("P" + p + "-INT");
        SPSpend(p, 18);
        Damage(p, e, damage, "Fire");
        StatusEffect.InflictStatusEnemy("burning", e, 10);
        EndSkill(p);
        SkillReset();
    }

    void WinterShard()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int damage = 6 + PlayerPrefs.GetInt("P" + p + "-INT");
        SPSpend(p, 2);
        Damage(p, e, damage, "Frost");
        StatusEffect.InflictStatusEnemy("frozen", e, 1);
        EndSkill(p);
        SkillReset();
    }

    void CreepingCold()
    {
        int p = Target();
        int e = PlayerPrefs.GetInt("ENumber");
        int damage = 14 + PlayerPrefs.GetInt("P" + p + "-INT");
        SPSpend(p, 7);
        Damage(p, e, damage, "Frost");
        StatusEffect.InflictStatusEnemy("shiver", e, 5);
        EndSkill(p);
        SkillReset();
    }

    void Cloudburst()
    {
        int p = Target();
        int e = 0;
        switch (PlayerPrefs.GetString("P" + p + "StartUp"))
        {
            case "Cloudburst":
                e = PlayerPrefs.GetInt("P" + p + "EnemyTarget");
                if (PlayerPrefs.GetInt("E" + e + "-CHP") == 0) {e = RandomEnemy(); }
                Damage(p, e, 25 + 2 * PlayerPrefs.GetInt("P" + p + "-INT"), "Electric");
                StatusEffect.InflictStatusEnemy("weakened", e, 3);
                EndSkill(p);
                PlayerPrefs.SetString("P" + p + "StartUp", "null");
                break;
            case "null":
                e = PlayerPrefs.GetInt("ENumber");
                SPSpend(p, 14);
                PlayerPrefs.SetString("P" + p + "StartUp", "Cloudburst");
                PlayerPrefs.SetInt("P" + p + "EnemyTarget", e);
                EndSkill(p);
                break;
        }
        SkillReset();
    }

    //used for default
    void None()
    {
    }

    //used for turn order
    public void ETakeTurn()
    {
        SendMessage("TakeTurn");
    }

    void EndSkill(int p)
    {
        GameObject hero = GameObject.Find("P" + p);
        hero.GetComponent<SpriteRenderer>().color = Color.grey;
        PlayerPrefs.SetInt("P" + p + "-TurnTaken", 1);
        EndPlayerTurn();
    }

    public static void FastSkill(int p)
    {
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played") == 1)
        {
            SingleTargetSkills singleTargetSkills = new SingleTargetSkills();
            singleTargetSkills.EndSkill(p);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("ActiveSkill") + "-Played", 1);
        }
    }

    void GuardGain(int p, int guardGain)
    {
        int p1CG = PlayerPrefs.GetInt("P" + p + "-CG");
        int p1MaxGuard = PlayerPrefs.GetInt("P" + p + "-Guard");
        if (guardGain > (p1MaxGuard - p1CG)) { guardGain = p1MaxGuard - p1CG; }
        p1CG += guardGain;
        if (p1CG >= p1MaxGuard)
        {
            p1CG = p1MaxGuard;
        }
        PlayerPrefs.SetInt("P" + p + "-CG", p1CG);
        SingleTargetSkills.SpecialCharge(p, guardGain, "Iron Will");
        PlayerPrefs.SetInt("P" + p + "CombatGuardGained", PlayerPrefs.GetInt("P" + p + "CombatGuardGained") + guardGain);
        GameObject GBar = GameObject.Find("P" + p + "-Guard");
        float PercentG = ((float)p1CG / (float)p1MaxGuard);
        GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
    }

    public void EndPlayerTurn()
    {
        for (int p = 1; p<=2; p++)
        {
            for (int i = 1; i <=4; i++)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("P" + p + "-Skill-" + i) + "-Played", 0);
            }
        }
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

    void GainDecoy(int p, int amount)
    {
        StatusEffect.InflictStatusCharacter("decoy", p, amount);
        SpecialCharge(p, amount, "Ancient Champion");
    }

    void Flamebearer(int p, int e)
    {
        if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Flamebearer1")
        {
            StatusEffect.InflictStatusEnemy("burning", e, 1);
        }
        else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Flamebearer2")
        {
            StatusEffect.InflictStatusEnemy("burning", e, 2);
            HealSP(p, 1);
        }
        else if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == "Flamebearer3")
        {
            StatusEffect.InflictStatusEnemy("burning", e, 3);
            HealSP(p, 2);
        }
    }

    void Miss(int e)
    {
        Vector3 loc = GameObject.Find("E" + e.ToString()).transform.localPosition;
        GameObject.Find("Miss").transform.localPosition = loc;
        Invoke("MissMove", 1.0f);
    }

    public void MissMove()
    {
        GameObject.Find("Miss").transform.localPosition = new Vector3(-3000, 0, -1);
    }

    void Crit(int e)
    {
        Vector3 loc = GameObject.Find("E" + e.ToString()).transform.localPosition;
        GameObject.Find("Crit").transform.localPosition = loc;
        Invoke("CritMove", 1.0f);
    }

    public void CritMove()
    {
        GameObject.Find("Crit").transform.localPosition = new Vector3(-3000, 0, -1);
    }

    public static void UltSwitch(int p)
    {
        
            int special = PlayerPrefs.GetInt("P" + p + "-SpecialMeter");
            int specialMax = PlayerPrefs.GetInt("P" + p + "-SpecialMax");
            GameObject specialMeter = GameObject.Find("Special");
            specialMeter.transform.localScale = new Vector3((float)special / (float)specialMax, 1, 1);
            if (special == specialMax)
            {
                GameObject.Find("A-Text").GetComponent<Text>().text = PlayerPrefs.GetString("P" + p + "-Ultimate");
            }
            else
            {
            GameObject.Find("A-Text").GetComponent<Text>().text = "Attack";
            }
        
    }

    public static void UltFinish(int p)
    {
        PlayerPrefs.SetInt("P" + p + "-SpecialMeter", 0);
        PlayerPrefs.SetInt("P" + p + "-SpecialMax", (int)(1.5 * PlayerPrefs.GetInt("P" + p + "-SpecialMax")));
        GameObject specialMeter = GameObject.Find("Special");
        specialMeter.transform.localScale = new Vector3(0, 1, 1);
    }

    public static void SpecialCharge(int p, int amount, string specialName)
    {
        if (PlayerPrefs.GetString("P" + p + "-PassiveSkill") == specialName)
        {
            int special = PlayerPrefs.GetInt("P" + p + "-Special");
            int specialMax = PlayerPrefs.GetInt("P" + p + "-SpecialMax");
            special += amount;
            if (special >= specialMax) { special = specialMax; }
            GameObject specialBar = GameObject.Find("Special");
            float specialPercent = (float)special / (float)specialMax;
            specialBar.transform.localScale = new Vector3(specialPercent, 1, 1);
        }
    }



    int Push(int e)
    {
        int collision = 0;
        GameObject Vill = this.gameObject;
    int loc = PlayerPrefs.GetInt("E" + e + "-Loc");
    loc = loc + 1;
        int m = PlayerPrefs.GetInt("E-Block-" + loc + "-Moveable");
        if (loc != 5 && loc != 9 && loc != 13 && loc != 17 && m == 1)
        {
            SendMessage("MoveTo", loc);
        }
        if (m == 0)
        {
            collision = 1;
        }
        return collision;
    }

    int Pull(int e)
    {
        int collision = 0;
        GameObject Vill = this.gameObject;
        int loc = PlayerPrefs.GetInt("E" + e + "-Loc");
        loc = loc - 1;
        int m = PlayerPrefs.GetInt("E-Block-" + loc + "-Moveable");
        if (loc != 0 && loc != 4 && loc != 8 && loc != 12 && m == 1)
        {
            SendMessage("MoveTo", loc);
        }
        if (m == 0)
        {
            collision = 2;
        }
        return collision;
    }

    void Collision(int e, int collision, int damage, string status, int statusX)
    {
        int loc = 0;
        if (collision == 1)
        {
            loc = PlayerPrefs.GetInt("E" + e + "-Loc") + 1;
            for (int i = 1; i <= 4; i++)
            {
                if (loc == PlayerPrefs.GetInt("E" + i + "Loc"))
                {
                    StatusEffect.InflictStatusEnemy(status, e, statusX);
                    StatusEffect.InflictStatusEnemy(status, i, statusX);
                    int e1HP = PlayerPrefs.GetInt("E" + e + "-CHP");
                    int e2HP = PlayerPrefs.GetInt("E" + i + "-CHP");
                    e1HP -= damage;
                    e2HP -= damage;
                    if (e1HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", e1HP);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = ((float)e1HP / (float)E1Max);
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + e);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                    if (e2HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", e2HP);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = ((float)e2HP / (float)E1Max);
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + i);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                }
            }
        }
        if (collision == 2)
        {
            loc = PlayerPrefs.GetInt("E" + e + "-Loc") - 1;
            for (int i = 1; i <= 4; i++)
            {
                if (loc == PlayerPrefs.GetInt("E" + i + "Loc"))
                {
                    StatusEffect.InflictStatusEnemy(status, e, statusX);
                    StatusEffect.InflictStatusEnemy(status, i, statusX);
                    int e1HP = PlayerPrefs.GetInt("E" + e + "-CHP");
                    int e2HP = PlayerPrefs.GetInt("E" + i + "-CHP");
                    e1HP -= damage;
                    e2HP -= damage;
                    if (e1HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", e1HP);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = ((float)e1HP / (float)E1Max);
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + e + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + e + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + e + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + e);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                    if (e2HP > 0)
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", e2HP);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = ((float)e2HP / (float)E1Max);
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("E" + i + "-CHP", 0);
                        int E1Max = PlayerPrefs.GetInt("E" + i + "-HP");
                        float PercentHP = 0;
                        GameObject.Find("E" + i + "-Hp").transform.localScale = new Vector3(PercentHP, 1, 1);
                        GameObject enemy = GameObject.Find("E" + i);
                        enemy.GetComponent<SpriteRenderer>().color = Color.black;
                        if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetInt("E2-CHP") <= 0)
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                        else if (PlayerPrefs.GetInt("E1-CHP") <= 0 && PlayerPrefs.GetString("E2-Name") == "null")
                        {
                            //change to map
                            RewardsScreen.RewardDisplay("standard");
                            PlayerPrefs.SetInt("E1-Set", 0);
                            //Application.LoadLevel("Win");
                        }
                    }
                }
            }
        }
    }
}