using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatSystem : MonoBehaviour
{

    public Character activePlayer;
    public Skill activeSkill;
    public string skillTargeting;
    public bool charactersPlaced;

    public GameObject background;
    public GameObject Enemy;
    public GameObject characterObject;
    public PlayerTurn playerTurn;
    public PlayerData playerData;
    private void Start()
    {
        CreateEnemies();
        CreateCharacters();
        //StartCoroutine(PlayerTransition());
    }

    IEnumerator Skill()
    {
        
    }

    void CreateEnemies()
    {
        for (int e = 1; e <= 1; e++)
        {
            string tile = PlayerPrefs.GetString("CurrentTile");
            string name = "null";
            if (tile[0] == 'C')
            {
                int combatNumber = 0;
                if (tile.Length == 7)
                {
                    combatNumber = Int32.Parse(tile[6].ToString());
                }
                if (tile.Length == 8)
                {
                    combatNumber = Int32.Parse(tile[6].ToString() + tile[7].ToString());
                }
                name = PlayerPrefs.GetString("Combat" + combatNumber + "E" + e + "-Name");
            }
            else if (tile[0] == 'M')
            {
                name = PlayerPrefs.GetString("MinibossE" + e + "-Name");
            }
            else if (tile[0] == 'B')
            {
                name = PlayerPrefs.GetString("BossE" + e + "-Name");
            }
            if (name != "null")
            {
                GameObject E1 = Instantiate(Enemy);
                E1.gameObject.name = "E" + e.ToString();
            }
        }
    }

    void CreateCharacters()
    {
        foreach (Character character in playerData.characters)
        {
            LoadCharacter(character);
        }
    }

    void LoadCharacter(Character character)
    {
        GameObject player = Instantiate(characterObject);
        Character characterInPlay = player.GetComponent<Character>();
        characterInPlay.GetCharacterData(character);
        characterInPlay.clicked = false;
        characterInPlay.turnTaken = false;
        characterInPlay.guard = characterInPlay.maxGuard;
        characterInPlay.special = 0;
        LoadSprite.FindSprite(player, characterInPlay.name);
    }

    IEnumerator PlayerTransition()
    {
        playerTurn.Begin();
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(PlayerTurn());
    }
    
    IEnumerator PlayerTurn()
    {
        for (int p = 1; p <= 25; p++)
        {
            if (GameObject.Find("P" + p) != null)
            {
                if (GameObject.Find("P" + p).GetComponent<Character>().turnTaken == false)
                {
                    yield return new WaitForSeconds(0.3f);
                    CheckIfGameOver();
                    StartCoroutine(PlayerTurn());
                    break;
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(EnemyTransition());
    }

    IEnumerator EnemyTransition()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        for (int e = 1; e <= 25; e++)
        {
            if (GameObject.Find("E" + e) != null)
            {
                if (GameObject.Find("E" + e).GetComponent<Enemy>().turnTaken == false)
                {
                    GameObject.Find("E" + e).GetComponent<Enemy>().TakeTurn();
                    CheckIfGameOver();
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(PlayerTransition());
    }

    void CheckIfGameOver()
    {
        for (int p = 1; p <= 4; p++)
        {
            //as of now, will not yield game over if a summon in p2, p3 or p4 is alive
            if (GameObject.Find("P" + p) != null)
            {
                return;
            }
        }
        GameOver();
    }

    void CheckIfVictory()
    {
        for (int e = 1; e <= 25; e++)
        {
            if (GameObject.Find("E" + e) != null)
            {
                return;
            }
        }
        Victory();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Victory()
    {
        RewardsScreen.RewardDisplay(PlayerPrefs.GetString("CurrentStage"));
    }
}
