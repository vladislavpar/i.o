using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DifferentFood: MonoBehaviour
{
    [SerializeField] int lifeTime;
    
    public float size;
    private IEnumerator liveCoroutine;
    
    void Start()
    {
        OnStart();
        liveCoroutine = LiveCoroutine();
        StartCoroutine(liveCoroutine);
    }

    protected virtual void OnStart()
    {
        size = Random.RandomRange(0.05f,0.5f);
        transform.localScale = new Vector3(size * 10, size * 10, size * 10);
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
