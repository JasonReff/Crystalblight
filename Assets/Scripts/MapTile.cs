using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public GameObject Tile;
    public GameObject Tile2;
    public GameObject Diss;
    public GameObject ex;
    void Start()
    {
        Diss.transform.position = this.transform.position + new Vector3(0, 0, -3);
        if (PlayerPrefs.GetString("CurrentTile") == this.name)
        {
            Invoke("Delay", 0.0f);
        }
        GameObject xp1 = GameObject.Find("Combat1XP");
        EnemyAllocation other = (EnemyAllocation)xp1.GetComponent(typeof(EnemyAllocation));
        other.CombatXPDisplay();
    }
    void OnMouseDown()
    {
        PlayerPrefs.SetString("CurrentTile", this.name);
    }
    void RemoveDiss()
    {
        Diss.transform.position = new Vector3(-3000, 0, 0);
    }
    void Delay()
    {
        Tile2.GetComponent<MapTile>().RemoveDiss();
        Tile.GetComponent<MapTile>().RemoveDiss();
        ex.transform.position = this.transform.position + new Vector3(0, 0, -3);
    }
}
