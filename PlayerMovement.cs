using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float base_movement_speed = 5.0f;
    [SerializeField] public float movement_speed_modifier = 1.0f;

    private Rigidbody2D rb;
    private Vector2 move_direction;

    // Animation tools
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // normalized causes the diagonal vector to be the same as cardinal vectors in magnitude
        move_direction = new Vector2(moveX, moveY).normalized;
        AnimateParameters(moveX, moveY, move_direction);
    }

    void AnimateParameters(float x, float y, Vector2 m)
    {
        if (m != Vector2.zero)
        {
            animator.SetFloat("Horizontal", x);
            animator.SetFloat("Vertical", y);
        }
        animator.SetFloat("Magnitude", m.magnitude);
    }

    void Move()
    {
        float x_vector = move_direction.x * base_movement_speed;
        float y_vector = move_direction.y * base_movement_speed;
        rb.velocity = new Vector2(x_vector, y_vector);
    }
}
