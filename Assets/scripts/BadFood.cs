using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFood : DifferentFood
{
    [SerializeField] GameObject food;
    private float FoodSize;
    void Start()
    {
        GetComponent<DifferentFood>().size = -Random.RandomRange(0.05f, 0.15f);
        FoodSize = Random.RandomRange(0.5f, 1.5f);
        transform.localScale = new Vector3(FoodSize,FoodSize,FoodSize);
        FixedUpdate();
    }
}
