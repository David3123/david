using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1, obstacle2, obstacle3, obstacle4;
    private float obstacleSpawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {
            StopCoroutine("SpawnObstacles");
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1, 35);

        if (random >= 1 && random <= 10)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, -0.5f, 0), Quaternion.identity);
        }

        else if (random >= 11 && random <= 20)
        {
            float y = Random.Range(-3, 0);
            Instantiate(obstacle2, new Vector3(transform.position.x, y, 0), Quaternion.identity);
        }
        else if (random >= 21 && random <= 30)
        {
            float y = Random.Range(-2, 1);
            Instantiate(obstacle3, new Vector3(transform.position.x, y, 0), Quaternion.identity);
        }
        else if (random >= 31 && random <= 35)
        {
            float y = Random.Range(-2, 1);
            Instantiate(obstacle4, new Vector3(transform.position.x, y, 0), Quaternion.identity);
        }

    }
    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
}
