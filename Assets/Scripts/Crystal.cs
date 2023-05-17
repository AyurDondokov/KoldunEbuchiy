using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int xp;

    private void Start() {
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360));    
    }
}
