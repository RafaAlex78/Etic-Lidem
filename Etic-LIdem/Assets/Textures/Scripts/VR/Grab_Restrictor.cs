using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Restrictor : MonoBehaviour
{
    [SerializeField] private GameObject rightHandRay;
    [SerializeField] private GameObject leftHandRay;

    public void DisableRightRay()
    {
        rightHandRay.SetActive(false);
    }

    public void DisableLeftRay()
    {
        leftHandRay.SetActive(false);
    }

    public void EnableRightRay()
    {
        rightHandRay.SetActive(true);
    }

    public void EnableLeftRay()
    {
        leftHandRay.SetActive(true);
    }
}
