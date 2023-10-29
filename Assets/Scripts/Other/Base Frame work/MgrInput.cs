using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgrInput : InstanceBaseAuto_Mono<MgrInput>
{        
    //每个都要在下面添加检测哦
    public KeyCode W = KeyCode.N;
    public KeyCode A = KeyCode.A;
    public KeyCode S = KeyCode.S;
    public KeyCode D = KeyCode.D;
    public KeyCode UpArrow = KeyCode.UpArrow;
    public KeyCode DownArrow = KeyCode.DownArrow;
    public KeyCode Esc = KeyCode.Escape;
    public KeyCode Setting = KeyCode.I;    
    public KeyCode AddNowTranslateRate = KeyCode.LeftControl;
    public KeyCode PanelTownStore = KeyCode.Tab;
    public KeyCode PanelResTable = KeyCode.CapsLock;
    public KeyCode PanelRole = KeyCode.R;    
    public KeyCode PanelBar = KeyCode.F;

    private void Update()
    {        
        //没有开启输入检测 就不去检测 直接return
        if (!IsOpen)
            return;

        //在这里添加需要检测的键
        CheckKeyCode(W);
        CheckKeyCode(S);
        CheckKeyCode(A);
        CheckKeyCode(D);
        CheckKeyCode(UpArrow);
        CheckKeyCode(DownArrow);
        CheckKeyCode(Esc);
        CheckKeyCode(Setting);
        CheckKeyCode(AddNowTranslateRate);
        CheckKeyCode(PanelTownStore);
        CheckKeyCode(PanelResTable);
        CheckKeyCode(PanelRole);
        CheckKeyCode(PanelBar);
    }

    /// <summary>
    /// 是否输入检测
    /// </summary>
    private bool IsOpen = true;

    /// <summary>
    /// 是否开启或关闭输入检测
    /// </summary>
    /// <param name="isOpen">---</param>
    public void OpenOrCloseCheck(bool isOpen)
    {
        IsOpen = isOpen;
    }    

    /// <summary>
    /// 用来检测按键抬起按下 分发事件
    /// </summary>
    /// <param name="key"></param>
    private void CheckKeyCode(KeyCode key)
    {
        //可以添加其他的输入事件

        //事件中心模块 统一触发按下抬起事件
        if (Input.GetKeyUp(key))
            CenterEvent.GetInstance().EventTrigger<KeyCode>("CertainKeyUp", key);
        //事件中心模块 统一触发按下抬起事件
        if (Input.GetKeyDown(key))
            CenterEvent.GetInstance().EventTrigger<KeyCode>("CertainKeyDown", key);        
    }
}
