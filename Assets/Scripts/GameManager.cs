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
    [SerializeField] Image[] _stars;
    [SerializeField] Sprite _starBrightSprite;
    private Animator _pauseMenuAnimator;
    private bool pauseAnimation=false;
    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;
        // _pauseMenuAnimator=_pauseCanvas.GetComponentsInChildren<Animator>();
    }
    void Start(){
        BGMManager.instance.PlayBGM(BGMManager.instance.bgmsound);
        // _starBrightSprite = Resources.Load<Sprite>("Sprites/UI/star_bright");
    }
    public void AddCoin(){
        coins+=1;
        _coinText.text=coins.ToString();
    }
    public void AddStar(){ 
        //TODO: Array de GameObject que almacene las 4 imagenes de las estrellas.
        //When AddStar -> Array busca según currentStars. Y selecciona la imagen según la cantidad de estrellas que tengas. 
        
        if(currentStars >= 0 && currentStars < 4){ //_stars.Length
            _stars[currentStars].sprite = _starBrightSprite;
            currentStars += 1;     
        } 

    }
    public void Pause(){
        if(!isPaused && !pauseAnimation) {
            isPaused=true;
            Time.timeScale=0;
            _pauseCanvas.SetActive(true);
        }else if(isPaused && !pauseAnimation){
            pauseAnimation=true;
            StartCoroutine(ClosePauseAnimation());
        }
    }

    IEnumerator ClosePauseAnimation(){
            _pauseMenuAnimator.SetBool("Close",true);
            yield return new WaitForSecondsRealtime(0.15f);
            Time.timeScale=1;
            isPaused = false;
            _pauseCanvas.SetActive(false);
            pauseAnimation=false;
    }
}
