using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 5f;
    float xRotataion = 0f;
    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity *Time.deltaTime;

        xRotataion -= mouseY;
        //xRotataion = Mathf.Clamp(xRotataion, -90f, 90f);

        if ((xRotataion > -65f ) & (xRotataion < 65f)){
            transform.localRotation = Quaternion.Euler(xRotataion, 0f, 0f);
        }
        playerBody.Rotate (Vector3.up * mouseX);
    }
}
