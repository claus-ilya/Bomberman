using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;

    void Start () {
        Invoke("Explode", 3f);
    }

    void Explode()
    {
        explosionPrefab.transform.localScale = new Vector3(SetGameObject.Width, SetGameObject.Width, SetGameObject.Width);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        transform.FindChild("Collider").gameObject.SetActive(false);
        Destroy(gameObject, .3f);
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), direction, out hit, i* explosionPrefab.transform.localScale.x, levelMask);

            if (!hit.collider || hit.collider.CompareTag("SoftBlock"))
            {
                Debug.DrawLine(direction, hit.point, Color.green);
                Instantiate(explosionPrefab, transform.position + (i * explosionPrefab.transform.localScale.x * direction),
                explosionPrefab.transform.rotation);
                if (hit.collider && hit.collider.CompareTag("SoftBlock"))
                    break;
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds(.05f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!exploded && other.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }

}
