using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public void Begin()
    {
        GameObject FullDiss = GameObject.Find("FullDiss");
        FullDiss.transform.position = new Vector3(0, 0, -100);
        GetComponent<Rigidbody>().velocity = new Vector3(1500, 0, 0);
        Invoke("Pause", 1.0f);
        for (int p = 1; p <= 4; p++)
        {
            if (PlayerPrefs.GetString("P" + p + "StartUp") != "null")
            {
                AutoAttack(p);
                StartCoroutine(AttackDelay());
            }
        }
    }

    public void AutoAttack(int player)
    {
        string skill = PlayerPrefs.GetString("P" + player + "StartUp");
        switch (PlayerPrefs.GetString(skill + "-Targeting"))
        {
            case "SingleTarget":
                SingleTargetSkills singleTargetSkills = GameObject.Find("E1").GetComponent<SingleTargetSkills>();
                singleTargetSkills.Invoke(skill, 0f);
                break;
            case "FriendlyTarget":
                FriendlyTargetSkills friendlyTargetSkills = GameObject.Find("skillcard-1").GetComponent<FriendlyTargetSkills>();
                friendlyTargetSkills.Invoke(skill, 0f);
                break;
            case "FriendlyTargetOther":
                FriendlyTargetOtherSkills friendlyTargetOtherSkills = GameObject.Find("skillcard-1").GetComponent<FriendlyTargetOtherSkills>();
                friendlyTargetOtherSkills.Invoke(skill, 0f);
                break;
            case "Untargeted":
                UntargetedSkills untargetedSkills = GameObject.Find("skillcard-1").GetComponent<UntargetedSkills>();
                untargetedSkills.Invoke(skill, 0f);
                break;
            case "EnemyTile": 
            case "EnemyRow":
                EnemyTileSkills enemyTileSkills = GameObject.Find("E-Block-1").GetComponent<EnemyTileSkills>();
                enemyTileSkills.Invoke(skill, 0f);
                break;
        }
        
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(2.0f);
    }

    public void Pause()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Invoke("Go", 1.5f);
    }
    public void Go()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(1500, 0, 0);
        Invoke("Stop", 1.3f);
    }
    public void Stop()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GameObject FullDiss = GameObject.Find("FullDiss");
        FullDiss.transform.position = new Vector3(-3000, 0, 0);
        transform.position = new Vector3(-1430, 0, 0);
    }
}
