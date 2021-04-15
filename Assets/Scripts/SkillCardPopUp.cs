using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardPopUp : MonoBehaviour
{

    public float time;
    public GameObject popUp;
    public Text popUptext;
    void Start()
    {
        time = 0.0f;   
    }
    private void OnMouseOver()
    {
        time += Time.deltaTime;
        if (time >= 3.0f)
        {
            popUp.transform.localPosition = new Vector3(0, 0, -1);
            popUptext.transform.localPosition = new Vector3(0, -10, -1);
            string skillCard = this.name[this.name.Length - 1].ToString();
            string skillName = GameObject.Find(skillCard + "-Text").GetComponent<Text>().text;
            GameObject.Find("SkillPopUpName").GetComponent<Text>().text = skillName;
            GameObject.Find("SkillPopUpDescription").GetComponent<Text>().text = PlayerPrefs.GetString(PlayerPrefs.GetString(skillName + "ID") + "Description");
        }
    }

    private void OnMouseExit()
    {
        time = 0.0f;
        popUp.transform.localPosition = new Vector3(0, 1500, -1);
        popUptext.transform.localPosition = new Vector3(0, 500, -1);
    }
}
