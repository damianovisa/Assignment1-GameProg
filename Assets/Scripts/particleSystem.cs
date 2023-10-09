using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystem : MonoBehaviour
{

    public ParticleSystem particleSystemToSpawn;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            particleSystemToSpawn.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
