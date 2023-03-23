using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject Enemy;
    private Transform parentObject;
    private bool enemySpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = new GameObject("Enemy").transform;
        //InvokeRepeating("SpawnSprite", spawndelay, spawndelay);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !enemySpawned)
        {
            Debug.Log("Space Pressed");
            SpawnEnemy();
            Debug.Log("Spawned Enemy");
            enemySpawned = true;
        }

    }

    void FixedUpdate()
    {
       
    }

    void SpawnEnemy()
    {
    Camera mainCamera = Camera.main;
    if (mainCamera != null)
        {
            float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float cameraHeight = mainCamera.orthographicSize;

            float minX = mainCamera.transform.position.x - cameraWidth * 0.4f + Enemy.transform.localScale.x / 2f;
            float maxX = mainCamera.transform.position.x + cameraWidth * 0.4f - Enemy.transform.localScale.x / 2f;
            float minY = mainCamera.transform.position.y - cameraHeight * 0.4f + Enemy.transform.localScale.y / 2f;
            float maxY = mainCamera.transform.position.y + cameraHeight * 0.4f - Enemy.transform.localScale.y / 2f;

            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), mainCamera.nearClipPlane);

            GameObject enemyObj = Instantiate(Enemy, spawnPos, Quaternion.identity);
            enemyObj.transform.parent = parentObject;
        }
    }

    void StopSpawning(){
        CancelInvoke();
    }
}
