using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void DeContrainer(Rigidbody rb)
    {
        // Possivel solução poster
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log(rb);

    }
}
