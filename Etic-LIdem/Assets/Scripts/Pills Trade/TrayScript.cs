using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayScript : MonoBehaviour
{
    [SerializeField] int _currentRoundPills;
    [SerializeField] int _currentStraightPills;
    [SerializeField] int _neededRoundPills;
    [SerializeField] int _neededStraightPills;
    [SerializeField] private GameObject[] toGive;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    private void CheckPills()
    {
        if(_currentRoundPills>=_neededRoundPills &&_currentStraightPills>= _neededStraightPills)
        {
            for (int i = 0; i < toGive.Length; i++)
            {
                toGive[i].SetActive(true);
                
            }
            //faze som de objectos a cair
            _gameManager.Audios[13].PlayOneShot(_gameManager.Audios[13].clip);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("StraightPills"))
        {
            Debug.Log("+1");
            _currentStraightPills++;
            CheckPills();
        }
        if(other.CompareTag("RoundPills"))
        {
            Debug.Log("+1");
            _currentRoundPills++;
            CheckPills();
        }
        Destroy(other.gameObject);
    }
}
