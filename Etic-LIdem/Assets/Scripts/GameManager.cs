using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void DeContrainer(Rigidbody rb)
    {
        // Possivel solu��o poster
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log(rb);

    }
}
