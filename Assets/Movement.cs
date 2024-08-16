using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Gun g;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Reference to the Rigidbody component
        g = GetComponent<Gun>();

        GameObject gunObject = GameObject.Find("gun");

        // Ensure the gunObject is found before trying to access its Gun component
        if (gunObject != null)
        {
            g = gunObject.GetComponent<Gun>();
        }
        else
        {
            Debug.LogWarning("Gun GameObject not found.");
        }
    
}

    private void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Calculate the direction to move
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Normalize the movement vector so that diagonal movement isn't faster
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Apply the movement to the player
        rb.MovePosition(transform.position + transform.TransformDirection(movement));
    }

    // Detect collision with an object tagged as "Ammo"
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            // Increase the current ammo by 25
            g.currentAmmo += 25;

            // Destroy the ammo GameObject
            Destroy(other.gameObject);

            // Optionally, display the current ammo count in the console (for testing)
            Debug.Log("Current Ammo: " + g.currentAmmo);
        }
    }
}
