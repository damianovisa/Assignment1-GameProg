using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.score = GameManager.prevScore;
            CharacterMovement.canDoubleJump = false;
        }
    }
}
