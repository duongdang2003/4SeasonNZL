using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TimeDisplay : MonoBehaviour, IPointerClickHandler
{
    private void Start() {
        UIConstants.TimeScroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.583333333f;
        UIConstants.TimeScroller.SetActive(false);
        UIConstants.TimeScrollDisplay.SetActive(false);
    }
    private bool _displayScroller = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_displayScroller){
            UIConstants.TimeScroller.SetActive(true);
            UIConstants.TimeScrollDisplay.SetActive(true);
            _displayScroller = true;
        } else {
            UIConstants.TimeScroller.SetActive(false);
            UIConstants.TimeScrollDisplay.SetActive(false);
            _displayScroller = false;
        }
    }
    
}
