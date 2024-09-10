using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TimeDisplay : Menu,IPointerClickHandler
{
    public static TimeDisplay Instance;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isOpen){
            UIController.Instance.OpenMenu(0);
        } else {
            UIController.Instance.CloseMenu(0);
        }
    }
    public override void Open()
    {
        base.Open();
        UIConstants.TimeScroller.SetActive(true);
        UIConstants.TimeScrollDisplay.SetActive(true);

    }
    public override void Close()
    {
        base.Close();
        UIConstants.TimeScroller.SetActive(false);
        UIConstants.TimeScrollDisplay.SetActive(false);
    }
    public bool IsScrollerOpen() => isOpen;
    
}
