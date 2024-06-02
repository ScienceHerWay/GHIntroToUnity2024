using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float jumpForce = 10.0f;

    private Rigidbody2D rb = null;
    private bool isJumping = false;

    private Vector2 startPosition = Vector2.zero;
    private Animator anim;
    private bool isFacingRight;

    private float Move;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      startPosition = transform.position;
      isFacingRight = true;
    }

    public void Flip()
    {
      isFacingRight = !isFacingRight;
      Vector2 localScale = transform.localScale;
      localScale.x *= -1f;
      transform.localScale = localScale;
    }

    //Checks if the avatar is still on the ground. If not, the user can't jump until they land again.
    bool isGrounded()
    {
      int layerMask = LayerMask.GetMask("Ground");
      Vector2 offset = new Vector2(0.0f, -0.0f);
      Vector2 position = new Vector2(transform.position.x, transform.position.y);
      return Physics2D.Raycast(position, Vector2.down, 0.6f, layerMask);
    }

    // Update is called once per frame
    private void Update()
    {

      //jump when space bar is detected
      if (Input.GetKeyDown(KeyCode.Space))
      {
        isJumping = true;
      }

      //only jump once player is on the ground again
      if (isJumping && isGrounded())
      {
        isJumping = false;
        rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
      }

      // makes the jumping animation bool the opposite of the bool of isGrounded.
      anim.SetBool("isJumping", !isGrounded());
      if (!isFacingRight && Move > 0.0)
      {
        Flip();
      }
      else if (isFacingRight && Move < 0.0)
      {
        Flip();
      }

      float mass = rb.mass;
      Move = Input.GetAxisRaw("Horizontal");
       //Check if the A key is being pressed, and set moveLeft accordingly.

       //Check if the A key is being pressed, and set moveLeft accordingly.
       //Animation state from idle to running/waling.
       if (Input.GetKey(KeyCode.A))
       {
         Vector2 movement = new Vector2 (-acceleration * mass, 0.0f);
         rb.AddForce(movement, ForceMode2D.Force);
         anim.SetBool("isMoving", true);
       }
       else if (Input.GetKeyUp(KeyCode.A))
       {
         anim.SetBool("isMoving", false);
       }

       //Check if the D key is being pressed, and set moveRight accordingly.
       //Animation state from idle to running/waling.
       if (Input.GetKey(KeyCode.D))
       {
         Vector2 movement = new Vector2 (acceleration * mass, 0.0f);
         rb.AddForce(movement, ForceMode2D.Force);
         anim.SetBool("isMoving", true);
       }
       else if (Input.GetKeyUp(KeyCode.D))
       {
         anim.SetBool("isMoving", false);
       }
    }


    void FixedUpdate()
    {


    }

    //"Kills" the avatar and spawns them back to their start position and resets their velocity.
    private void OnTriggerEnter2D(Collider2D other)
    {
      transform.position = startPosition;
      rb.velocity = Vector2.zero;
      Debug.Log(other.gameObject);
      Debug.Log("Trigger has been hit");
    }
}
