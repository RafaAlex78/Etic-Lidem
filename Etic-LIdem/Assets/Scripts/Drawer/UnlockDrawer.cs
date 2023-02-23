using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class UnlockDrawer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject key;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DrawerKey")
        {
            key.SetActive(true);
            other.gameObject.SetActive(false);
            animator.SetTrigger("Open");
            
        }
    }
}
