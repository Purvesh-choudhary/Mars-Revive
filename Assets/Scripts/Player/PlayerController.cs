using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 10f;
    public float deceleration = 5f;
    public float maxSpeed = 10f;
    public float rotationSpeed = 100f;

    [SerializeField] AudioSource audioSource;

    private Rigidbody rb;
    private float currentSpeed = 0f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Accelerate or decelerate based on input
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            if(!audioSource.isPlaying) audioSource.Play();
            currentSpeed += moveInput * acceleration * Time.fixedDeltaTime;
        }
        else
        {
            // Slowly reduce speed when no input (simulate friction)
            audioSource.Stop();
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
        }

        // Clamp speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Apply movement
        Vector3 moveDirection = transform.forward * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Apply rotation
       // Quaternion rotateOffset = Quaternion.Euler(Vector3.up * rotateInput * rotationSpeed * Time.fixedDeltaTime);
        float effectiveRotation = rotateInput * rotationSpeed * Time.fixedDeltaTime;
        if (currentSpeed < -0.1f){
            effectiveRotation *= -1; // Reverse rotation when moving backward
        }  
        Quaternion rotateOffset = Quaternion.Euler(Vector3.up * effectiveRotation);

        rb.MoveRotation(rb.rotation * rotateOffset);
    }
}
