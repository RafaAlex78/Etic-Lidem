using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Animator playroomAnim;
    [SerializeField] private Animator infirmaryAnim;
    [SerializeField] private Animator recordAnim;
    [SerializeField] private GameObject[] lightsCorridor1;
    [SerializeField] private GameObject[] lightsCorridor2;
    [SerializeField] private GameObject[] lightsCorridor3;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public void DeContrainer(Rigidbody rb)
    {
        // Possivel solução poster
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log(rb);

    }

    public void ExitPlayRoom()
    {
        playroomAnim.SetTrigger("Change");
    }

    public void PickedPlushiePart()
    {
        StartCoroutine(LightSequence1());
    }

    IEnumerator LightSequence1()
    {
        yield return new WaitForSeconds(1.5f);
        //play light turn on Sound
        for (int i = 0; i < lightsCorridor2.Length; i++)
        {
            lightsCorridor2[i].SetActive(true);
        }
    }

    public void RepairedPlushie()
    {
        StartCoroutine(LightSequence2());
    }

    IEnumerator LightSequence2()
    {
        yield return new WaitForSeconds(2);
        //play light turn off Sound
        for (int i = 0; i < lightsCorridor2.Length; i++)
        {
            lightsCorridor2[i].SetActive(false);
        }
        yield return new WaitForSeconds(1);
        //play light turn on Sound
        for (int i = 0; i < lightsCorridor1.Length; i++)
        {
            lightsCorridor1[i].SetActive(true);
        }
        yield return new WaitForSeconds(1);
        //Play Door opening sound
        infirmaryAnim.SetTrigger("Change");
    }



    //Do we trigger the door closing after the player turns on the lights or after they enter the infirmary?
    public void EnteredInfirmary()
    {
        //Play Door shutting sound
        infirmaryAnim.SetTrigger("Change");
        playroomAnim.SetTrigger("Change");
    }
}
