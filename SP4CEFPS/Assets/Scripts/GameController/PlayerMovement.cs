using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public Transform playerBody;
    public float movementSpeed;
    public float rotationSpeed;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    float xRotation = 0f;
    Vector3 velocity;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (PV.IsMine)
        {
            BasicMovement();
            
        }
    }

        void BasicMovement()
        {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        myCC.Move(move * movementSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        velocity.y += gravity * Time.deltaTime;
        myCC.Move(velocity * Time.deltaTime);
        }
    
        void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

    
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
