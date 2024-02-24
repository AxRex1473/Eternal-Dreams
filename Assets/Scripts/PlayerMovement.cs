using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speedMovement;
    [SerializeField] private Vector2 direction;  
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        animator.SetFloat("Speed", direction.magnitude);

        if(direction.x < 0) 
        {
            spriteRenderer.flipX = true;
        }
        else if(direction.x > 0) 
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direction * speedMovement * Time.fixedDeltaTime);
    }
}
