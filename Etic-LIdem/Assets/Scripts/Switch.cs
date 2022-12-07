using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Transform rotation;
    [SerializeField] private SwitchPuzzle switchPuzzle;
    [SerializeField] private float z;
    [SerializeField] private int value;
    private float timer;
    private bool isOn;

    private void Start()
    {
        rotation = this.transform;
    }

    private void Update()
    {
        if (switchPuzzle.Complete)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            timer += Time.deltaTime;
            
            if (timer > 0.15f)
            {
                timer = 0;
                z = rotation.rotation.z;
                if (rotation.rotation.z > 0.4 && !isOn)
                {
                    isOn = true;
                    Debug.Log(this.name + " on");
                    switchPuzzle.SwitchOn(value);
                }
                if (rotation.rotation.z < -0.4 && isOn)
                {
                    isOn = false;
                    Debug.Log(this.name + " off");
                    switchPuzzle.SwitchOff(value);
                }
            }
        }
    }
}
