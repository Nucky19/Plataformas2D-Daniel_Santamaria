using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int coins = 0;
    private bool isPaused;

    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }
    void Start(){
        BGMManager.instance.PlayBGM(BGMManager.instance.bgmsound);
    }
    public void AddCoin(){
        coins+=1;
    }
    public void Pause(){
        if(!isPaused) {
            Time.timeScale=0;
            isPaused=true;
        }else {
            Time.timeScale=1;
            isPaused = false;
        }
    }
}
