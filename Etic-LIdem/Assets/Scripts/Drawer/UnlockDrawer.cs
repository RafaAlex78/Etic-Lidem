using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class UnlockDrawer : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject key;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        anim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DrawerKey")
        {
            anim.SetTrigger("Open");
            key.SetActive(true);
            _gameManager.Audios[8].PlayOneShot(_gameManager.Audios[8].clip);
            other.gameObject.SetActive(false);
        }
    }
}
