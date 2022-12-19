using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleyer:MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] Rigidbody2D rigidbody;
    private float vertical = 1;
    public float weight = 1;
    [SerializeField] Collider2D collider;
    [SerializeField] float weightgain;

    private void Start()
    {
        if (CompareTag("Food"))
        {
            OnTriggerEnter2D(collider);
        }
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        float movementx = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementx, 0, 0) * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, vertical, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -vertical, 0) * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("onTrigerEnter");
        weight = weight + weightgain;
        transform.localScale += new Vector3(weight, weight, weight);
    }
} 
