using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float speed = 100f;
    private Rigidbody2D rb;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetFloat("X", 0);
        animator.SetFloat("Y", -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Move();
        Animate();
    }

    private void Move(){
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        if(Horizontal == 0 && Vertical == 0){
            rb.velocity = new Vector2(0,0);
            return;
        }

        Direction = new Vector2(Horizontal, Vertical);

        rb.velocity = new Vector2(Horizontal * speed, Vertical * speed);
    }

    private void Animate(){
        animator.SetFloat("X", Direction.x);
        animator.SetFloat("Y", Direction.y);
    }
    
}
