using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.3f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    [SerializeField] float acceleration = 5.0f;



    float velocityY = 0.0f;
    float cameraPitch = 0.0f;
    CharacterController controller = null;
   
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    float currentSpeed = 0.0f;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = isSprinting ? sprintSpeed : walkSpeed;

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
            if (Input.GetButtonDown("Jump"))
            {
                velocityY = jumpForce;
            }
        }

        velocityY += gravity * Time.deltaTime;

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * currentSpeed + Vector3.up * velocityY;
        //Debug.Log(currentSpeed);
        controller.Move(velocity * Time.deltaTime);

    }


}
