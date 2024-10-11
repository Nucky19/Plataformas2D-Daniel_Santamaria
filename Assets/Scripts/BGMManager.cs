using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    private AudioSource _audioSource;
    public AudioClip bgmsound;

    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        _audioSource = GetComponent<AudioSource>();

        _audioSource.loop = true;
        _audioSource.mute = true;
    }

    public void PlayBGM(AudioClip audio){
        _audioSource.clip=audio;
        _audioSource.Play();
    }

    public void StopBGM(){
        _audioSource.Stop();
    }
    public void PauseBGM(){
        _audioSource.Pause();
    }



    
}
