using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Pleyer pleyer;
    private Vector3 newPosition;
    
    private void Update()
    {
        newPosition.z = -pleyer.weight - 10;
        newPosition.x = pleyer.transform.position.x;
        newPosition.y = pleyer.transform.position.y;
        
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.1f);
    }
}
