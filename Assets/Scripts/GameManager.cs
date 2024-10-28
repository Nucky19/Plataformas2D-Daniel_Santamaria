using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPaused;
    [SerializeField] Text _coinText;
    private int coins = 0;
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] GameObject _winCanvas;
    [SerializeField] private int currentStars = 0;
    [SerializeField] private Image[] _stars;
    [SerializeField] private Sprite _starBrightSprite;
    [SerializeField] Slider _healthBar;
    [SerializeField] private Animator _pauseMenuAnimator;
    private bool pauseAnimation=false;
    void Awake(){
        if(instance != null && instance != this) Destroy(gameObject);
        else instance = this;
        _pauseMenuAnimator=_pauseCanvas.GetComponentInChildren<Animator>();
    }
    void Start(){
        Time.timeScale=1;
        BGMManager.instance.PlayBGM(BGMManager.instance.bgmsound);
    }

    // void Update(){
    //     if(Input.GetKeyDown(KeyCode.L)) StartCoroutine(LoadAsync("Main Menu"));
    // }
    public void AddCoin(){
        coins+=1;
        _coinText.text=coins.ToString();
    }
    public void AddStar(){ 
        if(currentStars < 4){ //_stars.Length
            _stars[currentStars].sprite = _starBrightSprite;
            currentStars += 1;     
        }
        if(currentStars>=4) {
            _winCanvas.SetActive(true);
            Time.timeScale=0;
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
            _pauseMenuAnimator.SetBool("close",true);
            yield return new WaitForSecondsRealtime(0.15f);
            Time.timeScale=1;
            isPaused = false;
            _pauseCanvas.SetActive(false);
            pauseAnimation=false;
    }
   
    public void SetHealthBar(int _maxHealth){
        _healthBar.maxValue=_maxHealth;
        _healthBar.value=_maxHealth;
    }
    public void UpdateHealthBar(int health){
        _healthBar.value = health;
    }

    public void SceneLoader(string scene){
        SceneManager.LoadScene(scene);
    }

    // IEnumerator LoadAsync(string scene){
    //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
    //     while(!asyncLoad.isDone)  yield return null;
    // }
}
