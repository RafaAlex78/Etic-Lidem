using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemReturner : MonoBehaviour
{
    [SerializeField] private GameObject returnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        collidedObject.transform.position = returnPoint.transform.position;
        StartCoroutine(ResetVelocity(collidedObject));
    }

    IEnumerator ResetVelocity(GameObject collidedObject)
    {
        Rigidbody rb = collidedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        yield return new WaitForSeconds(0.5f);
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

}
