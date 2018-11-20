using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class camera_controller : MonoBehaviour
{
    public GameObject playerobject; 

    private Vector3 offval;    

    // Use this for initialization
    void Start()
    {
        offval = transform.position - playerobject.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = playerobject.transform.position + offval;
    }
}