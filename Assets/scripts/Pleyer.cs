using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Pleyer:MonoBehaviour
{
    public event Action<float> DieEndWin;

    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] GameObject PanelDie;
    [SerializeField] GameObject PanelWin;
    [SerializeField] GameObject spawner;
    [SerializeField] Image FoodImage;
    [SerializeField] Collider2D collider;
    [SerializeField] TextMeshProUGUI rooting_time;

    private float vertical = 1;
    public float weight = 1;
    public float weightgain;

    private bool stop_coroutine = true;
    private float time;
    
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
        if (weight <= 0 || weight > 2000)
        {
            DieEndWin?.Invoke(weight);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var food = collision.GetComponent<DifferentFood>();
        if (food.size <= weight/3)
        {
            weight = weight + food.size;
            transform.localScale = new Vector3(weight/10, weight/10, weight/10);
            FoodImage.fillAmount += food.size /25 ;
            Destroy(collision.gameObject);
        }
        else
        {
            food.transform.localScale = new Vector3(food.transform.localScale.x / 2, food.transform.localScale.y / 2);
            if (food.size <= 1)
            {
                weight = weight + food.size;
                transform.localScale = new Vector3(weight/10, weight/10, weight/10);
            }
            food.size = food.size / 2;
            FoodImage.fillAmount += food.size / 150;
        }
    }
    private IEnumerator speed_up_coroutine()
    {
        stop_coroutine = true;
        while (stop_coroutine)
        {
            weight = weight - speed;
            speed = speed + 0.2f;
            for (int i = 0; i < time*10; i++)
            {
                rooting_time.text = " Rooting Time : " + (i - time);
                yield return new WaitForSeconds(1f);
            }
            speed = 0.2f;
            stop_coroutine = false;
        }
        rooting_time.text = " Rooting Time : nothing";
        time = 0;
        StopCoroutine("speed_up_coroutine");
    }
    public void speed_up()
    {
        if (weight >= 1)
        {
            time = time + weight;
            StartCoroutine("speed_up_coroutine");
        }
    }
} 
