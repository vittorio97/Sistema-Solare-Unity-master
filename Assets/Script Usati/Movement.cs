using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidB;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("c")) {
            rigidB.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rigidB.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey("d"))
        {
            rigidB.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey("a"))
        {
            rigidB.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey("u"))
        {
            rigidB.AddForce(Vector3.up * speed);
        }
        if (Input.GetKey("d"))
        {
            rigidB.AddForce(Vector3.down * speed);
        }
    }
    }

