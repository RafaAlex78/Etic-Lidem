using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunelSwitch : MonoBehaviour
{
    [SerializeField] tunel tunelScript;
    [SerializeField] bool bigRoomTrigger;
    void Start()
    {
        tunelScript = GetComponentInParent<tunel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tunelScript.ChangeRoom(bigRoomTrigger);
        }
    }
}
