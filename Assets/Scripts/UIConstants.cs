using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public static class UIConstants
{
    // menu
    public static GameObject[] menus = new GameObject[2];
    public enum MenuType {
        TimeSetting,
        CameraPos
    }

    // color
    public static Color DEFAULT_COLOR;
    public static Color SELECTED_COLOR;

    // time
    public static GameObject TimeDisplay;
    public static GameObject TimeScroller;
    public static GameObject TimeScrollDisplay;

    // camera pos saver
    public static GameObject CameraPosButton;
    public static GameObject CameraPosMenu;
}
