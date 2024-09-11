using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TPSMode : MonoBehaviour, IPointerClickHandler
{
    public GameObject robot;
    public Camera fpsCamera;
    public Camera tpsCamera;
    public RobotMovement robotMovement;
    public Image button;

    public void OnPointerClick(PointerEventData eventData)
    {
        robot.SetActive(true);
        fpsCamera.gameObject.SetActive(false);
        tpsCamera.gameObject.SetActive(true);
        robotMovement.ChangeMode(RobotMovement.Mode.TPS);
        button.sprite = GetComponent<Image>().sprite;
    }
}
