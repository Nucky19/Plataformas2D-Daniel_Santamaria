using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPaused;
    [SerializeField] Text _coinText;
    private int coins = 0;
    private int currentStars = 0;
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] GameObject _stars;

    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }
    void Start(){
        BGMManager.instance.PlayBGM(BGMManager.instance.bgmsound);
    }
    public void AddCoin(){
        coins+=1;
        _coinText.text=coins.ToString();
    }
    public void AddStar(){ 
        //TODO: Array de GameObject que almacene las 4 imagenes de las estrellas.
        //When AddStar -> Array busca según currentStars. Y selecciona la imagen según la cantidad de estrellas que tengas. 
        
        currentStars+=1;
        // _coinText.text=coins.ToString();

    }
    public void Pause(){
        if(!isPaused) {
            Time.timeScale=0;
            isPaused=true;
            _pauseCanvas.SetActive(true);
        }else {
            Time.timeScale=1;
            isPaused = false;
            _pauseCanvas.SetActive(false);
        }
    }
}
