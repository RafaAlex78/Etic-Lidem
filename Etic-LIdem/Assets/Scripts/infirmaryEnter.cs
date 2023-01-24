using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infirmaryEnter : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.EnteredInfirmary();
            Destroy(this.gameObject);
        }
    }
}
