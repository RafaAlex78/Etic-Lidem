using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toysBox : MonoBehaviour
{
    [SerializeField] List<GameObject> _toys;
    [SerializeField] int _toysStored = 0;
    [SerializeField] GameObject _lockedDoor;

    private void Update()
    {
        if(_toys.Count == _toysStored)
        {
            Debug.Log("Door Open");
            // open door
            // disable script
            this.enabled = false;
           
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
