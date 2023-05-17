using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private Player player;

    private MoveObject moveObj;

    [SerializeField] float AttackDistance;
    [SerializeField] float AttackCooldown;

    private float currentAttackTime;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        moveObj = GetComponent<MoveObject>();

        health = maxHealth;
    }

    private void Update()
    {
        if (player) 
        {
            Vector2 dir = player.transform.position - transform.position;
            if (!isDead)
                moveObj.MoveTo(dir.normalized);

            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            if (distanceToPlayer <= AttackDistance)
            {
                if (currentAttackTime > AttackCooldown)
                {
                    player.TakeDamage(damage);
                    currentAttackTime = 0;
                }
                else
                    currentAttackTime += Time.deltaTime;
            }
        }
    }

}
