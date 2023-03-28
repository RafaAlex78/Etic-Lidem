using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] private GameObject[] key;
    [SerializeField] private FinalPuzzle final;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colided");
        if (other.gameObject.CompareTag("FinalKey1"))
        {
            if (key[0].activeInHierarchy == false)
            {
                other.gameObject.SetActive(false);
                key[0].SetActive(true);
                _gameManager.Audios[9].PlayOneShot(_gameManager.Audios[9].clip);
                AddKey();
            }
        }
        if (other.gameObject.CompareTag("FinalKey2"))
        {
            if (key[1].activeInHierarchy == false)
            {
                other.gameObject.SetActive(false);
                key[1].SetActive(true);
                _gameManager.Audios[9].PlayOneShot(_gameManager.Audios[9].clip);
                AddKey();
            }
        }
        if (other.gameObject.CompareTag("FinalKey3"))
        {
            if (key[2].activeInHierarchy == false)
            {
                other.gameObject.SetActive(false);
                key[2].SetActive(true);
                _gameManager.Audios[9].PlayOneShot(_gameManager.Audios[9].clip);
                AddKey();
            }
        }
    }

    private void AddKey()
    {
        if (final != null)
        {
            
            final.InsertKey();
        }
    }
}
