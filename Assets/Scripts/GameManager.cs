using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public static int score = 0;
    public static int prevScore = 0;


    private void Awake() { 
        Instance = this;
        DontDestroyOnLoad(Instance);
        // If there is an instance, and it's not me, delete myself. 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    } 
    
    public void IncrementScore(){
        score+= 50;
    }
    
}
