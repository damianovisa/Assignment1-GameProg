using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag == "Player"){
            Debug.Log("touch");
            Destroy(coin); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
