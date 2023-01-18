using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour
{
    [SerializeField] private bool complete;
    [SerializeField] private bool[] switches;
    [SerializeField] private bool[] solution;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private GameObject emergencyLight;
    public bool Complete { get => complete; }

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
        emergencyLight.SetActive(false);
        complete = true;
    }
}
