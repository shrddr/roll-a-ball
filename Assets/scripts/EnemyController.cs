using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const float Speed = 5;
    private const float TimeToChangeDirection = 3;
    private Rigidbody _rigidbody;
    private float _timeFromLastDirectionChange;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start ()
    {
		_rigidbody = GetComponent<Rigidbody>();
        RandomMovement();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update ()
    {
        _timeFromLastDirectionChange += Time.deltaTime;
        if(_timeFromLastDirectionChange > TimeToChangeDirection)
            RandomMovement();
    }


    // Same as Update but for physics
    private void FixedUpdate()
    {

    }

    // When touching another object
    private void OnCollisionEnter(Collision collision)
    {
        RandomMovement();

        if(collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }

    private void RandomMovement()
    {
        var randomVector = new Vector3(Random.value*2 - 1, 0, Random.value*2 - 1);
        _rigidbody.velocity = randomVector*Speed;
        _timeFromLastDirectionChange = 0;
    }
}
