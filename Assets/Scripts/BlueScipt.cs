using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        gameObject.SetActive(false);
        CharacterMovement.canDoubleJump = true;
        Invoke("reAppear",30.0f);
    }

    public void reAppear(){
        gameObject.SetActive(true);
    }
}
