using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class badPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Collider2D collider;
    [SerializeField] Transform origin;
    [SerializeField] float maxDistans;

    public float weight = 1;
    public float weightgain;
    public float scaleModificator = 10;
    public bool NormalCameraMove;
    public Transform food;
    public LayerMask layer;

    private void Start()
    {
        Time.timeScale = 1;
        food = this.gameObject.transform;
    }
    private void Update()
    {
        Vector3 direction = Vector3.zero;

        Debug.DrawRay(origin.position, Vector2.up,Color.red ,maxDistans);
        Debug.DrawRay(origin.position, Vector2.right, Color.red, maxDistans);
        Debug.DrawRay(origin.position, Vector2.left, Color.red, maxDistans);
        Debug.DrawRay(origin.position, Vector2.down, Color.red, maxDistans);


        if (Physics.Raycast(origin.position,Vector2.up,maxDistans,layer))
        {
            direction.y += 1;
        }
        if (Physics.Raycast(origin.position, Vector2.right, maxDistans, layer)) 
        {
            direction.x -= 1;
        }
        if (Physics.Raycast(origin.position, Vector2.left, maxDistans, layer))
        {
            direction.x += 1;
        }
        if (Physics.Raycast(origin.position, Vector2.down, maxDistans, layer))
        {
            direction.y -= 1;
        }

        transform.position = Vector3.Lerp(transform.position, transform.position + direction * speed, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var food = collision.GetComponent<DifferentFood>();
        if (food.size <= weight / 3)
        {
            NormalCameraMove = true;
            weight = weight + food.size;
            Destroy(collision.gameObject);
        }
        else
        {
            NormalCameraMove = false;
            food.size = food.size / 2;
            weight = weight + food.size;
        }

        var weightInPercent = weight / GameConfig.MaxWeight;
        var scaleModificator = weightInPercent * GameConfig.MaxScale + 1;
        transform.localScale = Vector3.one * scaleModificator;
    }
}
