using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject pleyer;
    // Update is called once per frame    void Update()
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -pleyer.GetComponent<Pleyer>().weight * 10);
        transform.position = Vector3.Lerp(transform.position, new Vector3(pleyer.transform.position.x, pleyer.transform.position.y, transform.position.z), 0.5f);
    }
}
