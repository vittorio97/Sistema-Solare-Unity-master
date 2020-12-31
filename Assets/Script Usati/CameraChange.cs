using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour
{

    public Camera firstPersonCamera;

    public Camera another1, another2;

   
   
    

   

    public void ShowCamera()
    {
        
        firstPersonCamera.enabled = true;
        another1.enabled = false;
        another2.enabled = false;

        

        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}