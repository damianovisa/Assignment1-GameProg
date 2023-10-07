using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsAnimation : MonoBehaviour
{
    float timer = 0;
    Vector3 movement = new Vector3(-0.3f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.5f,0,0);

        timer += Time.deltaTime;
        if (timer > 0.2)
        {
            timer = 0;
            movement = -1 * movement;
        }


        transform.Translate(movement * Time.deltaTime);
    }
}
