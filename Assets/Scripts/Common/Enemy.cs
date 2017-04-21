using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public float speed = 3.0f;
    public float obstacleRange = 0.2f;
    bool alive;
    bool canStartCoroutine;

    private void Start()
    {
        alive = true;
        canStartCoroutine = true;
    }

    void FixedUpdate () {
        if (alive)
        {
            Ray ray = new Ray(transform.position, -transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, this.transform.localScale.x * 0.4f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hit.distance < obstacleRange && !hitObject.tag.Equals("Player") && !hitObject.tag.Equals("Enemy"))
                    transform.Rotate(0, GetRandomAngle(), 0);
                else
                {
                    transform.Translate(0, 0, -speed * Time.deltaTime);
                    if (canStartCoroutine)
                        StartCoroutine(Turn());
                }
            }
        }
        
	}

    public IEnumerator Turn()
    {
        transform.Rotate(0, GetRandomAngle(), 0);
        canStartCoroutine = false;
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        canStartCoroutine = true;
    }

    public int GetRandomAngle()
    {
        int numberOfAngle = Random.Range(0, 2);
        switch (numberOfAngle)
        {
            case 0:
                return 90;
            case 1:
                return 180;
            case 2:
                return 270;
        }
        return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            alive = false;
            GetComponent<Animator>().SetTrigger("Death");
            Destroy(gameObject, 2.5f);
        }
    }
}
