using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayScript : MonoBehaviour
{
    [SerializeField] int _currentPills;
    [SerializeField] int _neededPills;
    [SerializeField] private GameObject[] toGive;

    private void CheckPills()
    {
        if(_currentPills==_neededPills)
        {
            for (int i = 0; i < toGive.Length; i++)
            {
                toGive[i].SetActive(true);
            }
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
