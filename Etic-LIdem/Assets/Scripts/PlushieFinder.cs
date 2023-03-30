using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushieFinder : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Plushie plushie = other.GetComponent<Plushie>();
        if (plushie != null)
        {
            gameManager.PlushieFound(false);
        }
    }
}
