using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElevatorActivator : MonoBehaviour
{

    [SerializeField] private GameObject buttonHidden;
    [SerializeField] private GameObject uvLight;
    [SerializeField] private Animator anim;
    [SerializeField] private XRGrabInteractable posterTunel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Elevator"))
        {
            other.gameObject.SetActive(false);
            buttonHidden.SetActive(true);
            uvLight.SetActive(true);
            anim.SetBool("Open", true);
            //sound of thing opening, metal bang
            posterTunel.enabled = true;
        }
    }
}
