using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col){
        if(col.tag == "Enemy"){
            col.gameObject.SetActive(false);
        }
    }
}
