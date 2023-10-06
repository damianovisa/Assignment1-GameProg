using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour
{
    public void OnGameStart(){
        SceneManager.LoadScene("Level 1");
    }
    public void OnGameExit(){
        Application.Quit();
    }
}
