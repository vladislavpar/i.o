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
    [SerializeField] int FoodRestrictions;
    [SerializeField] GameObject player;
    void Update()
    {
        if (FoodRestrictions <= 400)
        {
            if (Time.time > nextSpawn)
            {
                if (Random.RandomRange(1, 3) == 1)
                {
                    nextSpawn = Time.time + spawnRate;
                    RandX = Random.Range(-30 + player.GetComponent<Transform>().position.x, 30 + player.GetComponent<Transform>().position.x);
                    RandY = Random.Range(30 + player.GetComponent<Transform>().position.y, -30 + player.GetComponent<Transform>().position.y);
                    position = new Vector3(RandX, RandY);
                    Instantiate(food, position, Quaternion.identity);
                    FoodRestrictions = FoodRestrictions + 1;
                }
                else
                {
                    nextSpawn = Time.time + spawnRate;
                    RandX = Random.Range(-30 + player.GetComponent<Transform>().position.x, 30 + player.GetComponent<Transform>().position.x);
                    RandY = Random.Range(30+player.GetComponent<Transform>().position.y,-30 + player.GetComponent<Transform>().position.y);
                    position = new Vector3(RandX, RandY);
                    Instantiate(BadFood, position, Quaternion.identity);
                    FoodRestrictions = FoodRestrictions + 1;
                }
            }
        }
    }
}
