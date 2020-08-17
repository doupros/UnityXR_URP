using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FacingToCamera : MonoBehaviour
{

   Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainVRCam").GetComponent<Camera>();
    }
    void Update()
    {
        //node text always facing camera
        transform.LookAt(mainCamera.transform);
    }
}
