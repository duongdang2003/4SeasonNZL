using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    private void Awake() {
        UIConstants.TimeDisplay = GameObject.FindWithTag("TimeDisplay");
        UIConstants.TimeScroller = GameObject.FindWithTag("TimeScroller");
        UIConstants.TimeScrollDisplay = GameObject.FindWithTag("TimeScrollDisplay");

        UIConstants.CameraPosMenu = GameObject.FindWithTag("CameraPositionMenu");
        UIConstants.menus[0] = GameObject.FindWithTag("TimeDisplay");
        UIConstants.menus[1] = GameObject.FindWithTag("CameraPosButton");

        ColorUtility.TryParseHtmlString("#2E2E2E", out UIConstants.DEFAULT_COLOR);
        ColorUtility.TryParseHtmlString("#007CFF", out UIConstants.SELECTED_COLOR);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }
    public void OpenMenu(int index){
        // 0 : time setting menu
        // 1 : camera menu position menu
        for(int i=0; i < UIConstants.menus.Length; i++){
            if (i == index) UIConstants.menus[i].GetComponent<Menu>().Open();
            else UIConstants.menus[i].GetComponent<Menu>().Close();
        }
    }
    public void CloseMenu(int index){
        UIConstants.menus[index].GetComponent<Menu>().Close();
    }

}
