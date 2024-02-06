using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.transform.root.gameObject, 14f);
        }
    }
}
