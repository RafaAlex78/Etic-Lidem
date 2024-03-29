using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour
{
    [SerializeField] private bool complete;
    [SerializeField] private bool[] switches;
    [SerializeField] private Switch[] switchesScripts;
    [SerializeField] private bool[] solution;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private GameObject emergencyLight;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] wallsDecal;
    public bool Complete { get => complete; }
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    public void SwitchOn(int value)
    {
        switches[value] = true;
        CheckResult();
    }

    public void SwitchOff(int value)
    {
        switches[value] = false;
        CheckResult();
    }
    public void ResetAllSwitch()
    {
        for (int i = 0; i < switchesScripts.Length; i++)
        {
         
            switchesScripts[i].transform.localEulerAngles = new Vector3(-60, 0, -0);
            switchesScripts[i].Moves = 0;
        }
    }

    private void CheckResult()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if (solution[i] == switches[i])
            {
               
            }
            else
            {
                return;
            }
        }

        foreach (GameObject i in lights)
        {
            i.SetActive(true);
            
        }
        //ligar a luz
        gameManager.Audios[6].PlayOneShot(gameManager.Audios[6].clip);
        emergencyLight.SetActive(false);
        complete = true;
        gameManager.SearchForPlushie();
        for (int i = 0; i < wallsDecal.Length; i++)
        {
            wallsDecal[i].SetActive(false);
        }
    }
}
