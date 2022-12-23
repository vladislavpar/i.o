using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleyer:MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    private float vertical = 1;
    public static float weight = 1;
    [SerializeField] Collider2D collider;
    public static float weightgain;
    [SerializeField] GameObject food;

    private void Start()
    {
        if (CompareTag("Food"))
        {
            OnTriggerEnter2D(collider);
        }
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        float movementx = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementx, 0, 0) * speed;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, vertical, 0) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -vertical, 0) * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        weightgain = DifferentFood.size / 10;
        Destroy(collision.gameObject);
        weight = weight + weightgain;
        transform.localScale = new Vector3(weight, weight, weight);
    }
} 
