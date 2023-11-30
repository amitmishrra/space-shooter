using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] /*Used to make a private variable public in unity*/
    private GameObject laser;


    public float fireRate = 0.2f;
    public float nextFire = 0.0f;

    private SpawnManagerScript spawnManagerScript;

    [SerializeField]
    private int lives = 3;

    void Start()
    {
        transform.position = new Vector3(0, -7, 0);

        //Getting object from other file

        //SpawnManager -- name of the componenet in which script is attached 
        //SpawnManagerScript-- name of th script 
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        if(spawnManagerScript == null )
        {
            Debug.Log("BUGG");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }


    void Fire()
    {
        //Time.time --- for how long game has been running
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            //Instantiate -- it is used to make a clone of the game objected which is attached with the variable 
            //transform.position -- it is used to give the initial position of the current object
            Instantiate(laser, transform.position + new Vector3(0, 0.02f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void Movement()
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



    public void Damage()
    {
        lives = lives - 1;

        if(lives == 0)
        {    
            Destroy(gameObject);
            spawnManagerScript.onPlyaerDeath();
        }
    }
}
