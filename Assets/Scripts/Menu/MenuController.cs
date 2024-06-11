using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject creditScene;
    
    public void BeginGame(){
        SceneManager.LoadScene(1);   
    }

    public void ExitGame(){  
            Application.Quit();  
    }

    public void CreditsImg(){
        creditScene.SetActive(true);
    }

    public void closeCredits(){
        creditScene.SetActive(false);
    }

    public void MenuGo()
    {
            SceneManager.LoadScene(0);    
    }
    
}
