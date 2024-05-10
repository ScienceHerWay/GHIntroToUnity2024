using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 jumpForce = new Vector3(0.0f, 10.0f, 0.0f);
    public float rotationSpeed = 1f;
    private Rigidbody rb;
    private float yRotate = 0f;

    private Vector3 startPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    //Rotate the camera when the user moves the mouse. It rotates the avatar as well.
    void RotateView()
    {
      yRotate += Input.GetAxis("Mouse X");

      transform.eulerAngles = new Vector3(0, yRotate, 0);
    }

    //Checks if the avatar is still on the ground. If not, the user can't jump until they land again.
    bool isGrounded()
    {
      int layerMask = LayerMask.GetMask("Ground");
      Vector3 offset = new Vector3(0.0f, -0.5f, 0.0f);
      return Physics.Raycast(transform.position + offset, Vector3.down, 0.6f, layerMask);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1.0f;
        }
        if(Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1.0f;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1.0f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1.0f;
        }

        Vector3 movement = transform.forward * moveDir.y + transform.right * moveDir.x;

        moveDir = movement * speed * Time.deltaTime;

        transform.Translate(moveDir, Space.World);

        Jump();
        RotateView();

        Vector3 offset = new Vector3(0.0f, -0.5f, 0.0f);
        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.green);

    }

    //"Kills" the avatar and spawns them back to their start position and resets their velocity.
    private void OnTriggerEnter(Collider other)
    {
      transform.position = startPosition;
      rb.velocity = Vector3.zero;
      Debug.Log(other.gameObject);
      Debug.Log("Trigger has been hit");
    }
}
