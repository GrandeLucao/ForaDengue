using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool clickable;
    

    void Start()
    {
        clickable=true;
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (clickable && Input.GetMouseButtonDown(0))
        {
            gameController.instance.foundItens+=1;
            // animation.play
            this.clickable=false;
        }
    }
}
