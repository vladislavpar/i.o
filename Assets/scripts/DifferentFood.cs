using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentFood: MonoBehaviour
{
    public float size;
    [SerializeField] GameObject spawner;
    public int time;
    [SerializeField] int endTime;
    void Start()
    {
        size = Random.RandomRange(0.05f, 0.1f);
        transform.localScale = new Vector3(size * 10, size * 10, size * 10);
    }
    protected void FixedUpdate()
    {
        time = time + 1;
        if (endTime <= time)
        {
            Destroy(this.gameObject);
        }
    }
}
