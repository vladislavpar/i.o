using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] float RandX;
    [SerializeField] Vector3 position;
    [SerializeField] float RandY;
    [SerializeField] GameObject BadFood;
    [SerializeField] Transform playersTransform;
    [SerializeField] Transform goodFoodParent;
    [SerializeField] Transform badFoodParent;
    
    private float spawnRateGood = 0.05f;
    private float spawnRateBad = 0.1f;

    private void Start()
    {
        StartCoroutine(SpawnGoodFoodCoroutine());
        StartCoroutine(SpawnBadFoodCoroutine());
    }

    private IEnumerator SpawnGoodFoodCoroutine()
    {
        while (true)
        {
            RandX = GetRandomX();
            RandY = GetRandomY();
            
            position = new Vector3(RandX, RandY);
            Instantiate(food, position, Quaternion.identity, goodFoodParent);

            yield return new WaitForSeconds(spawnRateGood);
        }
    }

    private IEnumerator SpawnBadFoodCoroutine()
    {
        while (true)
        {
            RandX = GetRandomX();
            RandY = GetRandomY();
            
            position = new Vector3(RandX, RandY);
            Instantiate(BadFood, position, Quaternion.identity, badFoodParent);

            yield return new WaitForSeconds(spawnRateBad);
        }
    }

    private float GetRandomX()
    {
        return Random.Range(-30 + playersTransform.position.x - playersTransform.localScale.x * 2,
            30 + playersTransform.position.x + playersTransform.localScale.x * 2);
    }
    
    private float GetRandomY()
    {
        return Random.Range(30 + playersTransform.position.y + playersTransform.localScale.y*2, 
            -30 + playersTransform.position.y - playersTransform.localScale.y);
    }
}
