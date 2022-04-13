using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    // Move player in 2D space
    public float moveSpeed, jumpForce;
    public Transform groundPoint;
    bool isGrounded = false;
    public ColorEnum colorEnum;
    public Color color;

    private SpriteRenderer sr;
    private float inputX;

    Rigidbody2D rb;
    BoxCollider2D col;
    public LayerMask ground;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        rb.freezeRotation = true;

        color = ColorEnumToColorScript.instance.ColorEnumToColor(colorEnum);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .1f, ground);
        sr.color = ColorEnumToColorScript.instance.ColorEnumToColor(colorEnum);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
        if(inputX < 0)
        {
            sr.flipX = true;
        }
        else if(inputX > 0)
        {
            sr.flipX = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded && context.action.phase == InputActionPhase.Started)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hazard"))
        {
            Events.GameOver();
        }
    }    
}