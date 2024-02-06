using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barricade : MonoBehaviour
{
    public GameObject hitEffect;
    public AudioClip colClip;
    private Rigidbody rb;
    public GameObject[] houses;
    public BoxCollider collider;
    private void Start()
    {
        DOTween.Init();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collider.isTrigger = true;
            rb.isKinematic = false;
            rb.useGravity = true;
            AudioManager.instance.playCollisionSound(colClip);
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(hitEffect, pos, rot);

            foreach (var item in houses)
            {
                item.transform.DOMoveY(item.transform.position.y + 1, 1);
                //item.transform.DORotate(new Vector3(item.transform.rotation.x + 120, item.transform.rotation.y, item.transform.rotation.z), 2);
                item.transform.DOScale(new Vector3(0, 0, 0), 3f);
            }
        }
    }
}
