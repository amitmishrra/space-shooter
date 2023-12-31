using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpScript : MonoBehaviour
{
    [SerializeField] private GameObject _shieldPrefab;

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
           /* Instantiate(_shieldPrefab, other.transform.position, Quaternion.identity);*/
            other.transform.GetComponent<Player>().ActivateShield();
            Destroy(gameObject);
        }
    }
}
