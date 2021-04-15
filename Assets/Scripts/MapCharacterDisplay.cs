using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCharacterDisplay : MonoBehaviour
{
    public void OnMouseEnter()
    {
        GameObject.Find("CharacterDisplay").transform.localPosition += new Vector3(0, 0, -4);
        GameObject.Find("CharacterName").transform.localPosition += new Vector3(0, 0, -4);
        GameObject.Find("CharacterLevel").transform.localPosition += new Vector3(0, 0, -4);
        GameObject.Find("CharacterSkill1").transform.localPosition += new Vector3(0, 0, -4);
        GameObject.Find("CharacterSkill2").transform.localPosition += new Vector3(0, 0, -4);
        GameObject.Find("CharacterSkill3").transform.localPosition += new Vector3(0, 0, -4);
        GameObject.Find("CharacterSkill4").transform.localPosition += new Vector3(0, 0, -4);
        string characterName = PlayerPrefs.GetString(this.name + "-Name");
        LoadSprite.FindSprite(GameObject.Find("CharacterIcon"), characterName + "Head");
        GameObject.Find("CharacterName").GetComponent<Text>().text = characterName;
        GameObject.Find("CharacterLevel").GetComponent<Text>().text = "Level: " + PlayerPrefs.GetInt(characterName + "-Level").ToString();
        GameObject.Find("CharacterSkill1").GetComponent<Text>().text = "Skill 1: " + PlayerPrefs.GetString(characterName + "Level1Skill1");
        GameObject.Find("CharacterSkill2").GetComponent<Text>().text = "Skill 2: " + PlayerPrefs.GetString(characterName + "-Skill-2");
        GameObject.Find("CharacterSkill3").GetComponent<Text>().text = "Skill 3: " + PlayerPrefs.GetString(characterName + "-Skill-3");
        GameObject.Find("CharacterSkill4").GetComponent<Text>().text = "Skill 4: " + PlayerPrefs.GetString(characterName + "-Skill-4");
    }
    public void OnMouseExit()
    {
        GameObject.Find("CharacterDisplay").transform.localPosition += new Vector3(0, 0, +4);
        GameObject.Find("CharacterName").transform.localPosition += new Vector3(0, 0, +4);
        GameObject.Find("CharacterLevel").transform.localPosition += new Vector3(0, 0, +4);
        GameObject.Find("CharacterSkill1").transform.localPosition += new Vector3(0, 0, +4);
        GameObject.Find("CharacterSkill2").transform.localPosition += new Vector3(0, 0, +4);
        GameObject.Find("CharacterSkill3").transform.localPosition += new Vector3(0, 0, +4);
        GameObject.Find("CharacterSkill4").transform.localPosition += new Vector3(0, 0, +4);
    }
}
