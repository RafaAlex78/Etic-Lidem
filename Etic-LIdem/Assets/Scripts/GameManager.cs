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
    [SerializeField] private AudioSource[] randomEffectsAudios;
    [SerializeField] private AudioSource[] effectsAudios;
    // 0- firts Door slow opening
    // 1- firt lights Turnig on
    // 2- firts lights Turning off
    // 3- second lights turnig on
    // 4- second Door Slow opening
    // 5- Second door slam
    // 6- Third Lights On inside Infamari
    // 7- Elavator sound
    // 8- Key on the drawer lock 
    // 9- Key on keyLock
    //10- PadLock AfirmationSound
    //11- PadLock NegationSound
    //12- PadLock Button push
    //13- sounds of things falling
    //14- third Door Slow opening
    [Header("Plushie")]
    [SerializeField] private Plushie plushie;
    [SerializeField] private AudioSource plushieAudio;
    [SerializeField] private AudioClip[] plushieClips;
    [SerializeField] private GameObject plushieFinder;
    // 0 - Behind
    // 1 - Come back
    // 2 - Come on (emotionless)
    // 3 - Come on
    // 4 - Dont be scared
    // 5 - Dont go
    // 6 - dont leave me
    // 7 - dont look
    // 8 - dont peak
    // 9 - Farewell
    // 10 - GoodBye
    // 11 - Hurry (scuffed)
    // 12 - im here
    // 13 - im over here (strange)
    // 14 - just a little more
    // 15 - look at the walls
    // 16 - look
    // 17 - my old friend
    // 18 - my... arm
    // 19 - over there
    // 20 - please help me
    // 21 - please help
    // 22 - Quick Quick
    // 23 - Quick
    // 24 - Thank you
    // 25 - The FlashLight
    // 26 - The Light
    // 27 - The Walls
    // 28 - This way
    // 29 - You forgot about me

    float lastPlayedTime = 0, minTimeBetweenSounds = 25f;
    int _index2 = 1;

    public AudioSource[] Audios { get => effectsAudios; set => effectsAudios = value; }

    
    private void Update()
    {
        if(musicAudio.volume <= 0.2)
        {
            musicAudio.volume += 0.0001f;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
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
        PickedPlushie();
        //play Door Opnening Slow
    }

    public void PickedPlushie()
    {
        StartCoroutine(LightSequence1());
    }

    IEnumerator LightSequence1()
    {
        yield return new WaitForSeconds(4f);
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
        //my...arm
        plushieAudio.clip = plushieClips[18];
        plushieAudio.Play();
        yield return new WaitForSeconds(3);
        //thank you
        plushieAudio.clip = plushieClips[24];
        plushieAudio.Play();
        yield return new WaitForSeconds(1);
        plushie.TryToDisappear = true;
        yield return new WaitForSeconds(2);
        //first lights off audio
        Audios[2].PlayOneShot(Audios[2].clip);
        for (int i = 0; i < lightsCorridor2.Length; i++)
        {
            lightsCorridor2[i].SetActive(false);
        }
        plushie.Disappear();
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
            if(index != _index2)
            {
                randomEffectsAudios[index].PlayOneShot(randomEffectsAudios[index].clip);
                lastPlayedTime = Time.time;
                index = _index2;
            }
            
        }
        Invoke("PlayRandomSound", Random.Range(5f, 10f));
    }

    #region Plushie
     
    public void FarFromPlushie()
    {
        int[] faraway = { 1, 6, 12, 20, 21, 29 };
        int random = Random.Range(0, faraway.Length-1);
        plushieAudio.clip = plushieClips[faraway[random]];
        plushieAudio.Play();
    }

    public void PlushieDisappeared()
    {
        StartCoroutine(PDisappeared());
    }
    IEnumerator PDisappeared()
    {
        yield return new WaitForSeconds(1.5f);
        //This way
        plushieAudio.clip = plushieClips[28];
        plushieAudio.Play();
    }

    public void SearchForPlushie()
    {
        StartCoroutine(SearchForPlushieCor());
    }

    IEnumerator SearchForPlushieCor()
    {
        plushieFinder.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        plushieFinder.SetActive(false);
    }

    public void PlushieFound(bool value)
    {
        if (value)
        {
            //you forgot about me
            plushieAudio.clip = plushieClips[29];
            plushieAudio.Play();
        }
        else
        {
            plushie.FoundPlushie();
        }
    }
    #endregion
}
