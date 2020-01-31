using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isgrounded = true;
    public float speed = 0.0002f;
    private Transform camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        camera = GetComponentInChildren<Camera>().transform;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isgrounded = true;
    }
    void Update()
    {
        var forward = new Vector3(camera.forward.x, 0, camera.forward.z).normalized;
        var right = new Vector3(camera.right.x, 0, camera.right.z).normalized;
        if (Input.GetKey("a"))
        {
            transform.position += -right * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += right * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position += -forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            transform.position += forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("space")&&isgrounded)
        {
            isgrounded = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }


    

 

    
}