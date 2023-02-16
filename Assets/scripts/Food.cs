using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food: MonoBehaviour
{
    [SerializeField] int lifeTime;
    
    public int size;

    private IEnumerator liveCoroutine;
    public event Action<Food> Die;
    
    void Start()
    {
        OnStart();
        liveCoroutine = LiveCoroutine();
        StartCoroutine(liveCoroutine);
    }

    protected virtual void OnStart()
    {
        size = Random.RandomRange(1, GameConfig.MaxWeight / 100);

        var weightInPercent = size * 1f / GameConfig.MaxWeight;
        var scaleModificator = weightInPercent * GameConfig.MaxScale + 1;
        
        transform.localScale = new Vector3(scaleModificator , scaleModificator , scaleModificator );
    }

    private void OnDestroy()
    {
        Die?.Invoke(this);
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
