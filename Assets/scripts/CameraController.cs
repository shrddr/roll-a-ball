using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Ball;
    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
        _offset = transform.position - Ball.transform.position;
    }

    // Same as update, but after every other object
    void LateUpdate()
    {
        if(Ball != null)
            transform.position = Ball.transform.position + _offset;
    }
}
