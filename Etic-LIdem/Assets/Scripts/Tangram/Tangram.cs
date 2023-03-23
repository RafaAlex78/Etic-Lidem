using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Tangram : MonoBehaviour
{
    [SerializeField] List<GameObject> _possiblePlaces;
   [SerializeField] int _numberObjectPlaced=0;

    public void ADDPieces()
    {
        _numberObjectPlaced++;

        CheckCompletation();        
    }
    public void RemovePieces()
    {
        _numberObjectPlaced--;      
    }

    void CheckCompletation()
    {
        if(_numberObjectPlaced == _possiblePlaces.Count)
        {
            int rightPieces = 0;
            for (int i = 0; i < _possiblePlaces.Count; i++)
            {
                XRSocketInteractor socket = _possiblePlaces[i].GetComponent<XRSocketInteractor>();
                GameObject piece = _possiblePlaces[i].GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject;
                Debug.Log(piece);

               if(_possiblePlaces[i].GetComponent<TangramPlace>().RightTangramPiece == piece)
                {
                    Debug.Log("peça certa");
                    rightPieces++;
                }           
            }
            if(rightPieces == _possiblePlaces.Count)
            {
                Debug.Log("give Reward");
            }
            else
            {
                Debug.Log("wrong order");
            }

        }
    }
}
