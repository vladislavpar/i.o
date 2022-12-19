using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] float RandX;
    [SerializeField] Vector3 position;
    private float spawnRate = 2f;
    private float nextSpawn = 0.0f;
    [SerializeField] float RandY;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            RandX = Random.Range(-20,20);
            RandY = Random.Range(20, -20);
            position = new Vector3(RandX,RandY);
            Instantiate(food, position, Quaternion.identity);
        }
    }
}
