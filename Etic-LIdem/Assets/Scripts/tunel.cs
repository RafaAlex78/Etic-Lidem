using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunel : MonoBehaviour
{
    [Header("Swap Map Size")]
    [SerializeField] GameObject _mapToScale;

    [SerializeField] Vector3 _smallRoomScale;
    [SerializeField] Vector3 _bigRoomScale;
    [SerializeField] Vector3 _smallRoomPos;
    [SerializeField] Vector3 _bigRoomPos;


    [Header("Swap Objects")]
    [SerializeField] GameObject[] BigRoom;
    [SerializeField] GameObject[] SmallRoom;
    [SerializeField] bool test;

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
            for (int i = 0; i < BigRoom.Length; i++)
            {
                BigRoom[i].SetActive(true);
                SmallRoom[i].SetActive(false);
            }

        }
        else
        {
            _mapToScale.transform.localScale = _bigRoomScale;
            _mapToScale.transform.position = _bigRoomPos;
            for (int i = 0; i < SmallRoom.Length; i++)
            {
                SmallRoom[i].SetActive(true);
                BigRoom[i].SetActive(false);
            }
        }
    }
   
}
