using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTile : MonoBehaviour
{
    public int columnNumber;
    public int rowNumber;

    public CombatTile(int column, int row)
    {
        columnNumber = column;
        rowNumber = row;
    }

    
}
