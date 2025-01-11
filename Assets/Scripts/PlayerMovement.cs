using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CoinManager pm;



    //Code for flipping player sprite provided by Dani Krossing on Youtube: https://www.youtube.com/watch?v=Cr-j7EoM8bg

    //Code for Player movement provided by PantsOnLava on Youtube: https://www.youtube.com/watch?v=34fgsJ2-WzM



    public float moveSpeed; // public float so the players speed can be modified in the inspector
    float speedX, speedY;
    Rigidbody2D rb; // assigns the RigidBody2D component to the value "rb"

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // allows unity to access the Player's rigid body component
    }

    private void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed; //uses the Horizontal movement keys (left & right arrow, A & D)
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;   // uses the vertical movement keys (up & down arroww, W & S)
        rb.velocity = new Vector2(speedX, speedY);

        if(speedX > 0)
        {
            gameObject.transform.localScale = new Vector3((float)0.7319449, (float)0.7319449, 1);
        }
       
        else if(speedX < 0) //Both the X & Y are a specific scale so that the player dosen't grow in size when the code for flipping its sprite runs
        {
            gameObject.transform.localScale = new Vector3((float)-0.7319449, (float)0.7319449, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pill")) //compares what tags the player is colliding with
        {
            Destroy(other.gameObject); // destroyes the pill collided with
            pm.PillCount++; //incriments the amount of pills by 1
        }
    }

}
