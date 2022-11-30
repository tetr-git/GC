using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{
    public GameObject player;// Create a public reference to the player game object.
    //public Transform target;
    private PlayerScript _player; // Reference to the script attached to player object.
    private Vector3 _offset;

    void Update()
    {   
        _offset = new Vector3(0, 1f, -5f);
        _player = player.GetComponent<PlayerScript>();
        Vector3 targetDirection = new Vector3(Mathf.Sin(_player.playerAngle), 0, Mathf.Cos(_player.playerAngle));
        Quaternion playerRotation = Quaternion.LookRotation(targetDirection);
        Vector3 offsetRotation = playerRotation * _offset;

        transform.rotation = playerRotation;
        //        transform.position = target.transform.position + offsetRotation;
        transform.position = player.transform.position + offsetRotation;
        
    }
}
