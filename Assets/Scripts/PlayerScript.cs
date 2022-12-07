using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float degreesPerSecond = 2.0f;
    public float speed = 5.0f;
    public float rotationSpeed = 0.2f;
    public float playerAngle = 0;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public String vertical = "VerticalPlayerOne";
    public String horizontal = "HorizontalPlayerOne";
    public KeyCode viewMin = KeyCode.Q;
    public KeyCode viewPlus = KeyCode.E;
    
    Rigidbody _rb;
    void Start(){
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void FixedUpdate()
    {
        float moveForward = Input.GetAxis(vertical) * speed * Time.deltaTime;
        float moveSideways = Input.GetAxis(horizontal) * speed * Time.deltaTime;
        transform.Translate(0, 0, moveForward); 
        transform.Translate(moveSideways,0,0);
        
        if (Input.GetKey(viewMin))
        { 
            playerAngle -= rotationSpeed;
        }
        else if (Input.GetKey(viewPlus))
        {
            playerAngle += rotationSpeed;
        }
        Vector3 targetDirection = new Vector3(Mathf.Sin(playerAngle), 0, Mathf.Cos(playerAngle));
        transform.rotation = Quaternion.LookRotation(targetDirection);
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
}
