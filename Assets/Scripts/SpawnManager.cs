using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(50, 0, 0);
    public float startDelay = 2f;
    public float repeatRate;

    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        // Assigns PlayerController Asset from "Player" GameObject
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        repeatRate = 3.0f;
        
        // Instantiate (Object, Vector Position, Rotation (Quaterion))
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        BoostOnSpeed();
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }   
    }

    void BoostOnSpeed()
    {
        if(playerControllerScript.boostOn == true )
        {
            repeatRate *= 40/60;
        }
    }
}
