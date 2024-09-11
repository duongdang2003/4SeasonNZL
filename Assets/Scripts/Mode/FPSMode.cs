using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FPSMode : MonoBehaviour, IPointerClickHandler

{
    public GameObject robot;
    public Camera tpsCamera;
    public Camera fpsCamera;
    public RobotMovement robotMovement;
    public Image button;

    public void OnPointerClick(PointerEventData eventData)
    {
        robot.SetActive(true);
        tpsCamera.gameObject.SetActive(false);
        fpsCamera.gameObject.SetActive(true);
        robotMovement.ChangeMode(RobotMovement.Mode.FPS);
        button.sprite = GetComponent<Image>().sprite;
    }
}
