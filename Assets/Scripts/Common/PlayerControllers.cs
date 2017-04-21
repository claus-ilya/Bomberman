using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public AudioClip PlayPutBombSound;
    public bool canMove = true;    
    private bool dead = false;
    public float moveSpeed = 6.0f;

    public GameObject bombPrefab;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!canMove)
            return;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.localEulerAngles = new Vector3(0, 90, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.localEulerAngles = new Vector3(0, -90, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.localEulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.localEulerAngles = new Vector3(0, -180, 0);

        CharacterController _characterController = GetComponent<CharacterController>();
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement *= Time.deltaTime;

        float speedForAnimation = 0;
        if (Mathf.Abs(Input.GetAxis("Horizontal") * moveSpeed) > Mathf.Abs(Input.GetAxis("Vertical") * moveSpeed))
            speedForAnimation = Mathf.Abs(Input.GetAxis("Horizontal") * moveSpeed);
        else speedForAnimation = Mathf.Abs(Input.GetAxis("Vertical") * moveSpeed);

        animator.SetFloat("Speed", speedForAnimation);
        _characterController.Move(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Sit");
            DropBomp();
        }
    }

    private void DropBomp()
    {
        if (bombPrefab)
        {
            bombPrefab.transform.localScale = transform.localScale;
            Instantiate(bombPrefab, new Vector3(transform.position.x, SetGameObject.Width / 2, transform.position.z), transform.rotation);
        }      
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || (!dead && other.CompareTag("Explosion")))
        {
            canMove = false;
            animator.SetTrigger("Hit");
            dead = true;
            Destroy(gameObject, 3.5f);
        }        
    }
}

