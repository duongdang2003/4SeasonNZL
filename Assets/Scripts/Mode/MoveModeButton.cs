using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveModeButton : Menu, IPointerClickHandler
{
    public GameObject MoveModeMenu;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isOpen){
            Open();
        } else {
            Close();
        }
    }

    public override void Close()
    {
        base.Close();
        MoveModeMenu.SetActive(false);
    }
    public override void Open()
    {
        base.Open();
        MoveModeMenu.SetActive(true);
    }
}
