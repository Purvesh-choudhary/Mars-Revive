using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Forward/Backward Movement
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Left/Right Rotation
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime);
    }
}
