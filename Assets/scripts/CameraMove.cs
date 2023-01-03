using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Pleyer pleyer;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -pleyer.weight * 10);
        transform.position = Vector3.Lerp(transform.position, new Vector3(pleyer.transform.position.x, pleyer.transform.position.y, transform.position.z), 0.25f);
    }
}
