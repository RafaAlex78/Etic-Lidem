using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{

    [SerializeField] private GameObject buttonHidden;
    [SerializeField] private GameObject uvLight;
    [SerializeField] private Animator anim;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Elevator"))
        {
            other.gameObject.SetActive(false);
            buttonHidden.SetActive(true);
            uvLight.SetActive(true);
            anim.SetBool("Open", true);
            //play elavator sound
            gameManager.Audios[7].PlayOneShot(gameManager.Audios[7].clip);
        }
    }
}
