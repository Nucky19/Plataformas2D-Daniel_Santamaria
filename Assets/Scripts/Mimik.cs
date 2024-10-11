using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimik : MonoBehaviour
{

    [SerializeField]private int healtPoints = 3;
    private Rigidbody2D mimikRigidbody;
    // Start is called before the first frame update
    public AudioSource audioSource;

    void Start(){
    
    }

    void Awake(){
        mimikRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        SoundManager.instance.PlaySFX(audioSource, SoundManager.instance.mimikAudio);
    }

    public void TakeDamage(){
        healtPoints-=1;
        if(healtPoints<=0) Die();

        // else anim.SetTrigger("IsHurt");
    }

    void Die(){
        // anim.SetTrigger("IsDead");
        Destroy(gameObject);
    }
}
