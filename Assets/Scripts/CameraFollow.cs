using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

    //sledzenie kamery i move kamery
{
    [HideInInspector]
    public Vector3 targetPos;

    private float smoothMove = 2f;

    void Start()
    {
        targetPos = transform.position;
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothMove * Time.deltaTime); 
    }
}
