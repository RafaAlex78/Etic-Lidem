using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Transform rotation;
    [SerializeField] private SwitchPuzzle switchPuzzle;
    [SerializeField] private int value;
    private float timer;
    private bool isOn;
    private Vector3 startPos;

    private void Start()
    {
        rotation = this.transform;
        startPos = this.transform.position;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90, 0);
        transform.position = startPos;
        if (switchPuzzle.Complete)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            this.enabled = false;
        }
        else
        {
            timer += Time.deltaTime;
            
            if (timer > 0.2f)
            {
                timer = 0;
                if (rotation.rotation.x < 0.15 && !isOn)
                {
                    isOn = true;
                    Debug.Log(this.name + " on");
                    switchPuzzle.SwitchOn(value);
                }
                if (rotation.rotation.x > 0.35 && isOn)
                {
                    isOn = false;
                    Debug.Log(this.name + " off");
                    switchPuzzle.SwitchOff(value);
                }
            }
        }
        //Debug.Log(rotation.rotation.x);
    }
}
