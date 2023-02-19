using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Rigidbody2D _rb;

    // Params
    [SerializeField] private float speed;
    [SerializeField] private bool isRotate;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void MoveTo(Vector2 direction) 
    {
        float currentSpeed = speed * 1000;
        direction = direction.normalized;
        _rb.AddForce(direction*currentSpeed*Time.deltaTime);

        if (isRotate) 
        {
            if (direction.x > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (direction.x < 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
