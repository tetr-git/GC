using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public String enemyTag = "Player2Bullet";
    
    private Rigidbody _rb;
    private Vector3 _respawnPosition;
    private Boolean _onGround = false;
    private Boolean _jumpCondition;
    private float _charger;
    private Boolean _inJumpMotion;
   
    void Start(){
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
        _respawnPosition = startPosition;
    }
    void FixedUpdate()
    {
        float moveForward = Input.GetAxis(vertical) * speed * Time.deltaTime;
        float moveSideways = Input.GetAxis(horizontal) * speed * Time.deltaTime;
        transform.Translate(0, 0, moveForward); 
        transform.Translate(moveSideways,0,0);

        if (Input.GetAxis(vertical) == 0 && Input.GetAxis(horizontal) == 0)
        {
            transform.Translate(0,0,0);
        }
        
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

        if (_jumpCondition)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpForce = _charger * 5.5f;
            _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jump = Vector3.up;
            Debug.Log("up");
            _jumpCondition = false;
            _inJumpMotion = true;
            _charger = 0f;
        }

        if (transform.position.y<-2)
        {
            transform.position = _respawnPosition;
        }
    }
    
    public void Respawn()
    {
        transform.position = _respawnPosition;
    }

    private void Update()
    {
        if (Input.GetKeyUp(jumpKey) && _onGround)
        {
            _jumpCondition = true;
        }

        if (Input.GetKey(jumpKey) && _onGround)
        {
            if (_charger < 0.75f)
            {
                _charger += Time.deltaTime;
            }
            Debug.Log(_charger);
        }

        if (_onGround && !_inJumpMotion)
        {
            _rb.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if( collision.gameObject.tag.Equals("world") == true )
        {
            _inJumpMotion = false;
            _onGround = true;
        }

        if (collision.gameObject.tag.Equals(enemyTag) == true)
        {
            Respawn();
        }
        {
            
        }
    }
    
    void OnCollisionExit(Collision collision) {
        if( collision.gameObject.tag.Equals("world") == true ){
            _onGround = false;
        }
    }
    
    
    
}
