using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraMode : MonoBehaviour, IPointerClickHandler
{
    public Image button;
    public GameObject robot;
    public void OnPointerClick(PointerEventData eventData)
    {
        robot.SetActive(false);
        button.sprite = GetComponent<Image>().sprite;
    }
}
