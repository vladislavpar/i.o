using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] GameObject pleyer;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -pleyer.GetComponent<Pleyer>().weight * 10);
    }
}
