﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera mainCamera;
    public Transform gyro;

    Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float sensitivity;

    float hor;
    float ver;



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = -1;

        rb = GetComponent<Rigidbody>();



        mainCamera.transform.position = new Vector3(100f, 0f, -1000f) + Vector3.up * 85f;
        mainCamera.transform.rotation = Quaternion.Euler(25f, 45f, 0f);
    }

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce((transform.forward + transform.up*25f/45f).normalized * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce((transform.forward + transform.up * 25f / 45f).normalized * -1f * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -1f * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * moveSpeed/2f, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.up * -1f * moveSpeed / 2f, ForceMode.Acceleration);
        }

        float rot = Input.GetAxis("Mouse X");
        if(Mathf.Abs(rot) > 0f)
        {
            mainCamera.transform.Rotate(Vector3.up * rot);
        }

        Vector3 eulers = transform.rotation.eulerAngles;
        Vector3 pos = mainCamera.transform.position;
        mainCamera.transform.rotation = Quaternion.Euler(30f, eulers.y, 0f);
        mainCamera.transform.position = new Vector3(pos.x, pos.y, pos.z);



        /*
        hor = Mathf.Lerp(hor, Input.GetAxis("Mouse X"), 6f*sensitivity);
        ver = Mathf.Lerp(ver, Input.GetAxis("Mouse Y"), 6f*sensitivity);

        gyro.transform.Rotate(new Vector3(ver*-1f, hor, 0f));
        transform.rotation = Quaternion.Slerp(transform.rotation, gyro.rotation, .5f);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -1f * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -1f * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up* moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.up * -1f * moveSpeed, ForceMode.Acceleration);
        }
        */

        if (rb.velocity.magnitude > 20f)
        {
            rb.velocity = rb.velocity.normalized * 20f;
        }
        

    }
}
