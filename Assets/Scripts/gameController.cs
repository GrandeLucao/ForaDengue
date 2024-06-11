using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public int foundItens;
    public int minItens;
    public int totalItens;
    public static gameController instance;

    public GameObject gameOverObj;
    public GameObject gameWinObj;
    public GameObject pauseScreen;
    public GameObject startScreen;
    public GameObject UIOffScreen;
    private bool gameWin, gameLose, gamePause;
    public bool gameStart;

    public float TimeLeft;
    public bool TimerOn=false;
    public Text TimerTxt;

    void Awake()
    {
        instance=this;
        foundItens=0;
        gameWin=false;
        gameLose=false;
        gamePause=false;
        gameStart=false;
    }

    void Start()
    {
        StartScreen();
    }

    void Update()
    {
        if(TimerOn)
        {
            if(foundItens>=minItens)
                GameWin();
            if(TimeLeft>0)
            {
                TimeLeft-=Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else{
                TimeLeft=0;
                TimerOn=false;
                if(minItens>foundItens)
                    GameOver();
            }
        }
        
    }

    void updateTimer(float currentTime)
    {
        currentTime+=1;
        float minutes=Mathf.FloorToInt(currentTime/60);
        float seconds=Mathf.FloorToInt(currentTime%60);
        TimerTxt.text=string.Format("{0:00} : {1:00}", minutes, seconds);

    }

    public void StartGame(){
        startScreen.SetActive(false);
        UIOffScreen.SetActive(true);
        gameStart=true;
        TimerOn=true;
    }

    public void GameOver()
    {
            FindObjectOfType<AudioManager>().Play("wind");
        gameOverObj.SetActive(true);
        gameStart=false;
    }

    public void GameWin()
    {
        gameWinObj.SetActive(true);
        TimerOn=false;
    }

    public void GamePause()
    {
            FindObjectOfType<AudioManager>().Play("hop");
        TimerOn=false;
        pauseScreen.SetActive(true);
        gameStart=false;
    }

    public void GameUnpause()
    {
        TimerOn=true;
        pauseScreen.SetActive(false);
        gameStart=true;
    }

    public void StartScreen()
    {
        startScreen.SetActive(true);
    }

    public void GameWinScene()
    {
            SceneManager.LoadScene(4);
    }

    public void MenuGo()
    {
            SceneManager.LoadScene(0);    
    }

    public void Restart()
    {
            int lvl=SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(lvl);        
    }

    public void NextLevel()
    {
            FindObjectOfType<AudioManager>().Play("trans");
            int lvl=SceneManager.GetActiveScene().buildIndex;
            if(lvl>=2){SceneManager.LoadScene(4); }
            else{SceneManager.LoadScene(lvl+1);  }      
    }

    public void ExitGame(){  
            Application.Quit();  
    }
}
