using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool clickable;
    private bool changeInstance;
    private Animator anim;
    

    void Start()
    {
        changeInstance=true;
        anim=GetComponent<Animator>();
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
            FindObjectOfType<AudioManager>().Play("WATERSPILL");
            gameController.instance.foundItens+=1;
            anim.SetTrigger("clicked");
            this.clickable=false;
        }else{
            //animation play
            //sound/visual feedback on
        }
    }
}
