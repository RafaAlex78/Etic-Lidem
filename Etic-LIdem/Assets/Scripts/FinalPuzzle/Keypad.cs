using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Keypad : MonoBehaviour
{
    [SerializeField] private string solution;
    [SerializeField] private string solutionCheck;
    [SerializeField] private int[] inputs;
    [SerializeField] private TextMeshPro displayText;
    [SerializeField] private GameObject displayTextObject;
    [SerializeField] private Animator doorAnimator;
    private bool complete;
    [SerializeField] private GameManager _gameManager;

    #region Startup/Setup
    private void Start()
    {
        _gameManager = GameManager.instance;
        complete = true;
    }

    public void Activate()
    {
        complete = false;
        if (displayTextObject.activeInHierarchy != true)
        {
            displayTextObject.SetActive(true);
            //10- PadLock AfirmationSound
            _gameManager.Audios[10].PlayOneShot(_gameManager.Audios[10].clip);
        }
        Debug.Log("ativo");
    }

    public void Deactivate()
    {
        complete = true;
        Debug.Log("Desativo");
    }
    #endregion

    public void InputValue(int value)
    {
        if (complete == true)
        {

        }
        else
        {
            inputs[2] = inputs[1];
            inputs[1] = inputs[0];
            inputs[0] = value;

            solutionCheck = inputs[2].ToString() + inputs[1].ToString() + inputs[0].ToString();

            DisplayText();

            if (inputs[2] != 0)
            {
                CheckResults();
            }
        }
    }

    private void CheckResults()
    {
        //solutionCheck = inputs[0].ToString() + inputs[1].ToString() + inputs[2].ToString();

        if (solution == solutionCheck)
        {
            Deactivate();
            doorAnimator.SetTrigger("Change");
            //PadLock AfirmationSound
            _gameManager.Audios[10].PlayOneShot(_gameManager.Audios[10].clip);
            //2ºDoorSlow Opening
            _gameManager.Audios[4].PlayOneShot(_gameManager.Audios[4].clip);
            Debug.Log("Right Code");
        }
        else
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = 0;
            }
            solutionCheck = inputs[2].ToString() + inputs[1].ToString() + inputs[0].ToString();
            //Pad Lock NegationSound
            _gameManager.Audios[11].PlayOneShot(_gameManager.Audios[11].clip);
            DisplayText();
        }
    }

    private void DisplayText()
    {
        displayText.text = solutionCheck;
    }
}
