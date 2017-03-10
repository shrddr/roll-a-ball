using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const float Speed = 5;
    private Rigidbody _rigidbody;
    private float _time;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
		_rigidbody = GetComponent<Rigidbody>();
        RandomMovement();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        _time += Time.deltaTime;
        if(_time > 3)
            RandomMovement();
    }


    // Same as Update but for physics
    void FixedUpdate()
    {

    }

    // When touching another object
    void OnCollisionEnter(Collision collision)
    {
        RandomMovement();

        if(collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }

    private void RandomMovement()
    {
        var randomVector = new Vector3(Random.value*2 - 1, 0, Random.value*2 - 1);
        _rigidbody.velocity = randomVector*Speed;
        _time = 0;
    }
}
