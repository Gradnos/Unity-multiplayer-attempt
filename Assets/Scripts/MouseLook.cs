using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    public float mouseSensitivity = 100f;
    [SerializeField] GameObject cameras;

    public Transform playerBody;
    public Transform orientation;

    float xRotation = 0f;
    float yRotation = 0f;

    bool isLocalPlayer;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void setLocalPlayer(bool _isLocalPlayer)
    {
        isLocalPlayer = _isLocalPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90, 90);


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.Rotate(Vector3.up * mouseX);
 
        }

        if (!isLocalPlayer)
        {
            cameras.SetActive(false);
        }
    }
}
