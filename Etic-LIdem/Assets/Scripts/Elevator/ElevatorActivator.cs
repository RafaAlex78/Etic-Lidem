using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{

    [SerializeField] private GameObject buttonHidden;
    [SerializeField] private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Elevator"))
        {
            other.gameObject.SetActive(false);
            buttonHidden.SetActive(true);
            anim.SetBool("Open", true);
        }
    }
}
