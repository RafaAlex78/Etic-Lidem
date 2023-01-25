using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Restrictor : MonoBehaviour
{
    [SerializeField] private GameObject rightHandRay;
    [SerializeField] private GameObject leftHandRay;

    public void DisableRightRay()
    {
        if (rightHandRay.activeInHierarchy != false)
        {
            rightHandRay.SetActive(false);
        }
    }

    public void DisableLeftRay()
    {
        if (leftHandRay.activeInHierarchy != false)
        {
            leftHandRay.SetActive(false);
        }
    }

    public void EnableRightRay()
    {
        if (rightHandRay.activeInHierarchy != true)
        {
            rightHandRay.SetActive(true);
        }
    }

    public void EnableLeftRay()
    {
        if (leftHandRay.activeInHierarchy != true)
        {
            leftHandRay.SetActive(true);
        }
    }
}
