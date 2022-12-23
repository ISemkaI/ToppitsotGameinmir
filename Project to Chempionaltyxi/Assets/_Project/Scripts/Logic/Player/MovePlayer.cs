using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speedJump = 3f;

    private Vector3 velocity;
    private float speed = 5f;    
    private float gravity = -9.8f;
    
    private bool isGrounded;

    private void Awake()
    {
        // Не забываем ставить тэг Main Camera на камеру!
        // Находим на сцене и говорим следить за нами
        if (Camera.main.TryGetComponent(out CameraFollow cameraFollowScript))
            cameraFollowScript.SetTarget(transform);
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
           velocity.y = gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(speedJump * -1f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
