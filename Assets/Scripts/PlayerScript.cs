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
    
    Rigidbody _rb;
    void Start(){
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void FixedUpdate()
    {
        float moveForward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveSideways = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0, 0, moveForward);
        transform.Translate(moveSideways,0,0);
        
        if (Input.GetKey(KeyCode.Q))
        { 
            playerAngle -= rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.E))
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
