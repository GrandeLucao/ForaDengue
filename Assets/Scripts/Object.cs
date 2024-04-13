using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool clickable;
    private bool changeInstance;
    

    void Start()
    {
        changeInstance=true;
    }

    void Update()
    {
        if(gameController.instance.gameStart && changeInstance){
            clickable=true;
            changeInstance=false;
        }       
        if(!gameController.instance.TimerOn)
            clickable=false;
    }

    void OnMouseOver()
    {
        if (clickable && Input.GetMouseButtonDown(0) && this.CompareTag("Focos"))
        {
            gameController.instance.foundItens+=1;
            // animation.play
            this.clickable=false;
        }else{
            //animation play
            //sound/visual feedback on
        }
    }
}
