using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VinceHover : MonoBehaviour
{
    public GoToMap GoMap;
    public Text textbox;
    void OnMouseEnter()
    {
        GameObject vincent = GameObject.FindGameObjectWithTag("vincent");
        Vector3 temp = new Vector3(693, -301, -2);
        vincent.transform.position = temp;
        textbox.text = "Vincent:" + "\n" + "Hp:40" + "\n" + "SP:40" + "\n" + "Attack: 15" + "\n" + "Skills:" + "\n" + "Gun: Kill All enemys SP cost 0(good for debug)"+"\n"+"will learn new skill at lv2";
    }

    void OnMouseExit()
    {
        GameObject vincent = GameObject.FindGameObjectWithTag("vincent");
        Vector3 temp = new Vector3(1500, -301, -2);
        vincent.transform.position = temp;
        textbox.text = "Overveiw";
    }
    void OnMouseDown()
    {
        //set all party member 1 stats to be Vinnie's including name
    }
}