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
    [SerializeField] private tunel tunelScript;
    [SerializeField] private GameObject map;
    [Header("Audio")]
    [SerializeField] private AudioSource doorAudioSource1;
    [SerializeField] private AudioSource doorAudioSource2;
    [SerializeField] private AudioSource doorSlamAudioSource;
    [SerializeField] private AudioSource lightsOffAudioSource;
    [SerializeField] private AudioSource lightsOnAudioSource;

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

    public void DeParent(Transform item)
    {
        item.SetParent(map.transform);
    }
   
    public void ExitPlayRoom()
    {
        playroomAnim.SetTrigger("Change");
        doorAudioSource1.PlayOneShot(doorAudioSource1.clip);
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
        lightsOffAudioSource.PlayOneShot(lightsOffAudioSource.clip);
        for (int i = 0; i < lightsCorridor2.Length; i++)
        {
            lightsCorridor2[i].SetActive(false);
        }
        yield return new WaitForSeconds(1);
        lightsOnAudioSource.PlayOneShot(lightsOnAudioSource.clip);
        for (int i = 0; i < lightsCorridor1.Length; i++)
        {
            lightsCorridor1[i].SetActive(true);
        }
        yield return new WaitForSeconds(1);
        doorAudioSource2.PlayOneShot(doorAudioSource2.clip);
        infirmaryAnim.SetTrigger("Change");
    }



    //Do we trigger the door closing after the player turns on the lights or after they enter the infirmary?
    public void EnteredInfirmary()
    {
        infirmaryAnim.SetTrigger("Change");
        playroomAnim.SetTrigger("Change");
        //Play Door shutting sound
        doorSlamAudioSource.PlayOneShot(doorSlamAudioSource.clip);
    }
}
