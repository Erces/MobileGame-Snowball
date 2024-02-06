using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject text;
    public void Start()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    public void StartGame()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(rb.gameObject.transform.forward * 10f);
        text.SetActive(false);

    }
}
