using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] float RandX;
    [SerializeField] Vector3 position;
    private float spawnRate = 0.1f;
    private float nextSpawn = 0.001f;
    [SerializeField] float RandY;
    [SerializeField] GameObject BadFood;
    [SerializeField] Transform playersTransform;
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (Random.RandomRange(1, 3) == 1)
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(-30 + playersTransform.position.x - playersTransform.localScale.x*2, 30 + playersTransform.position.x + playersTransform.localScale.x*2);
                RandY = Random.Range(30 + playersTransform.position.y + playersTransform.localScale.y*2, -30 + playersTransform.position.y - playersTransform.localScale.y);
                position = new Vector3(RandX, RandY);
                Instantiate(food, position, Quaternion.identity);
            }
            else
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(-30 + playersTransform.position.x -playersTransform.localScale.x*2, 30 + playersTransform.position.x + playersTransform.localScale.x*2);
                RandY = Random.Range(30 + playersTransform.position.y + playersTransform.localScale.y*2, -30 + playersTransform.position.y - playersTransform.localScale.y*2);
                position = new Vector3(RandX, RandY);
                Instantiate(BadFood, position, Quaternion.identity);
            }
            
        }
    }
}
