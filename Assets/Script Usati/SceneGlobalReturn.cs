using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGlobalReturn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnScene()
    {
        Application.LoadLevel("Main_Scene");
    }
}
