using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCiontroller : MonoBehaviour
{
    private float speed = 60.0f;
    private float rotationSpeed = 60f;
    public Transform sphereTransform;
    private Rigidbody rb;
    private bool isGrounded;
    public LayerMask layerMask;
    private float jumpForce=4f;



    void Start()
    {
       rb = sphereTransform.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        IsGrounded();
        Jump();
        
        if (isGrounded)
        {
            
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up * deltaX * rotationSpeed * Time.fixedDeltaTime);
            sphereTransform.Rotate(Vector3.up * deltaX * rotationSpeed * Time.fixedDeltaTime, Space.World);

            Vector3 mov = transform.forward * deltaZ * speed;

            rb.AddForce(mov);
        }
       
    }

    bool IsGrounded()
    {
        //Проверка условия, что персонаж находится на земле, в противном случае происходит отключение управления
        Ray ray = new Ray(transform.position, Vector3.down);
              
        if (Physics.Raycast(ray, 1.25f, layerMask))
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
            
        }

        return isGrounded;
    }

    void Jump()
    {
        if (Input.GetKey (KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

