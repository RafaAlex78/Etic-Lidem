using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toysBox : MonoBehaviour
{
    [SerializeField] int _toysNumber = 0;

    private void Update()
    {
        if(_toysNumber > 1)
        {
            Debug.Log("Door Open");
            if(_toysNumber <2)
            {
                Debug.Log("Door Close");
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("toy"))
        {
            _toysNumber++;
            if (_toysNumber > 1)
            {
                Debug.Log("Door Open");
               

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("toy"))
        {
            _toysNumber--;
            if (_toysNumber < 2)
            {
                Debug.Log("Door Close");
            }
        }
    }
}
