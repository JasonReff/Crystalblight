using UnityEngine;
using System.IO;
public class ReadPref : MonoBehaviour
{
    public static string FindFromCSV(string dataFile, string variableName)
    {
        using (var reader = new StreamReader(dataFile))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values[0] == variableName)
                {
                    return values[1];
                }
            }
            return "null";
        }
    }

    public static string FindFromCSV(string dataFile, string RowName, string ColumnName)
    {
        using (var reader = new StreamReader(dataFile))
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            var names = values;
            int column = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == ColumnName)
                {
                    column = i;
                }
            }
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                values = line.Split(',');
                if (values[0] == RowName)
                {

                    return values[column];
                }
            }
            return "null";
        }
    }

    public static void GetStringFromIndex(int index)
    {
        using (var reader = new StreamReader("pref.csv"))
        {
            for (int i = 1; i < index; i++)
            {
                reader.ReadLine();
            }
            var line = reader.ReadLine();
            var values = line.Split(',');
            PlayerPrefs.SetString(values[0], values[1]);
        }
    }
}
