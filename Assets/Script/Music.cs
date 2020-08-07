using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.pitch = 1;
        audioSource.clip = audioClip;
        audioSource.Play();

    }
    public void PlayReverseAudio(AudioClip audioClip)
    {
        audioSource.pitch = -1;
        audioSource.loop = true;
        audioSource.clip = audioClip;
        audioSource.Play();
        StartCoroutine(StopLoop());
    }

    public IEnumerator StopLoop()
    {
        yield return new WaitForSeconds(1f);
        audioSource.loop = false;
    }

}
