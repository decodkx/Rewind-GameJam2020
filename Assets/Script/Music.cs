using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;
    public Move tape;

    int state; 
    int tempState = 1;
    bool change = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        PlayAudio();
    }

    void Update()
    {
        state = tape.inversor;
        if (tempState != state)
        {
            change = true;
        }
        else change = false;
        tempState = state;

        if(change)
        {
            if (tape.inversor == -1)
                PlayReverseAudio();
        }

        if (change)
        {
            if (tape.inversor == 1)
                PlayAudio();
        }
    }

    public void PlayAudio()
    {
        audioSource.pitch = 1;
        audioSource.volume = 0.35f;
        audioSource.clip = audioClip;
        audioSource.Play();

    }
    public void PlayReverseAudio()
    {
        audioSource.pitch = -1;
        audioSource.volume = 0.55f;
        audioSource.clip = audioClip;
        audioSource.Play();
        //StartCoroutine(StopLoop());
    }

    //public IEnumerator StopLoop()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    audioSource.loop = false;
    //}

}
