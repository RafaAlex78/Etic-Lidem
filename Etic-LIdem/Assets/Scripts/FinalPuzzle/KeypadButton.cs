using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeypadButton : MonoBehaviour
{
    UnityEvent onButtoPress;
    [SerializeField] private int number;
    [SerializeField] private Keypad keypad;
    [SerializeField] private bool pressed;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private Vector3 pos;
    [SerializeField] private float posOffSetLimit;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        startingPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        pos = this.transform.position;
        if (Mathf.Abs(pos.x - startingPos.x) > posOffSetLimit && pressed == false)
        {
            keypad.InputValue(number);
            pressed = true;
            _gameManager.Audios[12].PlayOneShot(_gameManager.Audios[12].clip);
        }
        if (Mathf.Abs(pos.x - startingPos.x) < posOffSetLimit)
        {
            pressed = false;
        }
    }
}
