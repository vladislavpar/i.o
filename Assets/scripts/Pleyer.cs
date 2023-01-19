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
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + speed, transform.position.z), 0.25f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y, transform.position.z), 0.25f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y, transform.position.z), 0.25f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y - speed, transform.position.z), 0.25f);
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
        if (food.size <= weight/10)
        {
            weight = weight + food.size;
            transform.localScale = new Vector3(weight, weight, weight);
            FoodImage.fillAmount += food.size / 25;
            Destroy(collision.gameObject);
        }
        else
        {
            food.transform.localScale = new Vector3(food.transform.localScale.x / 2, food.transform.localScale.y / 2);
            food.size = food.size / 2;
            FoodImage.fillAmount += food.size / 50;
        }
    }
} 
