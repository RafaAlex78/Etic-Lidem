using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Plushie : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameManager gameManager;

    [SerializeField] private bool checkIfFar;
    float timer;

    [SerializeField] private Renderer render;
    [SerializeField] private GameObject[] infPos;
    XRGrabInteractable interactable;
    bool tryToDisappear;

    private void Start()
    {
        render = GetComponent<Renderer>();
        interactable = GetComponent<XRGrabInteractable>();
        gameManager = GameManager.instance;
        timer = 11;
    }

    private void Update()
    {
        Vector3 distance = player.transform.position - transform.position;
        if (Mathf.Abs(distance.x) >= 6 || Mathf.Abs(distance.z) >= 6)
        {
            timer += Time.deltaTime;
            if (timer >= 7)
            {
                timer = 0;
                gameManager.FarFromPlushie();
            }
        }

        if (tryToDisappear)
        {
            if (!render.isVisible)
            {
                tryToDisappear = false;
                CouldDisappear();
            }
        }
    }
    public void Disappear()
    {
        checkIfFar = false;
        tryToDisappear = true;
    }

    private void CouldDisappear()
    {
        interactable.enabled = false;
        transform.position = infPos[0].transform.position;
        transform.eulerAngles = infPos[0].transform.eulerAngles;
        interactable.enabled = true;
        gameManager.PlushieDisappeared();
    }

    public void FoundPlushie()
    {
        transform.position = infPos[1].transform.position;
        transform.eulerAngles = infPos[1].transform.eulerAngles;
        gameManager.PlushieFound(true);
    }
}
