
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemyPool
{
    public GameObject[] enemies;
}
public class RandomSpawner : MonoBehaviour
{
    public float spawnDelay;
    public int enemyCount;
    public Transform spawnPoint;
    public EnemyPool[] enemyPrefabs;
    public Vector2 volume;
    public int diflvl = 0;
    
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
                float rand_x = Random.Range(spawnPoint.position.x - volume.x, spawnPoint.position.x + volume.x);
                float rand_y = Random.Range(spawnPoint.position.y - volume.y, spawnPoint.position.y + volume.y);
                rand_x  = rand_x > spawnPoint.position.x ? rand_x+15 : rand_x-15;
                rand_y  = rand_y > spawnPoint.position.y ? rand_y+8 : rand_y-8;

                Vector2 pos = new Vector2(rand_x, rand_y);
                Instantiate(enemyPrefabs[diflvl].enemies[Random.Range(0, enemyPrefabs[diflvl].enemies.Length)], pos, Quaternion.identity);
            } 
            yield return new WaitForSeconds(spawnDelay);  
        }
    }
}
