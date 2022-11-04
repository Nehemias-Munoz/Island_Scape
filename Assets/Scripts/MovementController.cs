using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // clase con metodos predifinidos para el movimiento, collisiones sin rigibody   
    public CharacterController controller;
    [SerializeField] private float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        
        //mover elemento en el eje x y z
        Vector3 movement = transform.right * xMove + transform.forward * zMove;
        controller.Move(movement * (speed * Time.deltaTime));
    }
}
