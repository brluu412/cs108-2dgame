using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb2d;

    private float verticalAxis, horizontalAxis;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal, vertical;
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalAxis * moveSpeed, verticalAxis * moveSpeed);
    }
}
