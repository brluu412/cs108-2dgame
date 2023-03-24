using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject bigEnemyPrefab;

    [SerializeField]
    private float enemyInterval = 3.5f;
    [SerializeField]
    private float bigEnemyInterval = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
        StartCoroutine(spawnEnemy(bigEnemyInterval, bigEnemyPrefab));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy){
            yield return new WaitForSeconds(interval);
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

            GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
            //can add counter
            StartCoroutine(spawnEnemy(interval, enemy));
    }
        
    }

    
}
