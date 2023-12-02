using System.Collections;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject Dushman_BKL;
    [SerializeField] private GameObject Dushman_BKL_Container;
    [SerializeField] private GameObject Power_Up;
    [SerializeField] private GameObject Power_Up_Container;

    public float enemySpawnInterval = 5.0f; // Time between enemy spawns
    public float powerUpSpawnInterval = 20.0f; // Time between power-up spawns

    private bool isFinished = false;

    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
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

    public void OnPlayerDeath()
    {
        isFinished = true;
    }
}
