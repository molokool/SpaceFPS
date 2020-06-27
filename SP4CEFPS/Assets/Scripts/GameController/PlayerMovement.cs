using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public float movementSpeed;
    public float rotationSpeed;
 
    void Start()
    {
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();
            BasicRotation();
        }
    }

        void BasicMovement()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myCC.Move(-transform.forward * Time.deltaTime * movementSpeed);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                myCC.Move(transform.right * Time.deltaTime * movementSpeed);
            }
        }
    
        void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        transform.Rotate(new Vector3(mouseY, mouseX));
    }
}
