using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayScript : MonoBehaviour
{
    [SerializeField] int _currentPills;
    [SerializeField] int _neededPills;

    private void CheckPills()
    {
        if(_currentPills==_neededPills)
        {
            Debug.Log("give reward");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pills"))
        {
            Debug.Log("+1");
            _currentPills++;
            CheckPills();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pills"))
        {
            Debug.Log("-1");
            _currentPills--;
        }
    }

}
