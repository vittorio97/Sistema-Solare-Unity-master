using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float accelerazioneGravità = 9.807f;

    public Rigidbody[] corpo;

    

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int count = corpo.Length;

        for (int i = 0; i < count; i++)
        {
            corpo[i].AddForce(accelerazioneGravità * transform.position, ForceMode.Acceleration);
        }
    }
}
