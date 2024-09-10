using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public float panSpeed;
    public Camera mainCamera;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(1) && !TimeDisplay.Instance.IsScrollerOpen()){
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");

            // Vector3 newPos = mainCamera.transform.position + panSpeed * Time.deltaTime * new Vector3(horizontal, -vertical , 0);
            Vector3 newHorizontalPos = panSpeed * Time.deltaTime * -vertical * mainCamera.transform.up;
            Vector3 newVerticalPos = panSpeed * Time.deltaTime * -horizontal * mainCamera.transform.right;
            Vector3 newPos = newHorizontalPos + newVerticalPos;
            mainCamera.transform.position += newPos;
        }
    }
}
