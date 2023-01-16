using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Pleyer:MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] GameObject PanelDie;
    [SerializeField] GameObject PanelWin;
    [SerializeField] GameObject spawner;
    [SerializeField] Image FoodImage;
    [SerializeField] Collider2D collider;
    
    private float vertical = 1;
    public float weight = 1;
    public float weightgain;
    
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
        if (weight >= 20)
        {
            PanelWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var food = collision.GetComponent<DifferentFood>();
        
        weight = weight + food.size;
        transform.localScale = new Vector3(weight, weight, weight);
        FoodImage.fillAmount += food.size / 25;
        Destroy(collision.gameObject);
    }
} 
