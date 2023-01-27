using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DifferentFood: MonoBehaviour
{
    [SerializeField] int lifeTime;
    
    public int size;

    private float Food_size;
    private IEnumerator liveCoroutine;
    
    void Start()
    {
        OnStart();
        liveCoroutine = LiveCoroutine();
        StartCoroutine(liveCoroutine);
    }

    protected virtual void OnStart()
    {
        size = Random.RandomRange(1,5);
        Food_size = Random.RandomRange(0.5f,5f);
        transform.localScale = new Vector3(Food_size , Food_size , Food_size );
    }

    private void OnDestroy()
    {
        if (liveCoroutine != null)
        {
            StopCoroutine(liveCoroutine);
        }
    }

    private IEnumerator LiveCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
