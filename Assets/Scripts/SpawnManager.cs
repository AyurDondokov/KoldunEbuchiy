using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public void SpawnObject(Vector2 worldPosition, GameObject toSpawn)
    {
        
        //float rand_x = Random.Range(spawnPoint.position.x - volume.x, spawnPoint.position.x + volume.x);
        //float rand_y = Random.Range(spawnPoint.position.y - volume.y, spawnPoint.position.y + volume.y);
        Transform t = Instantiate(toSpawn).transform;
        t.position = worldPosition;
    }
}
