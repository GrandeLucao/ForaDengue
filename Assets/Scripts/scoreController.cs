using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    public int score;
    public Text scoreTxt;
    public static scoreController instance;


    void Awake()
    {
        instance=this;
        score=0;
        DontDestroyOnLoad(this.gameObject);
        
    }

    public void addScore()
    {
        float timeNow=gameController.instance.TimeLeft/60;
        timeNow*=100;
        score+=Mathf.RoundToInt(timeNow);
        scoreTxt.text=score.ToString();
    }
}
