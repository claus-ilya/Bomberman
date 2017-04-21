using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoftBlock : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
            Destroy(gameObject);
    }
}
