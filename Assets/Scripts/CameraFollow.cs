using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

    //sledzenie kamery i move kamery
{
    [HideInInspector]
    public Vector3 targetPos;

    private float smoothMove = 2f;

    //pozycja startowa, kamera zeby nigdzie nie uciekla 
    void Start()
    {
        targetPos = transform.position;
    }

    //pozycja poczatkowa, koncowa, delta
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothMove * Time.deltaTime); 
    }
}
