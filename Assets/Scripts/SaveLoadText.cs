using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using UnityEngine;

public class SaveLoadText : MonoBehaviour
{
    
    public static void TextSet(string variableText, string valueText)
    {
        int counter = 0;
        string line;
        StreamReader file = new StreamReader(@"C:\Users\jaref\Desktop\Crystalblight\Crystalblight Current Build\CrystalBlight0.1.9\CrystalBlight\Assets\Materials\temp assets\Text.txt");
        while ((line = file.ReadLine()) != null)
        {
            System.Console.WriteLine(line);
            counter++;
            if (line == variableText)
            {

            }
        }
    }
        
}
