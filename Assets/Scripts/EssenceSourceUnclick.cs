using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceSourceUnclick : MonoBehaviour
{
    void OnMouseDown()
    {
        for (int x = 1; x <= 4; x++)
        {
            GameObject characterIcon = GameObject.Find("Character" + x + "Icon");
            characterIcon.GetComponent<SpriteRenderer>().color = Color.white;
        }
        PlayerPrefs.SetString("EssenceButtonClicked", "null");
        Vector3 position = GameObject.Find("Confirm").transform.localPosition;
        GameObject.Find("Confirm").transform.localPosition = new Vector3(position.x, position.y, 1);
        GameObject.Find("ConfirmText").GetComponent<Text>().text = "";
    }
}
