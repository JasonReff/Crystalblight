using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class E2 : MonoBehaviour
{
    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        string tile = PlayerPrefs.GetString("CurrentTile");
        string e2Name = "";
        int combatNumber = 0;
        if (tile[0] == 'C')
        {
            if (tile.Length == 7)
            {
                combatNumber = Int32.Parse(tile[6].ToString());
            }
            if (tile.Length == 8)
            {
                combatNumber = Int32.Parse(tile[6].ToString() + tile[7].ToString());
            }
            e2Name = PlayerPrefs.GetString("Combat" + combatNumber + "E2-Name");
        }
        if (tile[0] == 'M')
        {
            e2Name = PlayerPrefs.GetString("MinibossE2-Name");
        }
        if (tile[0] == 'B')
        {
            e2Name = PlayerPrefs.GetString("BossE2-Name");
        }
        if (e2Name != "null")
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
            PlayerPrefs.SetInt("E2-Loc", 0);
            Invoke("SetLoc", 0.1f);
            if (PlayerPrefs.GetInt("E2-Set") != 1)
            {
                PlayerPrefs.SetString("E2-Name", e2Name);
                PlayerPrefs.SetInt("E2-CHP", PlayerPrefs.GetInt(e2Name + "-CHP"));
                PlayerPrefs.SetInt("E2-HP", PlayerPrefs.GetInt(e2Name + "-HP"));
                PlayerPrefs.SetInt("E2-CG", PlayerPrefs.GetInt(e2Name + "-CG"));
                PlayerPrefs.SetInt("E2-Guard", PlayerPrefs.GetInt(e2Name + "-Guard"));
                PlayerPrefs.SetInt("E2-Set", 1);
                PlayerPrefs.SetString("E2Status0", PlayerPrefs.GetString(e2Name + "Status0"));
                PlayerPrefs.SetInt("E2Status0X", PlayerPrefs.GetInt(e2Name + "Status0X"));
                PlayerPrefs.SetString("E2Status1", PlayerPrefs.GetString(e2Name + "Status1"));
                PlayerPrefs.SetInt("E2Status1X", PlayerPrefs.GetInt(e2Name + "Status1X"));
                PlayerPrefs.SetString("E2Status2", PlayerPrefs.GetString(e2Name + "Status2"));
                PlayerPrefs.SetInt("E2Status2X", PlayerPrefs.GetInt(e2Name + "Status2X"));
                PlayerPrefs.SetString("E2Status3", PlayerPrefs.GetString(e2Name + "Status3"));
                PlayerPrefs.SetInt("E2Status3X", PlayerPrefs.GetInt(e2Name + "Status3X"));
                PlayerPrefs.SetInt("E2-Attack", PlayerPrefs.GetInt(e2Name + "-Attack"));
                PlayerPrefs.SetString("E2-Weakness1", PlayerPrefs.GetString(e2Name + "-Weakness1"));
                PlayerPrefs.SetString("E2-Weakness2", PlayerPrefs.GetString(e2Name + "-Weakness2"));
                PlayerPrefs.SetString("E2-Resistance1", PlayerPrefs.GetString(e2Name + "-Resistance1"));
                PlayerPrefs.SetString("E2-Resistance2", PlayerPrefs.GetString(e2Name + "-Resistance2"));
                PlayerPrefs.SetString("E2-Resistance3", PlayerPrefs.GetString(e2Name + "-Resistance3"));
                PlayerPrefs.SetString("E2-Skill1", PlayerPrefs.GetString(e2Name + "-Skill1"));
                PlayerPrefs.SetString("E2-Skill2", PlayerPrefs.GetString(e2Name + "-Skill2"));
                PlayerPrefs.SetString("E2-Skill3", PlayerPrefs.GetString(e2Name + "-Skill3"));
                PlayerPrefs.SetString("E2-Skill4", PlayerPrefs.GetString(e2Name + "-Skill4"));
                PlayerPrefs.SetString("E2-Skill5", PlayerPrefs.GetString(e2Name + "-Skill5"));
                PlayerPrefs.SetString("E2-Skill6", PlayerPrefs.GetString(e2Name + "-Skill6"));
                GameObject targetHP = GameObject.Find("E2-Hp");
                int PCHP = PlayerPrefs.GetInt("E2-CHP");
                int PMax = PlayerPrefs.GetInt("E2-HP");
                float Percent = ((float)PCHP / (float)PMax);
                targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
                GameObject targetGuard = GameObject.Find("E2-Guard");
                int PCGuard = PlayerPrefs.GetInt("E2-CG");
                int PMaxGuard = PlayerPrefs.GetInt("E2-Guard");
                float PercentGuard = ((float)PCGuard / (float)PMaxGuard);
                targetGuard.gameObject.transform.localScale = new Vector3(PercentGuard, 1, 1);
                GameObject sprite = GameObject.Find("E2");
                if (e2Name.Substring(e2Name.Length - 8) == "(Stage1)" || e2Name.Substring(e2Name.Length - 8) == "(Stage2)" || e2Name.Substring(e2Name.Length - 8) == "(Stage3)")
                {
                    e2Name = e2Name.Remove(e2Name.Length - 9, 9);
                }
                LoadSprite.FindSprite(sprite, e2Name);
                BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
                Destroy(_boxCollider);
                _boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
                // PlayerPrefs.SetInt("E2-Guard", 100);
                PlayerPrefs.SetInt("E2-AttL", 0);
                ChooseAttack();
            }
        }
        if (e2Name == "null")
        {
            PlayerPrefs.SetString("E2-Name", e2Name);
            PlayerPrefs.SetInt("E2-CHP", PlayerPrefs.GetInt(e2Name + "-CHP"));
            PlayerPrefs.SetInt("E2-HP", PlayerPrefs.GetInt(e2Name + "-HP"));
            PlayerPrefs.SetInt("E2-CG", PlayerPrefs.GetInt(e2Name + "-CG"));
            PlayerPrefs.SetInt("E2-Guard", PlayerPrefs.GetInt(e2Name + "-Guard"));
            PlayerPrefs.SetInt("E2-Set", 1);
            PlayerPrefs.SetString("E2Status0", PlayerPrefs.GetString(e2Name + "Status0"));
            PlayerPrefs.SetInt("E2Status0X", PlayerPrefs.GetInt(e2Name + "Status0X"));
            PlayerPrefs.SetString("E2Status1", PlayerPrefs.GetString(e2Name + "Status1"));
            PlayerPrefs.SetInt("E2Status1X", PlayerPrefs.GetInt(e2Name + "Status1X"));
            PlayerPrefs.SetString("E2Status2", PlayerPrefs.GetString(e2Name + "Status2"));
            PlayerPrefs.SetInt("E2Status2X", PlayerPrefs.GetInt(e2Name + "Status2X"));
            PlayerPrefs.SetString("E2Status3", PlayerPrefs.GetString(e2Name + "Status3"));
            PlayerPrefs.SetInt("E2Status3X", PlayerPrefs.GetInt(e2Name + "Status3X"));
            PlayerPrefs.SetInt("E2-Attack", PlayerPrefs.GetInt(e2Name + "-Attack"));
            PlayerPrefs.SetString("E2-Weakness1", PlayerPrefs.GetString(e2Name + "-Weakness1"));
            PlayerPrefs.SetString("E2-Weakness2", PlayerPrefs.GetString(e2Name + "-Weakness2"));
            PlayerPrefs.SetString("E2-Resistance1", PlayerPrefs.GetString(e2Name + "-Resistance1"));
            PlayerPrefs.SetString("E2-Resistance2", PlayerPrefs.GetString(e2Name + "-Resistance2"));
            PlayerPrefs.SetString("E2-Resistance3", PlayerPrefs.GetString(e2Name + "-Resistance3"));
            PlayerPrefs.SetString("E2-Skill1", PlayerPrefs.GetString(e2Name + "-Skill1"));
            PlayerPrefs.SetString("E2-Skill2", PlayerPrefs.GetString(e2Name + "-Skill2"));
            PlayerPrefs.SetString("E2-Skill3", PlayerPrefs.GetString(e2Name + "-Skill3"));
            PlayerPrefs.SetString("E2-Skill4", PlayerPrefs.GetString(e2Name + "-Skill4"));
            PlayerPrefs.SetString("E2-Skill5", PlayerPrefs.GetString(e2Name + "-Skill5"));
            PlayerPrefs.SetString("E2-Skill6", PlayerPrefs.GetString(e2Name + "-Skill6"));
            GameObject targetHP = GameObject.Find("E2-Hp");
            int PCHP = PlayerPrefs.GetInt("E2-CHP");
            int PMax = PlayerPrefs.GetInt("E2-HP");
            float Percent = 0;
            targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
            GameObject targetGuard = GameObject.Find("E2-Guard");
            int PCGuard = PlayerPrefs.GetInt("E2-CG");
            int PMaxGuard = PlayerPrefs.GetInt("E2-Guard");
            float PercentGuard = 0;
            targetGuard.gameObject.transform.localScale = new Vector3(PercentGuard, 1, 1);
            GameObject sprite = GameObject.Find("E2");
            LoadSprite.FindSprite(sprite, e2Name);
            BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
            Destroy(_boxCollider);
            _boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
            // PlayerPrefs.SetInt("E2-Guard", 100);
            PlayerPrefs.SetInt("E2-AttL", 0);
        }
    }
    //used for initial movement
    void SetLoc()
    {
        if (PlayerPrefs.GetString("E2-Name") == "null")
        {

        }
        else
        {
            int time = (int)System.DateTime.Now.Ticks;
            UnityEngine.Random.seed = time;
            // the seed a number in that range
            int Loc = 0;
            PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E2-Loc") + "-Moveable", 1);
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
            PlayerPrefs.SetInt("E2-Loc", Loc);
            GameObject Vill = GameObject.Find("E2");
            string e2Name = PlayerPrefs.GetString("E2-Name");
            LoadSprite.FindSprite(Vill, e2Name);
            GameObject VillHp = GameObject.Find("E2-Hp");
            GameObject VillHpBack = GameObject.Find("E2-HpBack");
            GameObject VillGuard = GameObject.Find("E2-Guard");
            GameObject VillStatus0 = GameObject.Find("E2Status0");
            GameObject VillStatus0X = GameObject.Find("E2Status0X");
            Vector3 E2LocQuards = GameObject.Find("E-Block-" + Loc.ToString()).transform.position;
            Vill.transform.position = E2LocQuards + new Vector3(0, +67, -3);
            SpriteRenderer sprite = Vill.GetComponent<SpriteRenderer>();
            int l = Loc + 3;
            l = l / 4;
            sprite.sortingLayerName = "Char" + l;
            VillHp.transform.position = E2LocQuards + new Vector3(-100, -17, 1);
            VillHp = VillHp.transform.GetChild(0).gameObject;
            sprite = VillHp.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Bar" + l;
            VillHpBack.transform.position = E2LocQuards + new Vector3(0, -17, 1);
            sprite = VillHpBack.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Back" + l;
            VillStatus0.transform.position = E2LocQuards + new Vector3(-40, 20, 1);
            sprite = VillStatus0.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Status" + 1;
            VillStatus0X.transform.position = E2LocQuards + new Vector3(-40, 20, 1);
            VillGuard.transform.position = E2LocQuards + new Vector3(-100, -17, 1);
            VillGuard = VillGuard.transform.GetChild(0).gameObject;
            sprite = VillGuard.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Guard" + l;
        }
    }
    void OnMouseEnter()
    {
        string e2Name = PlayerPrefs.GetString("E2-Name");
        if (e2Name.Substring(e2Name.Length - 8) == "(Stage1)" || e2Name.Substring(e2Name.Length - 8) == "(Stage2)" || e2Name.Substring(e2Name.Length - 8) == "(Stage3)")
        {
            e2Name = e2Name.Remove(e2Name.Length - 9, 9);
        }
        textbox.text = e2Name + " Guard: " + PlayerPrefs.GetInt("E2-CG") + "/" + PlayerPrefs.GetInt("E2-Guard") + " HP: " + PlayerPrefs.GetInt("E2-CHP")
            + "/" + PlayerPrefs.GetInt("E2-HP") + "\n" + "Intent: " + PlayerPrefs.GetString("E2-CAtt") + " " + PlayerPrefs.GetInt("E2-Attack");
        int targ = PlayerPrefs.GetInt("E2-AttL");
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
        PlayerPrefs.SetInt("ENumber", 2);
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
        GameObject hero = GameObject.Find("P1");
        if (PlayerPrefs.GetInt("P1-CHP") > 0)
        {
            hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
        hero = GameObject.Find("P2");
        if (PlayerPrefs.GetInt("P2-CHP") > 0)
        {
            hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
        StatusEffect.StatusTickStart("P1");
        StatusEffect.StatusTickStart("P2");
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
        if (PlayerPrefs.GetString("E2StartUp") == "null")
        {
            int choice = UnityEngine.Random.Range(1, 4);
            PlayerPrefs.SetInt("E2-Choice", choice);
            if (choice == 1)
            {
                PlayerPrefs.SetString("E2-CAtt", "Basic Attack");
                int time = (int)System.DateTime.Now.Ticks;
                UnityEngine.Random.seed = time;
                int p = 0;
                while (PlayerPrefs.GetInt("P" + p + "-CHP") == 0)
                {
                    p = UnityEngine.Random.Range(1, 3);
                    PlayerPrefs.SetInt("E2-AttP", p);
                    PlayerPrefs.SetInt("E2-AttL", PlayerPrefs.GetInt("P" + p + "-Loc"));
                }
            }
            if (choice == 2)
            {
                PlayerPrefs.SetString("E2-CAtt", "Defend");
                PlayerPrefs.SetInt("E2-AttP", 0);
                PlayerPrefs.SetInt("E2-AttL", 0);
            }
            if (choice == 3)
            {
                int skillChoice;
                do
                {
                    skillChoice = UnityEngine.Random.Range(1, 7);
                }
                while (PlayerPrefs.GetString("E2-Skill" + skillChoice) == "null");
                PlayerPrefs.SetString("E2-CAtt", PlayerPrefs.GetString("E2-Skill" + skillChoice));
                int time = (int)System.DateTime.Now.Ticks;
                UnityEngine.Random.seed = time;
                int p = 0;
                while (PlayerPrefs.GetInt("P" + p + "-CHP") == 0)
                {
                    p = UnityEngine.Random.Range(1, 3);
                    PlayerPrefs.SetInt("E2-AttP", p);
                    PlayerPrefs.SetInt("E2-AttL", PlayerPrefs.GetInt("P" + p + "-Loc"));
                }
            }
        }
        else
        {
            PlayerPrefs.SetString("E2-CAtt", PlayerPrefs.GetString("E2StartUp"));
            int time = (int)System.DateTime.Now.Ticks;
            UnityEngine.Random.seed = time;
            int p = PlayerPrefs.GetInt("E2-AttP");
            while (PlayerPrefs.GetInt("P" + p + "-CHP") == 0)
            {
                p = UnityEngine.Random.Range(1, 3);
                PlayerPrefs.SetInt("E2-AttP", p);
                PlayerPrefs.SetInt("E2-AttL", PlayerPrefs.GetInt("P" + p + "-Loc"));
            }
        }
    }
    public void Attack()
    {
        GameObject target = GameObject.Find(PlayerPrefs.GetString("P" + PlayerPrefs.GetInt("E2-AttP") + "-Name"));
        GameObject targetHP = GameObject.Find("P" + PlayerPrefs.GetInt("E2-AttP") + "-Hp");
        GameObject targetG = GameObject.Find("P" + PlayerPrefs.GetInt("E2-AttP") + "-Guard");
        int p = PlayerPrefs.GetInt("E2-AttP");
        int PCHP = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-CHP");
        int PCG = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-CG");
        int Att = PlayerPrefs.GetInt("E2-Attack");
        string damageType = "Physical";
        StartCoroutine(Animation(damageType));
        if (PlayerPrefs.GetString("P" + p + "-Weakness1") == damageType || PlayerPrefs.GetString("P" + p + "-Weakness2") == damageType)
        {
            Att = (int)Math.Round((float)Att * 1.5, 1);
        }
        if (PlayerPrefs.GetString("P" + p + "-Resistance1") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance2") == damageType || PlayerPrefs.GetString("P" + p + "-Resistance3") == damageType)
        {
            Att = (int)Math.Round((float)Att * 0.75, 1);
        }
        if (PlayerPrefs.GetString("P" + p + "Status0") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status1") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status2") == "steadfast" || PlayerPrefs.GetString("P" + p + "Status3") == "steadfast")
        {
            PCG -= Att;
        }
        else if (PlayerPrefs.GetString("P" + p + "Status0") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status1") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status2") == "vulnerable" || PlayerPrefs.GetString("P" + p + "Status3") == "vulnerable")
        {
            PCHP -= Att;
        }
        else
        {
            PCG = PCG - ((Att / 2) + (Att % 2));
            PCHP = PCHP - ((Att / 2));
        }
        if (PCG < 0)
        {
            PCHP = PCHP + PCG;
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-CG", 0);
            PCG = 0;
        }
        else
        {
            PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-CG", PCG);
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
        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-CHP", PCHP);
        PlayerPrefs.SetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-CG", PCG);
        int PMax = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-HP");
        float Percent = ((float)PCHP / (float)PMax);
        targetHP.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        PMax = PlayerPrefs.GetInt("P" + PlayerPrefs.GetInt("E2-AttP") + "-Guard");
        Percent = ((float)PCG / (float)PMax);
        targetG.gameObject.transform.localScale = new Vector3(Percent, 1, 1);
        EndTurn();
    }
    public void Defend()
    {
        int eCurrentGuard = PlayerPrefs.GetInt("E2-CG");
        int eMaxGuard = PlayerPrefs.GetInt("E2-Guard");
        int eAddedGuard = PlayerPrefs.GetInt("E2-GuardGain");
        eCurrentGuard = eCurrentGuard + eAddedGuard;
        if (eCurrentGuard > eMaxGuard)
        {
            eCurrentGuard = eMaxGuard;
        }
        GameObject GBar = GameObject.Find("E2-Guard");
        float PercentG = ((float)eCurrentGuard / (float)eMaxGuard);
        GBar.gameObject.transform.localScale = new Vector3(PercentG, 1, 1);
        PlayerPrefs.SetInt("E2-CG", eCurrentGuard);
        StatusEffect.InflictStatusEnemy("steadfast", 1, 1);
        EndTurn();
    }

    public void Skill()
    {
        string skill = String.Concat(PlayerPrefs.GetString("E2-CAtt").Where(c => !Char.IsWhiteSpace(c)));
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
        int left = PlayerPrefs.GetInt("E2-Loc") - 1;
        int up = PlayerPrefs.GetInt("E2-Loc") + 4;
        int down = PlayerPrefs.GetInt("E2-Loc") - 4;
        int right = PlayerPrefs.GetInt("E2-Loc") + 1;
        Vector3 E2LocQuards = new Vector3(0, 0, 0);
        switch (PlayerPrefs.GetInt("E2-Loc"))
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
        GameObject Vill = GameObject.Find("E2");
        GameObject VillHp = GameObject.Find("E2-Hp");
        GameObject VillHpBack = GameObject.Find("E2-HpBack");
        GameObject VillGuard = GameObject.Find("E2-Guard");
        GameObject Vill1Status0 = GameObject.Find("E2Status0");
        GameObject Vill1Status0X = GameObject.Find("E2Status0X");
        GameObject Vill1Status1 = GameObject.Find("E2Status1");
        GameObject Vill1Status1X = GameObject.Find("E2Status1X");
        GameObject Vill1Status2 = GameObject.Find("E2Status2");
        GameObject Vill1Status2X = GameObject.Find("E2Status2X");
        GameObject Vill1Status3 = GameObject.Find("E2Status3");
        GameObject Vill1Status3X = GameObject.Find("E2Status3X");
        Vector3 E2LocQuards = GameObject.Find("E-Block-" + dest.ToString()).transform.position;
        Vill.transform.position = E2LocQuards + new Vector3(0, +67, -2);
        SpriteRenderer sprite = Vill.GetComponent<SpriteRenderer>();
        int layer = dest + 3;
        layer = layer / 4;
        sprite.sortingLayerName = "Char" + layer;
        VillHp.transform.position = E2LocQuards + new Vector3(-100, -17, 1);
        VillHp = VillHp.transform.GetChild(0).gameObject;
        sprite = VillHp.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Bar" + layer;
        VillHpBack.transform.position = E2LocQuards + new Vector3(0, -17, 1);
        sprite = VillHpBack.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Back" + layer;
        Vill1Status0.transform.position = E2LocQuards + new Vector3(-40, 20, 1);
        sprite = Vill1Status0.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Status" + layer;
        Vill1Status0X.transform.position = E2LocQuards + new Vector3(-40, 20, 1);
        Vill1Status1.transform.position = E2LocQuards + new Vector3(-30, 20, 1);
        sprite = Vill1Status1.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Status" + layer;
        Vill1Status1X.transform.position = E2LocQuards + new Vector3(-30, 20, 1);
        Vill1Status2.transform.position = E2LocQuards + new Vector3(-20, 20, 1);
        sprite = Vill1Status2.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Status" + layer;
        Vill1Status2X.transform.position = E2LocQuards + new Vector3(-20, 20, 1);
        Vill1Status3.transform.position = E2LocQuards + new Vector3(-10, 20, 1);
        sprite = Vill1Status3.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Status" + layer;
        Vill1Status3X.transform.position = E2LocQuards + new Vector3(-10, 20, 1);
        VillGuard.transform.position = E2LocQuards + new Vector3(-100, -17, 1);
        VillGuard = VillGuard.transform.GetChild(0).gameObject;
        sprite = VillGuard.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Guard" + layer;
        PlayerPrefs.SetInt("E-Block-" + PlayerPrefs.GetInt("E2-Loc") + "-Moveable", 1);
        PlayerPrefs.SetInt("E2-Loc", dest);
        PlayerPrefs.SetInt("E-Block-" + dest + "-Moveable", 0);
    }
    IEnumerator Animation(string animation)
    {
        PlayerPrefs.SetInt("Processing", 1);
        GameObject effect = GameObject.Find("SkillEffect");
        Animator anim = effect.GetComponent<Animator>();
        GameObject target = GameObject.Find("P" + PlayerPrefs.GetInt("E2-AttP"));
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
        PlayerPrefs.SetInt("Processing", 0);
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
        Vector3 ScreenPos = new Vector3(-3000, 0, -100);
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
        StatusEffect.StatusTickEnd("E2");
        GameObject E3 = GameObject.Find("E3");
        if (PlayerPrefs.GetString("E3-Name") != "null")
        {
            E3.GetComponent<E3>().TakeTurn3();
            GiveTurn();
        }
        else
        {
            GiveTurn();
        }

    }

    public void TakeTurn()
    {
        GameObject E1 = GameObject.Find("E1");
        E1.GetComponent<E1>().TakeTurn();
    }
    public void TakeTurn2()
    {
        //forgot C lmao
        if (PlayerPrefs.GetInt("E2-CHP") > 0)
        {
            Invoke("Move", 3.8f);
            int choice = PlayerPrefs.GetInt("E2-Choice");
            if (choice == 1) { Invoke("Attack", 3.9f); }
            if (choice == 2) { Invoke("Defend", 3.9f); }
            if (choice == 3) { Invoke("Skill", 3.9f); }
            Invoke("ChooseAttack", 4.0f);
        }
        else
        {
            GiveTurn();
        }
    }
}