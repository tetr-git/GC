using System;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public KeyCode shootingKey = KeyCode.C;
    public GameObject bullet;
    public float shootspace;
    public float shootintensity;
    public String enemyBulletTag = "Player2Bullet";
    
    private float _shootcounter;

    //@source https://www.youtube.com/watch?v=C-yqRxmwDxg 
    void Update()
    {
        _shootcounter -= Time.deltaTime;
        {
            // && shootcounter <= 0
            if (Input.GetKey(shootingKey) && _shootcounter <= 0)
            {

                // PlayerOne C ---> PlayerTwo N
                _shootcounter = shootspace;
                GameObject bl = Instantiate(bullet, transform.position, transform.rotation);
                bl.tag = enemyBulletTag;
                bl.transform.Rotate(90, 0, 0);
                Rigidbody rb = bl.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * shootintensity);
                Destroy(bl, 4.0f);
            }
        }
    }
}
