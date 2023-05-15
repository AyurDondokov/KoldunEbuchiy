using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : Weapon
{
    [SerializeField] GameObject projectileObj;
    [SerializeField] float[] SpeedProjectile;
    [SerializeField] float DistanceForCheckEnemies;
    [SerializeField] LayerMask enemyLayer;
    protected float speedProjectiles;


    protected override void OtherValues()
    {
        speedProjectiles = SpeedProjectile[level];
    }
    protected override void Attack()
    {
        Enemy nearestEnemy = FindObjectOfType<Enemy>();

        if (nearestEnemy)
        {
            float nearestDist = Vector2.Distance(nearestEnemy.transform.position, transform.position);

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, DistanceForCheckEnemies, enemyLayer);
            foreach (Collider2D enemy in enemies)
            {
                if (Vector2.Distance(enemy.transform.position, transform.position) < nearestDist)
                {
                    nearestEnemy = enemy.GetComponent<Enemy>();
                    nearestDist = Vector2.Distance(enemy.transform.position, transform.position);
                }
            }
            Instantiate(projectileObj, transform.position, Quaternion.identity).GetComponent<Bullet>().TakeValues((nearestEnemy.transform.position - transform.position).normalized, speedProjectiles, damage);
        }
    }
}
