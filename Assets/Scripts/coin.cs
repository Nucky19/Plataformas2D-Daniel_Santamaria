using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    private bool interactable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(interactable && Input.GetKeyDown(KeyCode.E)) {
            GameManager.instance.AddCoin();
            SoundManager.instance.PlaySFX(SoundManager.instance.coinAudio);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")) interactable=true;
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")) interactable=false;
    }
}
