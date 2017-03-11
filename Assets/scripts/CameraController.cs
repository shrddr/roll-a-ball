using JetBrains.Annotations;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [UsedImplicitly]
    public GameObject Ball;
    private Vector3 _offset;

    // Use this for initialization
    private void Start()
    {
        _offset = transform.position - Ball.transform.position;
    }

    // Same as update, but after every other object
    private void LateUpdate()
    {
        if(Ball != null)
            transform.position = Ball.transform.position + _offset;
    }
}
