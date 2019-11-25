using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip walkingStep, runningStep;
    static AudioSource audioSrc;

    void Start()
    {
        walkingStep = Resources.Load<AudioClip>("walking");
        runningStep = Resources.Load<AudioClip>("running");        

        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = walkingStep;
        audioSrc.loop = true;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walking" :
                audioSrc.clip = walkingStep;
                audioSrc.Play();
                break;

            case "running":
                audioSrc.clip = runningStep;
                audioSrc.Play();
                break;

        }
    }


} // CLASS
