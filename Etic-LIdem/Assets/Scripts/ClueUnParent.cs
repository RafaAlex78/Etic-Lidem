using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueUnParent : MonoBehaviour
{
    [SerializeField] private Animator pillAnim;
    [SerializeField] private Transform map;

    public void UnParent()
    {
        this.transform.SetParent(map);
        TriggerPillReciever();
    }

    private void TriggerPillReciever()
    {
        pillAnim.SetTrigger("Open");
        
    }
}
