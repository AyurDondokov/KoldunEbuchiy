using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    protected int damage;

    public void SetValues(int newHealth, int newDamage) 
    {
        maxHealth = newHealth;
        health = maxHealth;

        damage = newDamage;
    }

    public void TakeDamage(int inDamage) 
    {
        health -= inDamage;
        if (health <= 0)
            Die();
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
