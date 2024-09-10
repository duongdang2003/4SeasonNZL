using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraPosMenuButton : Menu, IPointerClickHandler
{
    private void Start() {
        UIController.Instance.CloseMenu(1);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isOpen){
            UIController.Instance.OpenMenu(1);
            GetComponent<Image>().color = UIConstants.SELECTED_COLOR;
        }
        else{
            UIController.Instance.CloseMenu(1);
            GetComponent<Image>().color = UIConstants.DEFAULT_COLOR;
        }
    }
    public override void Open()
    {
        base.Open();
        UIConstants.CameraPosMenu.SetActive(true);
    }
    public override void Close()
    {
        base.Close();
        UIConstants.CameraPosMenu.SetActive(false);
    }
}
