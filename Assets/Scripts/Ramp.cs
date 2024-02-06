using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public Transform playerT;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        playerT = GameObject.Find("Player").GetComponent<Transform>();
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("push", 0.05f);

        }
    }
    
    void push()
    {
        rb.AddForce(-this.transform.forward * 5/rb.mass, ForceMode.Impulse);
        rb.AddForce(this.transform.up * 2/rb.mass, ForceMode.Impulse);
    }
}
