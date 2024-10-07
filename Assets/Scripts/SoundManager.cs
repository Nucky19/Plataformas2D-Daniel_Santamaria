using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource _audioSource;
    public AudioClip coinAudio;
    public AudioClip jumpAudio;
    public AudioClip deathAudio;
    public AudioClip damageTakenAudio;
    
    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip audio){
        _audioSource.PlayOneShot(audio);
    }
}
