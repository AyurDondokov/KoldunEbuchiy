using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWave : MonoBehaviour
{
    public void Attack(float range, LayerMask TargetLayer, int damage)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, TargetLayer);
        foreach (Collider2D enemy in enemies)
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        Debug.Log(enemies.Length);
    }
}
