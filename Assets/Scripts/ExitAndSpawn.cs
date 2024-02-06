using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAndSpawn : MonoBehaviour
{
    public GameObject Grounds;
    private GameObject spawned;
    public Transform next;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {

            int random = Random.Range(0, 3);
            spawned = (GameObject)Instantiate(Grounds, next.position, next.rotation);
            for (int i = 7; i < 10; i++)
            {
                spawned.transform.GetChild(i).gameObject.SetActive(false);

            }

            spawned.transform.GetChild(7 + random).gameObject.active = true;
            
        }
    }
}
