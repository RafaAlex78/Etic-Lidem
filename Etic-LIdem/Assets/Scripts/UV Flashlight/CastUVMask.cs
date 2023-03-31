using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastUVMask : MonoBehaviour
{
    [SerializeField] private GameObject _cast;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] Vector3 _distance;

    private void Update()
    {

        RaycastHit hit;
        

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, _layerMask))
        {
            _cast.transform.position = hit.point;
            _distance =  hit.point - transform.position ;
            float distanceToUse=0;
            if(Mathf.Abs(_distance.x)>= Mathf.Abs(_distance.y))
            {
                if(Mathf.Abs(_distance.x)>= Mathf.Abs(_distance.z))
                {
                    distanceToUse = Mathf.Abs(_distance.x);
                }
                else
                {
                    distanceToUse = Mathf.Abs(_distance.z);
                }

            }
            else
            {
                if(Mathf.Abs(_distance.y)>= Mathf.Abs(_distance.z))
                {
                    distanceToUse = Mathf.Abs(_distance.y);
                }
                else
                {
                    distanceToUse = Mathf.Abs(_distance.z);
                }

            }
            _cast.transform.localScale = new Vector3(distanceToUse * 0.4f, distanceToUse * 0.4f, distanceToUse * 0.4f);
        }
       
    }
}
