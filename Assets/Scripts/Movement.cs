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
    public float JumpForce = 3.5f;
    public float speed = 5f;
    public float sprint = 1.5f;
    public float maxspeed = 15f;
    public float minspeed = 5f;
    private Transform camera;

    private GroundedCheck gc;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        camera = GetComponentInChildren<CameraLook>().transform;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        gc = GetComponentInChildren<GroundedCheck>();
    }


    
    void FixedUpdate()
    {

        var movementDelta = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift) && speed < maxspeed)
            speed += sprint;
        else
            if(speed>minspeed)
            speed -= sprint;
        if (Input.GetKey(KeyCode.A))
                movementDelta += Time.fixedDeltaTime * speed * -CameraRight*sprint;
        if (Input.GetKey(KeyCode.D))
                movementDelta += Time.fixedDeltaTime * speed * CameraRight*sprint;
        if (Input.GetKey(KeyCode.S))
                movementDelta += Time.fixedDeltaTime * speed * -CameraForward*sprint;
        if (Input.GetKey(KeyCode.W))
                movementDelta += Time.fixedDeltaTime * speed * CameraForward*sprint;
        

        transform.position += Time.fixedDeltaTime * speed * movementDelta.normalized;
        
        
        if (Input.GetKey(KeyCode.Space)&& gc.IsGrounded)
        {
            gc.IsGrounded = false;
            rb.AddForce(jump * JumpForce, ForceMode.Impulse);
        }
    }
    
    private Vector3 CameraForward => new Vector3(camera.forward.x, 0, camera.forward.z).normalized;
    private Vector3 CameraRight => new Vector3(camera.right.x, 0, camera.right.z).normalized;


    

 

    
}