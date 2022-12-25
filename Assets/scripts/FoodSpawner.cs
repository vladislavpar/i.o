using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] float RandX;
    [SerializeField] Vector3 position;
    private float spawnRate = 2f;
    private float nextSpawn = 0.001f;
    [SerializeField] float RandY;
    [SerializeField] GameObject BadFood;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (Random.RandomRange(1,3)==1)
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(-100, 100);
                RandY = Random.Range(100, -100);
                position = new Vector3(RandX, RandY);
                Instantiate(food, position, Quaternion.identity);
            }
            else
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(-100, 100);
                RandY = Random.Range(100, -100);
                position = new Vector3(RandX, RandY);
                Instantiate(BadFood, position, Quaternion.identity);
            }
        }
    }
}
