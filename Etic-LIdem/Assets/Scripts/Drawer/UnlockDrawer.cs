using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class UnlockDrawer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject key;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DrawerKey")
        {
            rb.constraints = RigidbodyConstraints.None;
            key.SetActive(true);
            _gameManager.Audios[8].PlayOneShot(_gameManager.Audios[8].clip);
            other.gameObject.SetActive(false);
        }
    }
}
