using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public float spawnDelay = 5f;
    public int enemyCount;
    public Transform spawnPoint;
    public GameObject[] enemyPrefabs;
    public Vector2 volume;
    private float x = Random.Range(0f, 100f);
    private float y = Random.Range(0f, 100f);
    
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(SpawnEnemy());
        }
        
    }
    IEnumerator SpawnEnemy()
    {
        while(true){
            enemyCount = 5;
            Debug.Log("Spawn");
            for (int i = 0; i< enemyCount; i++){
<<<<<<< Updated upstream
                float rand_x = Random.Range(spawnPoint.position.x - volume.x, spawnPoint.position.x + volume.x);
                float rand_y = Random.Range(spawnPoint.position.y - volume.y, spawnPoint.position.y + volume.y);
                rand_x  = rand_x > spawnPoint.position.x ? rand_x+15 : rand_x-15;
                rand_y  = rand_y > spawnPoint.position.y ? rand_y+8 : rand_y-8;
                
                Vector2 pos = new Vector2(rand_x, rand_y);
                GameObject obj = Instantiate(enemyPrefabs[0], pos, Quaternion.identity);
=======
                Vector2 pos = new Vector2(Random.Range(spawnPoint.position.x - volume.x, spawnPoint.position.x + volume.x), Random.Range(spawnPoint.position.y - volume.y, spawnPoint.position.y+volume.y));
                GameObject obj = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], pos, Quaternion.identity);
>>>>>>> Stashed changes
                
            } 
            yield return new WaitForSeconds(spawnDelay);  
        }
    }
}
