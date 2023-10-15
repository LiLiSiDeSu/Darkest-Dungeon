using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMgr : InstanceBase_Mono<InstanceMgr>
{
    public GameObject Gaming;

    protected override void Awake()
    {
        base.Awake();

        #region 在这里调用继承BaseAutoInstance_Mono脚本的GetInstance方法

        Gaming = new GameObject("Gaming");
        transform.parent = Gaming.transform;
        GameObject Other = new GameObject("Other");
        Other.transform.SetParent(transform);

        //数据一定要先加载出来
        MgrData.GetInstance().transform.SetParent(Other.transform);
        MgrAudioSource.GetInstance().transform.SetParent(Other.transform);
        //--
        PoolBuffer.GetInstance().transform.SetParent(transform);           
        PoolEsc.GetInstance().transform.SetParent(transform);
        //--
        PoolNowPanel.GetInstance().transform.SetParent(Other.transform);
        CenterEvent.GetInstance().transform.SetParent(Other.transform);
        MgrInput.GetInstance().transform.SetParent(Other.transform);
        MgrXml.GetInstance().transform.SetParent(Other.transform);
        MgrRes.GetInstance().transform.SetParent(Other.transform);
        MgrScene.GetInstance().transform.SetParent(Other.transform);        
        MgrUI.GetInstance().transform.SetParent(Other.transform);
        //StartPanel一定要在UIMgr后面加载 不然一开始显示的Panel不会被设置到Canvas下面
        StartUI.GetInstance().transform.SetParent(Other.transform);

        #endregion
    }
}
