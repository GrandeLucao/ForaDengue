using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public int foundItens;
    public int totalItens;
    public static gameController instance;

    public GameObject gameOverObj;
    public GameObject gameWinObj;
    public GameObject pauseScreen;
    public GameObject startScreen;
    public GameObject UIOffScreen;
    private bool gameWin, gameLose, gamePause;

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
    }

    void Start()
    {
        StartScreen();
    }

    void Update()
    {
        //GamePause();
        if(TimerOn)
        {
            if(TimeLeft>0)
            {
                TimeLeft-=Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else{
                TimeLeft=0;
                TimerOn=false;
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
        TimerOn=true;
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }

    public void GamePause()
    {
        TimerOn=false;
        pauseScreen.SetActive(true);
    }

    public void StartScreen()
    {
        startScreen.SetActive(true);
    }

    public void GameOverScene()
    {
            SceneManager.LoadScene(2);
    }

    public void MenuGo()
    {
            SceneManager.LoadScene(0);        
    }

    public void Restart()
    {
            SceneManager.LoadScene(1);        
    }
}
