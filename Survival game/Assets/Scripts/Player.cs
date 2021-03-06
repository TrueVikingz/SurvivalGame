using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private BoxCollider2D boxCollider2D;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public float Speed;
    private Animator animator;

    private void FixedUpdate()
    {
        moveDelta = Vector3.zero;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        /* Swap sprite direction, wether you're going right or left
          if (moveDelta.x > 0)
              transform.localScale = Vector3.one;
          else if (moveDelta.x < 0)
              transform.localScale = new Vector3(-1, 1, 1);*/
        
        // Make sure we can move in this direction, by casting a box there first, if the box returns null, we are free to move.
        hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make this thing move!
            transform.Translate(0, moveDelta.y * Speed * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make this thing move!
            transform.Translate(moveDelta.x * Speed * Time.deltaTime, 0, 0);
        }
        
        UpdateAnimationAndMove();
        UpdateMotor(new Vector3(x, y, 0));
    }

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
       
    }

    void UpdateAnimationAndMove()
    {
        if (moveDelta != Vector3.zero)
        {
            animator.SetFloat("Horizontal", moveDelta.x);
            animator.SetFloat("Vertical", moveDelta.y);
            animator.SetFloat("Speed", Speed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}
