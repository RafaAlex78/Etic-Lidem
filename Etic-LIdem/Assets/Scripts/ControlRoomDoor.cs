using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomDoor : MonoBehaviour
{
    [SerializeField] private Animator door;

    private void OnTriggerEnter(Collider other)
    {
        if (door != null) 
        {
            if (other.gameObject.CompareTag("Player"))
            {
                door.SetTrigger("Open");
                Destroy(this.gameObject);
            }
        }
    }
}
