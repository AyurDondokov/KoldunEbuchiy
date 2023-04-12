using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    private int damage;

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
