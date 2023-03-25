using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Transform rotation;
    [SerializeField] private float angle;
    [SerializeField] private SwitchPuzzle switchPuzzle;
    [SerializeField] private int value;
    [SerializeField] private int _maxMoves;
    [SerializeField] private int _moves;
    private float timer;
    private bool isOn;
    private Vector3 startPos;

    public int Moves { get => _moves; set => _moves = value; }
    public Vector3 StartPos { get => startPos; set => startPos = value; }


    private void Start()
    {
        rotation = this.transform;
        StartPos = this.transform.position;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90, 0);
        transform.position = StartPos;
        angle = rotation.rotation.x;
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
                if (rotation.rotation.x < 0.18f && !isOn)
                {
                    isOn = true;
                    Debug.Log(this.name + " on");
                    switchPuzzle.SwitchOn(value);
                    Moves++;
                    if (Moves > _maxMoves)
                    {
                        switchPuzzle.ResetAllSwitch();
                    }
                }
                if (rotation.rotation.x > 0.35f && isOn)
                {
                    isOn = false;
                    Debug.Log(this.name + " off");
                    switchPuzzle.SwitchOff(value);
                    Moves++;
                    if(Moves > _maxMoves)
                    {
                        switchPuzzle.ResetAllSwitch();
                    }

                }
            }
        }
        //Debug.Log(rotation.rotation.x);
    }
}
