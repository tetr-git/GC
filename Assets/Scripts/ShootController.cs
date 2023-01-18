using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
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
        if (Input.GetKey(KeyCode.A) && shootcounter <= 0)
            shootcounter = shootspace;
            GameObject bl = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody rb = bl.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward*shootintensity);
            Destroy(bl, 6.0f);
            
        }
    }
}
