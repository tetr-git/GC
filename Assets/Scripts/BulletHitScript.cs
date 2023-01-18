using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitScript : MonoBehaviour
{
    public GameObject player1Object;
    public GameObject player2Object;
    private PlayerScript _player1Script;
    private PlayerScript _player2Script;
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("player1"))
        {
            _player1Script = player1Object.GetComponent<PlayerScript>();
            _player1Script.Respawn();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            _player2Script = player2Object.GetComponent<PlayerScript>();
            _player2Script.Respawn();
            Destroy(gameObject);
        }
    }
}
