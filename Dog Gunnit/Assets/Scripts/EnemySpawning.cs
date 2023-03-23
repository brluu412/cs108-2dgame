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
            SpawnEnemy();
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

        // Calculate random position along perimeter of camera viewport
        float randomSide = Random.Range(0, 4);
        float x, y;
        if (randomSide == 0) // Top
        {
            x = Random.Range(-cameraWidth, cameraWidth);
            y = cameraHeight;
        }
        else if (randomSide == 1) // Right
        {
            x = cameraWidth - 1.5f;
            y = Random.Range(-cameraHeight, cameraHeight);
        }
        else if (randomSide == 2) // Bottom
        {
            x = Random.Range(-cameraWidth, cameraWidth);
            y = -cameraHeight + 1;
        }
        else // Left
        {
            x = -cameraWidth - 0.5f;
            y = Random.Range(-cameraHeight, cameraHeight);
        }

        Vector3 spawnPos = new Vector3(x, y, mainCamera.nearClipPlane);

        GameObject enemyObj = Instantiate(Enemy, spawnPos, Quaternion.identity);
        enemyObj.transform.parent = parentObject;
    }
    }

    void StopSpawning(){
        CancelInvoke();
    }
}
