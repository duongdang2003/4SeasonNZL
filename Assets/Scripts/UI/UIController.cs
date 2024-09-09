using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Awake() {
        UIConstants.TimeDisplay = GameObject.FindWithTag("TimeDisplay");
        UIConstants.TimeScroller = GameObject.FindWithTag("TimeScroller");
        UIConstants.TimeScrollDisplay = GameObject.FindWithTag("TimeScrollDisplay");
    }
}
