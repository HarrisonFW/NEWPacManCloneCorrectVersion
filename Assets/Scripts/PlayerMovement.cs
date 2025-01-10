using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Code for flipping player sprite provided by bendux on Youtube. https://www.youtube.com/watch?v=K1xZ-rycYY8

    //Code for Player movement provided by PantsOnLava on Youtube: https://www.youtube.com/watch?v=34fgsJ2-WzM

    private bool isFacingRight = false;
    private float horizontal;

    public float moveSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
