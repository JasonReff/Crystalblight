using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSprite : MonoBehaviour
{
    public static void FindSprite(GameObject gameObject2, string assetpath)
    {
        var sprite = Resources.Load<Sprite>(assetpath);
        gameObject2.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
