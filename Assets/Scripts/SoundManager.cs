using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public AudioClip coinAudio;
    public AudioClip jumpAudio;
    public AudioClip deathAudio;
    public AudioClip damageTakenAudio;
    public AudioClip mimikAudio;
    
    
    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioSource audioSource, AudioClip audio){
        audioSource.PlayOneShot(audio);
    }
}
