using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFollower : MonoBehaviour
{
    [SerializeField] private Transform sphere;
    public Vector3 offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(sphere.transform.position.x+3, sphere.transform.position.y+3, 0);
        //this.transform.position = sphere.transform.position + offset;
    }
}
