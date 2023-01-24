using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toysBox : MonoBehaviour
{
    [SerializeField] List<GameObject> _toys;
    [SerializeField] int _toysStored = 0;
    [SerializeField] GameObject _lockedDoor;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void Update()
    {
        //the -1 is there cause one of the toys has 2 hitboxes and it counts as 2 toys
        if(_toys.Count == _toysStored - 1)
        {
            Debug.Log("Door Open");
            // open door
            // disable script
            this.enabled = false;
            _gameManager.ExitPlayRoom();
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Toy"))
        {
            _toysStored++;
       
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Toy"))
        {
            _toysStored--;
  
        }
    }
}
