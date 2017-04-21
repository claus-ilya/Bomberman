using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggerOnPlayerExit : MonoBehaviour {

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
