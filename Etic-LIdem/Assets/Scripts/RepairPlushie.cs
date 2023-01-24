using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPlushie : MonoBehaviour
{
    [SerializeField] private GameObject plushieArms;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy"))
        {
            plushieArms.SetActive(true);
            other.gameObject.SetActive(false);
            gameManager.RepairedPlushie();
        }
    }
}
