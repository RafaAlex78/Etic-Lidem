using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunel : MonoBehaviour
{
    [SerializeField] GameObject _mapToScale;

    [SerializeField] Vector3 _smallRoomScale;
    [SerializeField] Vector3 _bigRoomScale;
    [SerializeField] Vector3 _smallRoomPos;
    [SerializeField] Vector3 _bigRoomPos;

    [SerializeField] bool _onTheBigRoom;

    private void Update()
    {
        RoomUpdate();
    }
    void RoomUpdate()
    {
        if (_onTheBigRoom)
        {
            _mapToScale.transform.localScale = _smallRoomScale;
            _mapToScale.transform.position = _smallRoomPos;
           // _onTheBigRoom = false;

        }
        else
        {
            _mapToScale.transform.localScale = _bigRoomScale;
            _mapToScale.transform.position = _bigRoomPos;
            //_onTheBigRoom = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(_onTheBigRoom)
            {
                _mapToScale.transform.localScale = _smallRoomScale;
                _mapToScale.transform.position = _smallRoomPos;
                _onTheBigRoom = false;

            }
            else
            {
                _mapToScale.transform.localScale = _bigRoomScale;
                _mapToScale.transform.position = _bigRoomPos;
                _onTheBigRoom = true;
            }
        }
    }
}
