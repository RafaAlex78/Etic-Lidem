using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{
    [SerializeField] private int keys;
    [SerializeField] private Keypad keypad;

    public void InsertKey()
    {
        keys++;
        Debug.Log(keys);
        CheckKeys();
    }

    private void CheckKeys()
    {
        if (keys >= 3)
        {
            Debug.Log("all keys in place");
            keypad.Activate();
        }
    }
}
