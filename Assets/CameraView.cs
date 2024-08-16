using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public float sensitivity = 2.0f;
    private float maxYRotation = 20.0f;
    private float minYRotation = -20.0f;

    private float rotationX = 0;
    private float rotationY = 0;

    public GameObject player;

    private void Start()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Adjust rotation based on mouse input
        rotationY += mouseX;
        rotationX -= mouseY;

        // Clamp the rotation to prevent over-rotation on the Y-axis
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        // Apply the rotations
        transform.localRotation = Quaternion.Euler(0, rotationY, 0); // Horizontal rotation of the camera's parent
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // Vertical rotation

        // Rotate the player along the Y axis
        player.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
