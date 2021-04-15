using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudfullbody2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void appear1()
    {
        Vector3 temp = new Vector3(693, -301, -2);
        transform.position = temp;
    }
    public void dissapear1()
    {
        Vector3 temp = new Vector3(1500, -301, -2);
        transform.position = temp;
    }
}
