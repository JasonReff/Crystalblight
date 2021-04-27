using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayRandomizer : MonoBehaviour
{
    public static void Randomize<T>(T[] array)
    {
        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < array.Length - 1; i++)
        {
            int j = UnityEngine.Random.Range(i, array.Length + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
