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

    [SerializeField] float lifeTime;
    protected float currentLifeTime;

    [SerializeField] AnimationCurve SpeedCurve;

    public void TakeValues(Vector2 dir, float Nspeed, int Ndamage)
    {
        direction = dir;
        speed = Nspeed;
        damage = Ndamage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentLifeTime <= lifeTime)
            currentLifeTime += Time.deltaTime;
        else
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        rb.AddForce(direction * speed * SpeedCurve.Evaluate(currentLifeTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFriendly)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                if (isDestroy)
                    Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.GetComponent<Player>())
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(damage);
                if (isDestroy)
                    Destroy(gameObject);

            }
        }
    }
}
