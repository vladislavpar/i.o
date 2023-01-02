using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleyer:MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    private float vertical = 1;
    public float weight = 1;
    [SerializeField] Collider2D collider;
    public float weightgain;
    [SerializeField] GameObject PanelDie;
    [SerializeField] GameObject PanelWin;
    [SerializeField] GameObject spawner;
    private void Start()
    {
        PanelWin.SetActive(false);
        PanelDie.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
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
        if (weight <= 0)
        {
            PanelDie.SetActive(true);
            Time.timeScale = 0;
        }
        if (weight >= 30)
        {
            PanelWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        weight = weight + collision.GetComponent<DifferentFood>().size;
        if (collision.GetComponent<DifferentFood>().size <= weight / 10) 
        {
            transform.localScale = new Vector3(weight, weight, weight);
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<DifferentFood>().size >= weight / 10)
        {
            collision.GetComponent<DifferentFood>().size = collision.GetComponent<DifferentFood>().size - collision.GetComponent<DifferentFood>().size - 0.05f;
            Instantiate(collision);
            Instantiate(collision);
        }
    }
} 
