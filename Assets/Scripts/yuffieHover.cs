using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class yuffieHover : MonoBehaviour
{
    public GoToMap GoMap;
    public Text textbox;
    void OnMouseEnter()
    {
        GameObject yuffie = GameObject.FindGameObjectWithTag("yuffie");
        Vector3 temp = new Vector3(693, -301, -2);
        yuffie.transform.position = temp;
        textbox.text = "Yuffie:" + "\n" + "HP:30" + "\n" + "SP:20" + "\n" + "Attack: 13" + "\n" + "Skills:" + "\n" + "caltrops: cover 4 tiles with spikes that deal 20 damage SP cost:5" + "\n" + "3 copies of the filler skill for ui demo";
    }

    void OnMouseExit()
    {
        GameObject yuffie = GameObject.FindGameObjectWithTag("yuffie");
        Vector3 temp = new Vector3(1500, -301, -2);
        yuffie.transform.position = temp;
        textbox.text = "Overveiw";
    }

    void OnMouseDown()
    {
        //set all party member 1 stats to be yuffie's including name
    }
}
