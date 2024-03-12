using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MoveRB : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 10f;
    public float rotationSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // การเคลื่อนที่
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.fixedDeltaTime;
        Vector3 relativeMovement = transform.TransformDirection(movement);
        rb.MovePosition(rb.position + relativeMovement);

        // การหมุน
        if (horizontal != 0)
        {
            float rotation = rotationSpeed * Time.fixedDeltaTime * horizontal;
            Quaternion turnAngle = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * turnAngle);
        }
    }
}