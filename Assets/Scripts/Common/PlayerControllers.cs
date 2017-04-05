using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public GameObject plane;
    public float speed = 6.0f;
    public float turnSpeed = 50f;


    private Vector3 moveDirection = Vector3.zero;



    void Update()
    {
        //// Получаем компонент CharacterController, который прикреплён к текущему GameObject
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.rotation = new Quaternion(0, 90, 0, -90);
        //    //transform.Rotate(Vector3.up, 90);

        //    Vector3 target = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        //    if (!Physics.Linecast(transform.position, target))
        //        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.rotation = new Quaternion(0, 90, 0, 90);
        //    //transform.Rotate(Vector3.up, 90);
        //    Vector3 target = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        //    if (!Physics.Linecast(transform.position, target))
        //        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.rotation = new Quaternion(0, 90, 0, 0);
        //    //transform.Rotate(Vector3.up, 90);
        //    Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        //    if (!Physics.Linecast(transform.position, target))
        //        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.rotation = new Quaternion(0, 0, 0, -180);
        //    //transform.Rotate(Vector3.up, 90);
        //    Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        //    if (!Physics.Linecast(transform.position, target))
        //        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);
        //}

        //Physics.Linecast

        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.rotation = new Quaternion(0, 90, 0, -90);
        //if (Input.GetKey(KeyCode.RightArrow))
        //    transform.Rotate(Vector3.up);
        //CharacterController controller = GetComponent<CharacterController>();
        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Debug.Log("Input.GetAxis = " + moveDirection);
        //// Преобразование координат текущего объекта из локальных в world space
        //moveDirection = transform.TransformDirection(moveDirection);

        //moveDirection *= speed;


        //controller.Move(moveDirection * Time.deltaTime);


        //from book
        
        CharacterController _characterController = GetComponent<CharacterController>();
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        
        //movement = transform.TransformDirection(movement);
        _characterController.Move(movement);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.localEulerAngles = new Vector3(0, 90, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.localEulerAngles = new Vector3(0, -90, 0);
        if(Input.GetKey(KeyCode.UpArrow))
            transform.localEulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.localEulerAngles = new Vector3(0, -180, 0);
    }
}

