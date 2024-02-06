using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform camera;
    public GameObject snowball;
    [Header("Camera Distance Controller")]
    public Vector3 distance;
void Start(){
    
}
   void Update(){
        Debug.Log("Test");
        camera.position = snowball.transform.position;
    }
}
