using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    // Same as update, but after every other object
    void LateUpdate()
    {
        transform.position = ball.transform.position + offset;
    }
}