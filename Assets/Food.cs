using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Player player;
    [SerializeField] int regeneration;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void regenerationHP(){
        player.healByFood(regeneration);
    }
}
