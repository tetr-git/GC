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
    public KeyCode viewMinKey = KeyCode.Q;
    public KeyCode viewPlusKey = KeyCode.E;
    public KeyCode jumpKey = KeyCode.LeftShift;
    public Vector3 startPosition = new Vector3(26.0f, 10.0f, 26.0f);
    private Rigidbody _rb;
    private Vector3 _respawnPosition;
   
    void Start(){
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        _respawnPosition = startPosition;
    }
    void FixedUpdate()
    {
        float moveForward = Input.GetAxis(vertical) * speed * Time.deltaTime;
        float moveSideways = Input.GetAxis(horizontal) * speed * Time.deltaTime;
        transform.Translate(0, 0, moveForward); 
        transform.Translate(moveSideways,0,0);
        
        if (Input.GetKey(viewMinKey))
        { 
            playerAngle -= rotationSpeed;
        }
        else if (Input.GetKey(viewPlusKey))
        {
            playerAngle += rotationSpeed;
        }
        Vector3 targetDirection = new Vector3(Mathf.Sin(playerAngle), 0, Mathf.Cos(playerAngle));
        transform.rotation = Quaternion.LookRotation(targetDirection);
        if (Input.GetKey(jumpKey))
        {
            _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        //on release addfore jumpforce and null jumpforce
        //on press add to jumpforce

        if (transform.position.y<-2)
        {
            transform.position = _respawnPosition;
        }
    }
}
