using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;
    public float power,forwardpower,forwardimproviser,gravity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * 2f, ForceMode.Acceleration);

        Debug.Log(rb.velocity);
        if(rb.velocity.x < -15)
        {
            rb.velocity = new Vector3(-10, 0, 0);
        }

        if (forwardpower > 2.5f)
        {
            forwardpower = 2.5f;
        }
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.position.x < Screen.width / 2)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    rb.AddForce(new Vector3(0, 0, -1) * power);
                }
            }
           else if(touch.position.x > Screen.width / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    rb.AddForce(new Vector3(0, 0, 1) * power);
                }
            }
        }
        forwardpower += forwardimproviser * Time.deltaTime;
        rb.AddForce(new Vector3(-1, 0, 0) * forwardpower);



        if (Input.GetKeyDown(KeyCode.S)){
            rb.AddForce(new Vector3(1,0,0) * power);
        }
        if(Input.GetKeyDown(KeyCode.W)){
            rb.AddForce(new Vector3(-1,0,0) * power);
        }
        if(Input.GetKey(KeyCode.D)){
            rb.AddForce(new Vector3(0,0,1) * power);
        }
        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(new Vector3(0,0,-1) * power);
        }
    }
   
}
