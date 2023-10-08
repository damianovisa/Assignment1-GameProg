using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    float timer = 0;
    public float countDown = 2f;
    Vector3 movement = new Vector3(0, 0, -0.7f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > countDown)
        {
            timer = 0;
            movement = -1 * movement;
        }


        transform.Translate(movement * Time.deltaTime);
    }
}
