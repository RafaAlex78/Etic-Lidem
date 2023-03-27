using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
    [SerializeField] private AudioSource ambientAudio;
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private AudioSource[] effectsAudios;
    // 0- firts Door slow opening
    // 1- firt lights Turnig on
    // 2- firts lights Turning off
    // 3- second lights turnig on
    // 4- second Door Slow opening
    // 5- Second door slam
    // 6- Third Lights On inside Infamari
    // 7- Elavator sound
    [SerializeField] private AudioSource[] randomEffectsAudios;
        float lastPlayedTime = 0, minTimeBetweenSounds = 25f;


    //teste Dps Apagar
    [SerializeField] bool plushyHandsOnMyHands = false;

    public AudioSource[] Audios { get => effectsAudios; set => effectsAudios = value; }

    //teste Dps Apagar
    private void Update()
    {
        if(plushyHandsOnMyHands == true)
        {
            StartCoroutine(LightSequence1());
            plushyHandsOnMyHands = false;
        }
        if(ambientAudio.volume <= 0.2)
        {
            ambientAudio.volume += 0.0001f;
        }
        Debug.Log("<color=red> o :" + lastPlayedTime + minTimeBetweenSounds);

    }
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
        Invoke("PlayRandomSound", Random.Range(5f, 10f));
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
        Audios[0].PlayOneShot(Audios[0].clip);
        playroomAnim.SetTrigger("Change");
        //play Door Opnening Slow
    }

    public void PickedPlushiePart()
    {
        StartCoroutine(LightSequence1());
    }

    IEnumerator LightSequence1()
    {
        yield return new WaitForSeconds(1.5f);
        //first lights turning on
        Audios[1].PlayOneShot(Audios[1].clip);
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
        //first lights off audio
        Audios[2].PlayOneShot(Audios[2].clip);
        for (int i = 0; i < lightsCorridor2.Length; i++)
        {
            lightsCorridor2[i].SetActive(false);
        }
        yield return new WaitForSeconds(1);
        //second lights On
        Audios[3].PlayOneShot(Audios[3].clip);
        for (int i = 0; i < lightsCorridor1.Length; i++)
        {
            lightsCorridor1[i].SetActive(true);
        }
        yield return new WaitForSeconds(1);

        //2ª Door Slow Openig
        Audios[4].PlayOneShot(Audios[4].clip);
        infirmaryAnim.SetTrigger("Change");
    }



    //Do we trigger the door closing after the player turns on the lights or after they enter the infirmary?
    public void EnteredInfirmary()
    {
        infirmaryAnim.SetTrigger("Change");
        playroomAnim.SetTrigger("Change");
        //Play Door shutting sound
        Audios[5].PlayOneShot(Audios[5].clip);
    }

    public void PlayRandomSound()
    {
        Debug.Log(Time.time);
        if (Time.time > lastPlayedTime + minTimeBetweenSounds)
        {

        int index = Random.Range(0,randomEffectsAudios.Length);
        randomEffectsAudios[index].PlayOneShot(randomEffectsAudios[index].clip);
         lastPlayedTime = Time.time;
           
            
        }
        Invoke("PlayRandomSound", Random.Range(5f, 10f));

    }
}
