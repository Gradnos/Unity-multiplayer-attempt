using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

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
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
 
        }

        if (!isLocalPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
