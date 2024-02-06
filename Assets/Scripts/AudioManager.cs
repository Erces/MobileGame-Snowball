using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Error");
            return;
        }
        instance = this;
    }

    public void playCollisionSound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
