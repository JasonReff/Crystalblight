using UnityEngine;
using System.IO;
using System;

public class WritePref : MonoBehaviour
{
    void OverWrite(string collumn1,string collumn2)
    {
        //this method needs to remake the entire file, so it will be slower.
        string tempFile = "temp.csv";
        string csv;
        using (var reader = new StreamReader("pref.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values[0] != collumn1)
                {
                    csv = string.Format("{0},{1}{2}", values[0], values[1], Environment.NewLine);
                    File.AppendAllText(@"temp.csv", csv);
                }
            }
        }
        File.Delete(@"Pref.csv");
        System.IO.File.Move("temp.csv", "pref.csv");
        csv = string.Format("{0},{1}{2}", collumn1, collumn2, Environment.NewLine);
        File.AppendAllText("pref.csv", csv);
    }

    void Write(string collumn1, string collumn2)
    {
        string csv = string.Format("{0},{1}{2}", collumn1, collumn2, Environment.NewLine);
        File.AppendAllText("pref.csv", csv);
    }
}
