using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentFood: MonoBehaviour
{
    public static float size;
    // Start is called before the first frame update
    void Start()
    {
        size = Random.RandomRange(1,3);
        transform.localScale = new Vector3(size, size, size);
    }
}
