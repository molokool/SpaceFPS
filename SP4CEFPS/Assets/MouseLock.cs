using UnityEngine;
using Photon.Pun;

public class MouseLock : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform PlayerBody;
    float xRotation = 0f;
    private PhotonView PV;
    void Start()
    {
        PV = GetComponentInParent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();

        }
       
    }

    void BasicMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;



        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
