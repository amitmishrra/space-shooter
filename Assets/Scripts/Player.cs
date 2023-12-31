using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject shield;
    public UI_Manager manager;

    public bool isShieldActive;
    private bool isPowerUpActive;

    public float fireRate = 0.2f;
    public float nextFire = 0.0f;
    public float speed = 4.0f;

    private SpawnManagerScript spawnManagerScript;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    public int score = 0;

    void Start()
    {
        transform.position = new Vector3(0, -5.5f, 0);
        manager= GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        // Getting object from another file
        manager.UpdateLives(lives);
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
;    }

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
        manager.UpdateLives(lives);

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

    private IEnumerator DeactivateSpeedUp(float time)
    {
        yield return new WaitForSeconds(time);
        speed = 4.0f;
    }


    public void SpeedUp()
    {
        if (lives > 1)
        {
            speed = 8.0f;
            StartCoroutine(DeactivateSpeedUp(5.0f));
        }
    }

    private IEnumerator DeactivateShield(float time)
    {
        yield return new WaitForSeconds(time);
        isShieldActive = false;
    }

    public void ActivateShield()
    {
        if (lives > 0)
        {
            isShieldActive = true;
            StartCoroutine(DeactivateShield(5.0f));
            if (shield != null)
            {
                Instantiate(shield, transform.position + new Vector3(0, 0.02f, 0), Quaternion.identity);
            }
        }
    }

     public void UpdateScore()
    {
        Debug.Log(score + " updated the score");
        if (lives > 0)
        {
            score = score + 10;
            manager.scoreText.text = "Score : " + score;
            Debug.Log(score);
        }
    }

   /* public void SetLifeSprite()
    {
        if (manager.lifeImage != null)
        {
            if (lives == 1)
            {
                manager.lifeImage.sprite = Resources.Load<Sprite>("Assets/Sprites/UI/Lives/One.png"); ;
            }
            if(lives == 2)
            {
                manager.lifeImage.sprite = Resources.Load<Sprite>("Assets/Sprites/UI/Lives/Two.png"); ;
            }
        }
        else
        {
            Debug.LogWarning("Life Image component is not assigned in the inspector.");
        }
    }*/


}
