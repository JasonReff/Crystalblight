using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTileSet : MonoBehaviour
{
    public List<CombatTile> tiles;
    public CharacterOrEnemy characterOrEnemy;
    

    public CombatTileSet(CharacterOrEnemy _characterOrEnemy)
    {
        characterOrEnemy = _characterOrEnemy;
    }
    
    public enum CharacterOrEnemy
    {
        Character,
        Enemy
    }

    public CombatTileSet Create3x3(CharacterOrEnemy characterOrEnemy)
    {
        CombatTileSet tileSet = new CombatTileSet(characterOrEnemy);
        for (int x = 1; x <= 3; x++)
        {
            for (int y = 1; y <= 3; y++)
            {
                CombatTile combatTile = new CombatTile(x, y);
                tileSet.tiles.Add(combatTile);
            }
        }
        return tileSet;
    }

    public CombatTileSet Create4x4(CharacterOrEnemy characterOrEnemy)
    {
        CombatTileSet tileSet = new CombatTileSet(characterOrEnemy);
        for (int x = 1; x <= 4; x++)
        {
            for (int y = 1; y <= 4; y++)
            {
                CombatTile combatTile = new CombatTile(x, y);
                tileSet.tiles.Add(combatTile);
            }
        }
        return tileSet;
    }

    public CombatTileSet Create5x5(CharacterOrEnemy characterOrEnemy)
    {
        CombatTileSet tileSet = new CombatTileSet(characterOrEnemy);
        for (int x = 1; x <= 5; x++)
        {
            for (int y = 1; y <= 5; y++)
            {
                CombatTile combatTile = new CombatTile(x, y);
                tileSet.tiles.Add(combatTile);
            }
        }
        return tileSet;
    }
}
