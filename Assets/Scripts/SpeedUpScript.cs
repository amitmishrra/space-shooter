using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.down * 0.7f * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.name == "Player")
        {
            other.transform.GetComponent<Player>().SpeedUp();
            Destroy(gameObject);
        }
    }
}
