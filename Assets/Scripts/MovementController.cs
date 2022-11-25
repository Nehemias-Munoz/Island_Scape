using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // clase con metodos predifinidos para el movimiento, collisiones sin rigibody   
    public CharacterController controller;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private float groundDistance = 0.3f;
    private Vector3 movement;
    private Vector3 velocity;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        
        //mover elemento en el eje x y z
        movement = transform.right * xMove + transform.forward * zMove;
        controller.Move(movement * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

 }


