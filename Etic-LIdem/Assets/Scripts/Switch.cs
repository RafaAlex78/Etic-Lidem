using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Transform rotation;
    [SerializeField] private float z;
    private float timer;
    private bool isOn;

    private void Start()
    {
        rotation = this.transform;
    }

    private void Update()
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
            }
            if (rotation.rotation.z < -0.4 && isOn)
            {
                isOn = false;
                Debug.Log(this.name + " off");
            }
        }
    }
}
