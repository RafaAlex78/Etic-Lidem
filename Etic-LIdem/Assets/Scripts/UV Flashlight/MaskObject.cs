using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    [SerializeField] private GameObject[] maskObjects;
    [SerializeField] private GameObject[] maskDecalWalls;


    void Start()
    {
        for (int i = 0; i < maskObjects.Length; i++)
        {
            maskObjects[i].GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
        for (int i = 0; i < maskDecalWalls.Length; i++)
        {
            maskObjects[i].GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }

  

    
}
