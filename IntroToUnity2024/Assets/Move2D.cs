using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
  public float acceleration = 1.0f;
  public float jumpForce = 10.0f;

  private Rigidbody2D rb = null;
  private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    //Checks if the avatar is still on the ground. If not, the user can't jump until they land again.
    bool isGrounded()
    {
      int layerMask = LayerMask.GetMask("Ground");
      Vector2 offset = new Vector2(0.0f, -0.0f);
      Vector2 position = new Vector2(transform.position.x, transform.position.y);
      return Physics2D.Raycast(position, Vector2.down, 0.6f, layerMask);
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        isJumping = true;
      }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      float mass = rb.mass;
      if (Input.GetKey(KeyCode.A))
      {
        Vector2 movement = new Vector2 (-acceleration * mass, 0.0f);
        rb.AddForce(movement, ForceMode2D.Force);
      }
      else if (Input.GetKey(KeyCode.D))
      {
        Vector2 movement = new Vector2 (acceleration * mass, 0.0f);
        rb.AddForce(movement, ForceMode2D.Force);
      }

      //Jump
      if (isJumping && isGrounded())
      {
        isJumping = false;
        rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
      }
    }
}
