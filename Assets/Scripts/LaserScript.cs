using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 8.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Here we are providing position speed and time to our lase object, when the laser will be initiated the it will go upwards 
        //Vector3.up-- provides direction
        //speed
        // per second
        //Translate method is used to translate the gameobject
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //Destroy the laser if the position is more than 8
        if (transform.position.y > 8.5)
        {
           Destroy(gameObject);
        }
    }
}
