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

    public List<CombatTileSet> tileSets;
    public GameObject background;
    public GameObject music;
    public GameObject enemyObject;
    public GameObject characterObject;
    public GameObject tileObject;
    public PlayerTurn playerTurn;
    public PlayerData playerData;
    private void Start()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        SetBackground();
        SetMusic();
        CreateEnemies();
        CreateCharacters();
        CreateTileSets();
        InstantiateTiles();
        //StartCoroutine(PlayerTransition());
    }

    void SetBackground()
    {
        string backgroundName = playerData.stageName;
        LoadSprite.FindSprite(background, backgroundName);
    }

    void SetMusic()
    {
        string musicName = playerData.stageName + " Music";
        music.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(musicName);
        music.GetComponent<AudioSource>().Play();
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
                GameObject E1 = Instantiate(enemyObject);
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

    void CreateTileSets()
    {
        CombatTileSet characterTileSet = new CombatTileSet();
        CombatTileSet enemyTileSet = new CombatTileSet();
        int currentStage = playerData.currentStage;
        switch (currentStage)
        {
            case 1:
                characterTileSet = CombatTileSet.Create3x3(CombatTileSet.CharacterOrEnemy.Character);
                enemyTileSet = CombatTileSet.Create3x3(CombatTileSet.CharacterOrEnemy.Enemy);
                break;
            case 2:
                characterTileSet = CombatTileSet.Create4x4(CombatTileSet.CharacterOrEnemy.Character);
                enemyTileSet = CombatTileSet.Create4x4(CombatTileSet.CharacterOrEnemy.Enemy);
                break;
            case 3:
                characterTileSet = CombatTileSet.Create5x5(CombatTileSet.CharacterOrEnemy.Character);
                enemyTileSet = CombatTileSet.Create5x5(CombatTileSet.CharacterOrEnemy.Enemy);
                break;
        }
        tileSets.Add(characterTileSet);
        tileSets.Add(enemyTileSet);
    }

    void InstantiateTiles()
    {
        foreach (CombatTileSet tileSet in tileSets)
        {
            foreach (CombatTile tile in tileSet.tiles)
            {
                GameObject newTile = Instantiate(tileObject);
                CombatTile newTileData = newTile.GetComponent<CombatTile>();
                newTileData.rowNumber = tile.rowNumber;
                newTileData.columnNumber = tile.columnNumber;
                Vector3 tileLocation = AdjustTilePosition(tile, tileSet);
                newTile.transform.localPosition = tileLocation;
            }
        }
    }

    Vector3 AdjustTilePosition(CombatTile tile, CombatTileSet tileSet)
    {
        Vector3 tileLocation = new Vector3(0, 0, -1);
        tileLocation.x -= 100 * tile.columnNumber;
        tileLocation.y += 100 * tile.rowNumber;
        switch (tileSet.characterOrEnemy)
        {
            case CombatTileSet.CharacterOrEnemy.Character:
                tileLocation.x -= 500;
                break;
            case CombatTileSet.CharacterOrEnemy.Enemy:
                tileLocation.x += 500;
                break;
        }
        return tileLocation;
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
