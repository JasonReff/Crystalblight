using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterMake("Reaper", 2, 3, 2, 2, 1);
        CharacterMake("Storm", 2, 2, 3, 2, 1);
        CharacterMake("Matriarch", 3, 2, 2, 1, 2);
        CharacterMake("Hollow", 2, 2, 2, 1, 3);
        CharacterMake("Shadow", 1, 2, 2, 3, 2);
    }

    public void CharacterMake(string characterName, int VIT, int STR, int INT, int DEX, int END)
    {
        PlayerPrefs.SetInt(characterName + "-VIT", VIT);
        PlayerPrefs.SetInt(characterName + "-INT", INT);
        PlayerPrefs.SetInt(characterName + "-STR", STR);
        PlayerPrefs.SetInt(characterName + "-DEX", DEX);
        PlayerPrefs.SetInt(characterName + "-END", END);
        PlayerPrefs.SetInt(characterName + "-Level", 1);
    }
}
