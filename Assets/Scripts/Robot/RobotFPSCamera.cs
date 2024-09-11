using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFPSCamera : MonoBehaviour
{
    public float speed;
    private void Update() {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        transform.Rotate(-vertical * Time.deltaTime * speed, horizontal * speed * Time.deltaTime, 0);
        Vector3 currentRotation = transform.rotation.eulerAngles;

        if (currentRotation.x > 180) currentRotation.x -= 360;
        // if (currentRotation.y > 180) currentRotation.y -= 360;

        currentRotation.x = Mathf.Clamp(currentRotation.x, -45f, 60f);
        // currentRotation.y = Mathf.Clamp(currentRotation.y, -90f, 90f); 
        currentRotation.z = 0;

        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
