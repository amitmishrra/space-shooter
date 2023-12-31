using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    // Start is called before the first frame update 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.Find("Player").GetComponent<Player>();
        if (player.isShieldActive)
        {
            transform.position = player.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
