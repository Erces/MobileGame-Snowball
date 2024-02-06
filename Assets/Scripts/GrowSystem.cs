using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class GrowSystem : MonoBehaviour
{
    public float growRate;
    public GameObject hitEffect;
    public AudioClip colClip;
    public CinemachineVirtualCamera cmFreeCam;
    public CinemachineBasicMultiChannelPerlin noise;
    private Rigidbody rb;
    public GameObject respawnButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        noise = cmFreeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Boyut: " + transform.localScale);
        if (transform.localScale.x < 0.3f)
        {
            Die();
            Debug.Log("Die");
        }
        if (transform.localScale.x < 4.5)
        {
            this.transform.localScale += new Vector3(growRate, growRate, growRate) * Time.deltaTime;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {

            AudioManager.instance.playCollisionSound(colClip);
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(hitEffect, pos, rot);
            Debug.Log("Hit!");
            Noise(1, 5);
            this.transform.localScale -= new Vector3(12f, 12f, 12f) * Time.deltaTime;
        }
     else if (collision.transform.tag == "Rock")
        {
            LookModifier.instance.rockCount++;

            AudioManager.instance.playCollisionSound(colClip);
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(hitEffect, pos, rot);
            Debug.Log("Hit!");
            Noise(1, 5);
            this.transform.localScale -= new Vector3(8f, 8f, 8f) * Time.deltaTime;
        }
        else if (collision.transform.tag == "Bottle")
        {
            LookModifier.instance.bottleCount++;

            AudioManager.instance.playCollisionSound(colClip);
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(hitEffect, pos, rot);
            Debug.Log("Hit!");
            Noise(1, 5);
            this.transform.localScale -= new Vector3(4f, 4f, 4f) * Time.deltaTime;
        }
    }
    public void Die()
    {
        this.GetComponent<SphereCollider>().enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        respawnButton.SetActive(true);
        Instantiate(hitEffect, this.transform.position, this.transform.rotation);
        Noise(1, 5);
    }

    public void Respawn()
    {
        respawnButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Noise(float amplitudeGain, float frequencyGain)
    {
     
        noise.m_AmplitudeGain = amplitudeGain;
       

        noise.m_FrequencyGain = frequencyGain;

        Invoke("setNoiseNormal", 0.8f);
    }
    public void setNoiseNormal()
    {
        noise.m_AmplitudeGain = 0;


        noise.m_FrequencyGain = 0;
    }
}
