
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [UsedImplicitly]
    public float Speed;
    [UsedImplicitly]
    public Text ScoreText;
    [UsedImplicitly]
    public Text WinText;
    private Rigidbody _rb;
    private int _score;

    // Use this for initialization
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _score = 0;
        UpdateText();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Same as Update but for physics
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    // When touching another object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            WinText.text = "Тобi пiзда!";
    }

    // When touching another object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _score = _score + 1;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        ScoreText.text = "Score: " + _score;
        WinText.text = (_score < 10) ? "" : "You Win!";
    }
}
