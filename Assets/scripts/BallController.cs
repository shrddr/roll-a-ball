using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float Speed;
    public Text ScoreText;
    public Text WinText;
    private Rigidbody _rb;
    private int _score;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _score = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Same as Update but for physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    // When touching another object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _score = _score + 1;
            UpdateText();
        }
    }

    void UpdateText()
    {
        ScoreText.text = "Score: " + _score.ToString();
        WinText.text = (_score < 10) ? "" : "You Win!";
    }
}