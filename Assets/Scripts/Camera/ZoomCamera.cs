using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public Camera Camera;
    public float zoomSpeed;
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if(scrollInput != 0){
            Camera.transform.position += scrollInput * zoomSpeed * transform.forward;
        }
    }
}
