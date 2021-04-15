using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class P1Hover : MonoBehaviour
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
    public GameObject HP;
    public GameObject HPBack;
    public GameObject SP;
    public GameObject SPBack;
    public GameObject Guard;

    void Start()
    {
        //randomize this
        PlayerPrefs.SetInt("P1-Loc", 6);
        PlayerPrefs.SetInt("P1-CanMove", 1);
    }

    void OnMouseEnter()
    {
        textbox.text = PlayerPrefs.GetString("P1-Name") + " HP: " + PlayerPrefs.GetInt("P1-CHP") + "/" + PlayerPrefs.GetInt("P1-HP") + 
            "    SP: " + PlayerPrefs.GetInt("P1-CSP") + "/" + PlayerPrefs.GetInt("P1-SP") + "\n" + "Guard: " + PlayerPrefs.GetInt("P1-CG") + "/" + PlayerPrefs.GetInt("P1-Guard");
        //this moves cards
        Vector3 temp = new Vector3(-300 * 2.893986f, -154* 2.893986f, -1 * 2.893986f);
        skillcard_A.transform.position = temp;
        Damage_A.text = PlayerPrefs.GetInt("P1-Attack").ToString();
        temp = new Vector3(-200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
        skillcard_D.transform.position = temp;
        temp = new Vector3(-100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
        skillcard_1.transform.position = temp;
        Damage_1.text = PlayerPrefs.GetInt("P1-S1-Damage").ToString();
        Cost_1.text = PlayerPrefs.GetInt("P1-S1-Cost").ToString();
        SName_1.text = PlayerPrefs.GetString("P1-Skill-1");
        temp = new Vector3(0 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
        skillcard_2.transform.position = temp;
        temp = new Vector3(100 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
        skillcard_3.transform.position = temp;
        temp = new Vector3(200 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
        skillcard_4.transform.position = temp;
        temp = new Vector3(300 * 2.893986f, -154 * 2.893986f, -1 * 2.893986f);
        skillcard_M.transform.position = temp;
        //this handles movement on 3x3
        int P1Loc = PlayerPrefs.GetInt("P1-Loc");

        if (PlayerPrefs.GetInt("P1-CanMove") == 1)
        {
            GameObject IBlock = GameObject.FindGameObjectWithTag("P-Block-1");
            switch (P1Loc)
            {
                case 1:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-4");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-4-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-2");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-2-Moveable", 1);
                        break;
                    }
                case 2:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-1");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-1-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-5");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-5-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-3");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-3-Moveable", 1);
                        break;
                    }
                case 3:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-6");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-6-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-2");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-2-Moveable", 1);
                        break;
                    }
                case 4:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-1");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-1-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-5");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-5-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-7");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-7-Moveable", 1);
                        break;
                    }
                case 5:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-4");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-4-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-2");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-2-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-8");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-8-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-6");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-6-Moveable", 1);
                        break;
                    }
                case 6:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-5");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-5-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-3");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-3-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-9");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-9-Moveable", 1);
                        break;
                    }
                case 7:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-4");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-4-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-8");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-8-Moveable", 1);
                        break;
                    }
                case 8:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-7");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-7-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-5");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-5-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-9");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-9-Moveable", 1);
                        break;
                    }
                case 9:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-6");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-6-Moveable", 1);
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-8");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-8-Moveable", 1);
                        break;
                    }

                default:
                    {
                        IBlock = GameObject.FindGameObjectWithTag("P-Block-1");
                        IBlock.GetComponent<SpriteRenderer>().color = Color.green;
                        PlayerPrefs.SetInt("P1-Block-1-Moveable", 1);
                        break;
                    }
            }
        }
    }
    void OnMouseDown()
    {
        PlayerPrefs.SetInt("Clicked", 1);
        PlayerPrefs.SetInt("P1-Clicked", 1);
    }

    public void OnMouseExit()
    {
        if(PlayerPrefs.GetInt("Clicked") != 1)
        {
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
            GameObject IBlock = GameObject.FindGameObjectWithTag("P-Block-1");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-2");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-3");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-4");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-5");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-6");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-7");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-8");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            IBlock = GameObject.FindGameObjectWithTag("P-Block-9");
            IBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 91, 255, 255);
            if (PlayerPrefs.GetInt("P1-Clicked") != 1)
            {
                PlayerPrefs.SetInt("P1-Block-1-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-2-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-3-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-4-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-5-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-6-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-7-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-8-Moveable", 0);
                PlayerPrefs.SetInt("P1-Block-9-Moveable", 0);
            }
        }
    }
}
