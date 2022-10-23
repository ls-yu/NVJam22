using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager
{

    private static bool[] keyFound;

    static KeyManager()
    {
        keyFound = new bool[4]; 
    }
    public static void ResetKeys(){
        keyFound[0] = false;
        keyFound[1] = false;
        keyFound[2] = false;
        keyFound[3] = false;
    }
    public static void FoundKey(int id)
    {
        Debug.Log(id + " picked up");

        keyFound[id] = true;
    }
    public static void FindAllDebug(){
        keyFound[0] = true;
        keyFound[1] = true;
        keyFound[2] = true;
        keyFound[3] = true;
    }
    public static bool FoundAll()
    {
        return keyFound[0] && keyFound[1] && keyFound[2] && keyFound[3];
    }
}
