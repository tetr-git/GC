using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public KeyCode shootingKey = KeyCode.C;
    
    public GameObject bullet;

    public float shootspace;
    public float shootintensity;
    private float shootcounter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootcounter -= Time.deltaTime;
        {
            // && shootcounter <= 0
            if (Input.GetKey(shootingKey) && shootcounter <= 0)
            {

                // PlayerOne C ---> PlayerTwo N
                shootcounter = shootspace;
                GameObject bl = Instantiate(bullet, transform.position, transform.rotation);
                bl.transform.Rotate(90, 0, 0);
                Rigidbody rb = bl.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * shootintensity);
                Destroy(bl, 6.0f);
            }
        }
    }
}
