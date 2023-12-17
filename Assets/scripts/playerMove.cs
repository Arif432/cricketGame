using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed = 0.01f; // Adjust the speed as needed

    // Update is called once per frame
    void Update()
    {
        // Get input from W, A, S, D keys
        float verticalInput = Input.GetAxis("Horizontal");
        float horizontalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply movement to the player
        transform.Translate(movement);

        // Optional: You can also use Rigidbody for better physics interactions
        // Rigidbody rb = GetComponent<Rigidbody>();
        // rb.MovePosition(rb.position + movement);
    }
}
