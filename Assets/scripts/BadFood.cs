using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFood : DifferentFood
{
    [SerializeField] GameObject food;
    private float FoodSize;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DifferentFood>().size = -Random.RandomRange(0.5f, 1.5f);
        FoodSize = Random.RandomRange(0.5f, 1.5f);
        transform.localScale = new Vector3(FoodSize,FoodSize,FoodSize);
    }
}
