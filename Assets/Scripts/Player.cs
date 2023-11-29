using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool flag 
    { get; set; }

    [SerializeField] /*Used to make a private variable public in unity*/
    private GameObject laser;

    void Start()
    {
        transform.position = new Vector3(0, 0, -4);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        fire();

    }


    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate -- it is used to make a clone of the game objected which is attached with the variable 
            //transform.position -- it is used to give the initial position of the current object
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }

    void movement()
    {

        //For taking inputs from keyboard
        float horizantalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        int speed = 4;
        Vector3 direction = new Vector3(horizantalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);



        // This gives a limit to the player, so it doesnt cross the border
        if (transform.position.y > 9)
        {
            transform.position = new Vector3(transform.position.x, -9, 0);
        }
        else if (transform.position.y < -9)
        {
            transform.position = new Vector3(transform.position.x, 9, 0);
        }

        if (transform.position.x > 18)
        {
            transform.position = new Vector3(-15, transform.position.y, 0);
        }
        else if (transform.position.x < -15)
        {
            transform.position = new Vector3(18, transform.position.y, 0);
        }
    }
}
