using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    private Vector3 offset;
    
    private void Start()
    {
        offset = transform.position - Target.transform.position;
    }
    void LateUpdate()
    {
        transform.position = Target.transform.position + offset;
    }
}
