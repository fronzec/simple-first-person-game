using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class MyFirstPersonController : MonoBehaviour
{
    public float walkSpeed = 6;
    public float runSpeed = 10;
    public float strafeSpeed = 5;
    public float gravity = 20;
    public float jumpHeight = 2;
    private bool canJump = true;
    private bool isRunning = false;
    private bool isGrounded = false;
    public bool AllowOperations = false;

    private Rigidbody _rigidbody;

    public bool IsRunning
    {
        get { return isRunning; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
    }


    private void FixedUpdate()
    {
        float forwardAndBackwardSpeed = walkSpeed;
        if (isRunning)
        {
            forwardAndBackwardSpeed = runSpeed;
        }

        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal") * strafeSpeed, 0,
            Input.GetAxis("Vertical") * forwardAndBackwardSpeed);
        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocity.y = 0;
        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        ///Jump section
        if (canJump && isGrounded && Input.GetButton("Jump"))
        {
//            _rigidbody.velocity = new Vector3(velocity.x, Mathf.Sqrt(2 * jumpHeight * gravity), velocity.z);
            _rigidbody.AddForce(new Vector3(velocity.x, Mathf.Sqrt(2 * jumpHeight * gravity), velocity.z),ForceMode.Impulse);
            isGrounded = false;
        }

        //Apply simple gravity
        _rigidbody.AddForce(new Vector3(0, -gravity * _rigidbody.mass), 0);
    }

    private void Update()
    {
        CheckIsGrounded();
        if (isGrounded && Input.GetButtonDown("Sprint"))
        {
            isRunning = true;
        }

        if (Input.GetButtonUp("Sprint"))
        {
            isRunning = false;
        }
    }

    /// <summary>
    /// Check if player is ground using raycast from position to down vector
    /// </summary>
    private void CheckIsGrounded()
    {
        float rayLenght = 1.5f;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, rayLenght))
        {
            isGrounded = true;
        }
    }
}