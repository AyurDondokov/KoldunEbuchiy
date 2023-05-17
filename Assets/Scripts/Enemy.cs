using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private Player player;

    private MoveObject moveObj;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        moveObj = GetComponent<MoveObject>();

        health = maxHealth;
    }

    private void Update()
    {
        Vector2 dir = player.transform.position - transform.position;
        if (!isDead)
            moveObj.MoveTo(dir.normalized);
    }

}
