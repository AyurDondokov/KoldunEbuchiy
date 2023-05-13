using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    protected int damage;

    protected Animator an{ get{ return GetComponent<Animator>(); } }

    void Start(){
        health = maxHealth;
    }

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
            an.SetTrigger("death");
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
