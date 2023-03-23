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


    private void Start()
    {
    //    _mapToScale.transform.localScale = _bigRoomScale;
    //    _mapToScale.transform.position = _bigRoomPos;
    }
    public void ChangeRoom(bool isInBigRoom)
    {
        if (isInBigRoom)
        {
            _mapToScale.transform.localScale = _smallRoomScale;
            _mapToScale.transform.position = _smallRoomPos;
            

        }
        else
        {
            _mapToScale.transform.localScale = _bigRoomScale;
            _mapToScale.transform.position = _bigRoomPos;
        }
    }
   
}
