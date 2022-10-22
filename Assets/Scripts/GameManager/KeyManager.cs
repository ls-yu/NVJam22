using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager 
{

    private static bool[] keyFound;

    static KeyManager()
    {
        //0 will be ignored
        keyFound = new bool[4]; 
    }

    public static void FoundKey(int id)
    {
        keyFound[id] = true;
    }

    public static bool FoundAll()
    {
        return keyFound[1] && keyFound[2] && keyFound[3];
    }
}
