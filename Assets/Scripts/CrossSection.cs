using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossSection : Menu
{
    public Material crossSection_Wall;
    public Material crossSection_Glass;

    public GameObject crossSectionMenu;
    public GameObject crossSectionButton;
    public Slider crossSectionSlider;
    private Vector3 _direction;
    private bool _isReverse = false;
    
    public override void Open()
    {
        base.Open();
        crossSectionMenu.SetActive(true);
        crossSectionButton.GetComponent<Image>().color = UIConstants.SELECTED_COLOR;
    }
    public override void Close(){
        base.Close();
        crossSectionMenu.SetActive(false);
        crossSectionButton.GetComponent<Image>().color = UIConstants.DEFAULT_COLOR;
    }
    public void ButtonClick(){
        if (!isOpen) Open();
        else Close();
    }
    public void ChangeAxisToX(){
        _direction = new Vector3(1, 0, 0);
        ChangeAxis();
    }
    public void ChangeAxisToY(){
        _direction = new Vector3(0, 1, 0);
        ChangeAxis();
    }
    public void ChangeAxisToZ(){
        _direction = new Vector3(0, 0, 1);
        ChangeAxis();
    }
    public void ChangeAxis(){
        crossSection_Wall.SetVector("_ClippingDirection", _direction);
        crossSection_Glass.SetVector("_ClippingDirection", _direction);
    }
    public void ReverseDirection(){
        int index;
        if (_isReverse)
            index = 0;
        else
            index = 1;
        _isReverse = !_isReverse;
        crossSection_Wall.SetInt("_Inverse", index);
        crossSection_Glass.SetInt("_Inverse", index);
    }
    public void CrossSectionValueChange(){
        float value = crossSectionSlider.value;
        crossSection_Wall.SetFloat("_Flow", value);
        crossSection_Glass.SetFloat("_Flow", value);
    }
}
