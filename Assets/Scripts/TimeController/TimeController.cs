using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private ScrollRect _timeScroller;
    private Text _timeDisplay;
    private Text _timeScrollDisplay;
    private string _timeText;
    private string _minuteText;
    private void Start() {
        _timeScroller = UIConstants.TimeScroller.GetComponent<ScrollRect>();
        _timeScroller.verticalNormalizedPosition = 0.583333333f;
        LighController.Instance.SetLight(1 - _timeScroller.verticalNormalizedPosition);
        _timeDisplay = UIConstants.TimeDisplay.GetComponent<Text>();
        _timeScrollDisplay=  UIConstants.TimeScrollDisplay.GetComponentInChildren<Text>();
    }
    public void UpdateTime(){
        // if(_timeScroller.verticalNormalizedPosition >= 0 && _timeScroller.verticalNormalizedPosition <= 1){}
        string period = "AM";
        float time = 1440 * (1 - _timeScroller.verticalNormalizedPosition) / 60;
        if (time < 0) time = 0;
        else if (time >= 12){
            time -= 12;
            period = "PM";
            if (time > 12) time = 12;
        }
        double minute = Convert.ToInt32(Math.Floor(time));
        minute = Math.Round((time - minute)*60);
        time = Convert.ToInt32(Math.Floor(time));

        if (time < 10)
            _timeText = "0" + time;
        else
            _timeText = time.ToString();
        if (minute < 10)
            _minuteText = "0" + minute;
        else
            _minuteText = minute.ToString();
        string result = _timeText + ":" + _minuteText + " " + period;
        
        _timeDisplay.text = result;
        _timeScrollDisplay.text = result;
        LighController.Instance.SetLight(1 - _timeScroller.verticalNormalizedPosition);
    }
    
}
