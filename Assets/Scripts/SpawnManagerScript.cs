using System.Collections;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject Dushman_BKL;
    [SerializeField] private GameObject Dushman_BKL_Container;
    [SerializeField] private GameObject Power_Up;
    [SerializeField] private GameObject Power_Up_Container;
    [SerializeField] private GameObject Speed_Up;
    [SerializeField] private GameObject Speed_Up_Container;
    [SerializeField] private GameObject Shiled_Up;
    [SerializeField] private GameObject Shiled_Up_Container;

    public float enemySpawnInterval = 5.0f; // Time between enemy spawns
    public float powerUpSpawnInterval = 15.0f; // Time between power-up spawns
    public float speedUpSpawnInterval = 15.0f;
    public float shieldUpSpawnInterval = 15.0f;

    private bool isFinished = false;

    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
        StartCoroutine(SpawnSpeedUps());
        StartCoroutine(SpawnShieldUps());
    }

    IEnumerator SpawnEnemies()
    {
        while (!isFinished)
        {
            yield return new WaitForSeconds(enemySpawnInterval);
            HandleEnemy();
        }
    }

    void HandleEnemy()
    {
        float randomNumber = Random.Range(-13, 16);
        GameObject newEnemy = Instantiate(Dushman_BKL, new Vector3(randomNumber, 10, 0), Quaternion.identity);
        newEnemy.transform.parent = Dushman_BKL_Container.transform;
    }

    IEnumerator SpawnPowerUps()
    {
        while (!isFinished)
        {
            yield return new WaitForSeconds(powerUpSpawnInterval);
            HandlePowerUp();
        }
    }

    void HandlePowerUp()
    {
        float randomNumber = Random.Range(-13, 16);
        GameObject newPowerUp = Instantiate(Power_Up, new Vector3(randomNumber, 10, 0), Quaternion.identity);
        newPowerUp.transform.parent = Power_Up_Container.transform;
    }

    void HandleSpeedUp()
    {
        float randomNumber = Random.Range(-13, 16);
        GameObject newPowerUp = Instantiate(Speed_Up, new Vector3(randomNumber, 10, 0), Quaternion.identity);
        newPowerUp.transform.parent = Speed_Up_Container.transform;
    }
    IEnumerator SpawnSpeedUps()
    {
        while (!isFinished)
        {
            yield return new WaitForSeconds(speedUpSpawnInterval);
            HandleSpeedUp();
        }
    }

    void HandleShieldUp()
    {
        float randomNumber = Random.Range(-13, 16);
        GameObject newPowerUp = Instantiate(Shiled_Up, new Vector3(randomNumber, 10, 0), Quaternion.identity);
        newPowerUp.transform.parent = Shiled_Up_Container.transform;
    }
    IEnumerator SpawnShieldUps()
    {
        while (!isFinished)
        {
            yield return new WaitForSeconds(shieldUpSpawnInterval);
            HandleShieldUp();
        }
    }
    public void OnPlayerDeath()
    {
        isFinished = true;
    }
}
