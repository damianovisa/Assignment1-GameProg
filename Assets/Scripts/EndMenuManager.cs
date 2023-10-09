using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndMenuManager : MonoBehaviour
{
    public void OnRestart(){
        SceneManager.LoadScene("Level 1");
        GameManager.score = 0;
        GameManager.prevScore = 0;
    }
}
