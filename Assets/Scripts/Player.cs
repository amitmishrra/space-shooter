using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;

    private bool isPowered;
    private bool isPowerUpActive;

    public float fireRate = 0.2f;
    public float nextFire = 0.0f;

    private SpawnManagerScript spawnManagerScript;

    [SerializeField]
    private int lives = 3;

    void Start()
    {
        transform.position = new Vector3(0, -5.5f, 0);

        // Getting object from another file
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        if (spawnManagerScript == null)
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
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            Instantiate(laser, transform.position + new Vector3(0, 0.02f, 0), Quaternion.identity);

            if (isPowerUpActive)
            {
                Instantiate(laser, transform.position + new Vector3(-1.52f, -1.25f, 0), Quaternion.identity);
                Instantiate(laser, transform.position + new Vector3(1.64f, -1.25f, 0), Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        int speed = 4;
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

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
        lives--;

        if (lives == 0)
        {
            Destroy(gameObject);
            spawnManagerScript.OnPlayerDeath();
        }
    }

    public void PowerUp()
    {
        if (lives > 1 && !isPowerUpActive)
        {
            isPowerUpActive = true;
            StartCoroutine(DeactivatePowerUp(5.0f));
        }
    }

    private IEnumerator DeactivatePowerUp(float time)
    {
        yield return new WaitForSeconds(time);
        isPowerUpActive = false;
        Debug.Log("Power-up deactivated");
    }

    public void RevokePower()
    {
        if (lives > 1 && isPowerUpActive)
        {
            Debug.Log("Power-up revoked");
            isPowerUpActive = false;
        }
    }
}
