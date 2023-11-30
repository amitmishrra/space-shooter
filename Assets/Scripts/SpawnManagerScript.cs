using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField] /*Used to make a private variable public in unity*/
    private GameObject Dushman_BKL;

    [SerializeField]
    private GameObject Dushman_BKL_Container;

    public float enemySpeed = 10.0f;
    public float nextEnemy = 1.0f;

    private System.Random random = new System.Random();
    private bool isCoroutineRunning = false;

    private bool isFinished = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //If co-routine is already then dont call it again else call
        if (!isCoroutineRunning)
        {
            //Starting co-routine to create enemy in every 5 sec
            StartCoroutine(NewEnemy(5.0f));
            isCoroutineRunning = true;
        }
    }

    //This returns a yield which helps to make out method wait
    private IEnumerator NewEnemy(float time)
    {
        while(isFinished == false )
        {
            // this will wait for time seconds and then move farward
            yield return new WaitForSeconds(time);
            HandleEnemy();
        }
    }

    void HandleEnemy()
    {
          float randomNumber = random.Next(-13, 16);
          GameObject newEnemy =  Instantiate(Dushman_BKL, new Vector3(randomNumber, 10, 0), Quaternion.identity); // creating Game object of enemy 
          newEnemy.transform.parent = Dushman_BKL_Container.transform; // Storing the game object to a new parent container 
          nextEnemy = Time.time + enemySpeed;
    }

    public void onPlyaerDeath()
    {
        isFinished = true;
    }
}
