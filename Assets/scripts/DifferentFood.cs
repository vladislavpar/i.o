using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentFood: MonoBehaviour
{
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        size = Random.RandomRange(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, size);
    }
}
