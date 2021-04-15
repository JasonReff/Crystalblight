using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screensize : MonoBehaviour
{
    private int lastWidth  = 0;
    private int lastHeight = 0;

    void Start()
    {

    }

    void Update()
    {
        float width = Screen.width;
        float height = Screen.height;

        if (lastWidth != (int)width) // if the user is changing the width
        {
            // update the height
            float heightAccordingToWidth = width / 16.0f * 9.0f;
            Screen.SetResolution((int)width, (int)Mathf.Round(heightAccordingToWidth), false, 0);
        }
        else if (lastHeight != (int)height) // if the user is changing the height
        {
            // update the width
            float widthAccordingToHeight = height / 9.0f * 16.0f;
            Screen.SetResolution((int)Mathf.Round(widthAccordingToHeight), (int)height, false, 0);
        }

        lastWidth = (int)width;
        lastHeight = (int)height;
    }
}
