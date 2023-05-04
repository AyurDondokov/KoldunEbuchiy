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
            enemyCount = 20;
            Debug.Log("Spawn");
            for (int i = 0; i< enemyCount; i++){
                Vector2 pos = new Vector2(Random.Range(spawnPoint.position.x - volume.x, spawnPoint.position.x + volume.x), Random.Range(spawnPoint.position.y - volume.y, spawnPoint.position.y+volume.y));
                GameObject obj = Instantiate(enemyPrefabs[0], pos, Quaternion.identity);
                
            } 
            yield return new WaitForSeconds(spawnDelay);  
        }
    }
}
