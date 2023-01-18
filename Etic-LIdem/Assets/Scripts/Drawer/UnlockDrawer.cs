using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class UnlockDrawer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject key;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DrawerKey")
        {
            rb.constraints = RigidbodyConstraints.None;
            key.SetActive(true);
        }
    }
}
