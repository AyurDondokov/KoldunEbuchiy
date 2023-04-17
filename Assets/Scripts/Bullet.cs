using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public bool isFriendly;
    public bool isDestroy;
    public Vector2 direction = Vector2.right;
    public float speed = 50f;
    public int damage = 1;

    public void GetValues(Vector2 dir, float Nspeed, int Ndamage)
    {
        direction = dir;
        speed = Nspeed;
        damage = Ndamage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rb.AddForce(direction * speed);
    }

    void OnCollisionEnter2D(Collider2D collider)
    {
        if (isFriendly){
            if (collider.GetComponent<Enemy>()){
                collider.GetComponent<Enemy>().TakeDamage(damage);
                if (isDestroy)
                    Destroy(gameObject);
            }
        }
        else{
            if (collider.GetComponent<Player>()){
                collider.GetComponent<Player>().TakeDamage(damage);
                if (isDestroy)
                    Destroy(gameObject);

            }
        }  
    }
}
