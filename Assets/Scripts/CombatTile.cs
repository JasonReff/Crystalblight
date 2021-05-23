using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTile : MonoBehaviour
{
    public int columnNumber;
    public int rowNumber;
    public bool movable;

    public CombatTile(int column, int row)
    {
        columnNumber = column;
        rowNumber = row;
    }

    public static List<CombatTile> AdjacentTiles(CombatTileSet tileSet, CombatTile location)
    {
        CombatTile up = tileSet.tiles.Find(x => x.columnNumber == location.columnNumber && x.rowNumber == location.rowNumber + 1);
        CombatTile left = tileSet.tiles.Find(x => x.columnNumber == location.columnNumber - 1 && x.rowNumber == location.rowNumber);
        CombatTile right = tileSet.tiles.Find(x => x.columnNumber == location.columnNumber + 1 && x.rowNumber == location.rowNumber);
        CombatTile down = tileSet.tiles.Find(x => x.columnNumber == location.columnNumber + 1 && x.rowNumber == location.rowNumber);
        List<CombatTile> adjacentTiles = new List<CombatTile> { up, left, down, right };
        return adjacentTiles;
    }
}
