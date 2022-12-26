using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentFood: MonoBehaviour
{
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        size = Random.RandomRange(0.05f, 0.15f);
        transform.localScale = new Vector3(size * 10, size * 10, size * 10);
    }
}
