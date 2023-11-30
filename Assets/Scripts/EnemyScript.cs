using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 0.7f * Time.deltaTime);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    //Collider2D && OnTriggerEnter2D -- when hame is 2d 
    //Collider && OnTriggerEnter -- when game is 3d
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name== "Laser(Clone)")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        Debug.Log(other.tag);

        if(other.transform.name == "Player")
        {
            //Getting the other game object in other file....here getting the method of player in ememy method
            other.transform.GetComponent<Player>().Damage();
        }
    }
}
