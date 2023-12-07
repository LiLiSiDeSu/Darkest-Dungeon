
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{    
    #region LifeFunction

    protected virtual void Awake()
    {        
        GetChildrenControl<Button>();
        GetChildrenControl<Toggle>();
        GetChildrenControl<Slider>();
        GetChildrenControl<Dropdown>();
        GetChildrenControl<InputField>();
        GetChildrenControl<ScrollRect>();
    }

    #endregion

    protected void GetChildrenControl<T>() where T : UIBehaviour
    {
        T[] controls = GetComponentsInChildren<T>();
        
        for (int i = 0; i < controls.Length; i++)
        {
            //这里的name不声明在for外面是为了避免下面注册监听事件时调用的OnClick传入的参数不为最后一次给name赋值的值(闭包)
            string name = controls[i].gameObject.name;           
            //------------------------------------------------------------------------------------------------- !!!

            if (controls[i] is Button)
            {
                (controls[i] as Button).onClick.AddListener(() =>
                {
                    Button_OnClick(name);
                });
            }
            else if (controls[i] is Toggle)
            {
                (controls[i] as Toggle).onValueChanged.AddListener((EventParam) =>
                {
                    Toggle_OnValueChange(name, EventParam);
                });
            }
            else if(controls[i] is Slider)
            {
                (controls[i] as Slider).onValueChanged.AddListener((EventParam) =>
                {
                    Slider_OnValueChange(name, EventParam);
                });
            }
            else if (controls[i] is Dropdown)
            {
                (controls[i] as Dropdown).onValueChanged.AddListener((EventParam) =>
                {
                    Dropdown_OnValueChange(name, EventParam);
                });
            }
            else if (controls[i] is InputField)
            {
                (controls[i] as InputField).onValueChanged.AddListener((EventParam) =>
                {
                    InputField_OnValueChange(name, EventParam);
                });
                (controls[i] as InputField).onEndEdit.AddListener((EventParam) =>
                {
                    InputField_OnEndEdit(name, EventParam);
                });                
            }
        }
    }

    //----------------------------------------------------------------------------------------------
    //                       || 用于事件监听里面调用的函数 ||                 
    //                       || 只要在子类重写逻辑就行     ||           ☟
    //                       || 也可以自己添加            ||

    #region Button

    protected virtual void Button_OnClick(string controlname)
    {

    }

    #endregion

    #region Toggle

    protected virtual void Toggle_OnValueChange(string controlname, bool EventParam)
    {

    }

    #endregion

    #region Slider

    protected virtual void Slider_OnValueChange(string controlname, float EventParam)
    {

    }

    #endregion

    #region Dropdown

    protected virtual void Dropdown_OnValueChange(string controlname, int EventParam)
    {

    }

    #endregion

    #region InputField

    protected virtual void InputField_OnValueChange(string controlname, string EventParam)
    {

    }

    protected virtual void InputField_OnEndEdit(string controlname, string EventParam)
    {

    }

    #endregion
}