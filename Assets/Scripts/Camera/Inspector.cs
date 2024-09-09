using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    public float rotateSpeed;   
    void Update()
    {
        if(Input.GetMouseButton(0) && !TimeDisplay.Instance.IsScrollerOpen()){
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");

            transform.Rotate(new Vector3(-vertical * rotateSpeed * Time.deltaTime, horizontal * rotateSpeed * Time.deltaTime, 0)); 
            Vector3 currentEulerAngles = transform.eulerAngles;
            currentEulerAngles.z = 0;
            transform.eulerAngles = currentEulerAngles;
        }
        
    }
}
