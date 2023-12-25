using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoleRecruit : PanelBaseCellRole,
             IPointerEnterHandler, IPointerExitHandler
{
    private Image ImgBk;
    public Transform Root;

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "PanelCellRoleRecruit";

        Root = transform.FindSonSonSon("Root");
        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
    }    

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {        
        Hot.PanelRoleGuildRecruitCost_.UpdateInfo(Hot.DataNowCellGameArchive.ListRoleRecruit[Index].Cost);
        Root.localPosition = new(40, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        Hot.PanelRoleGuildRecruitCost_.Clear();
        Root.localPosition = new(0, 0, 0);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ImgBk.raycastTarget = false;

        Root.localPosition = new(0, 0, 0);

        Hot.PanelBarRoleList_.EnableDetection();
        Hot.DragingPanelCellRoleRecruit = this;

        Hot.PaddingContentStep_.transform.SetParent(Hot.PanelRoleGuildRecruit_.Content, false);
    }    

    public override void OnEndDrag(PointerEventData eventData)
    {        
        ImgBk.raycastTarget = true;

        if (Hot.e_NowPointerLocation == E_NowPointerLocation.PanelRoleList)
        {
            Hot.MgrUI_.CreatePanel<PanelCellRole>
            (false, "/PanelCellRole",
            (panel) =>
            {
                Hot.DataNowCellGameArchive.ListRole.Add(Hot.DataNowCellGameArchive.ListRoleRecruit[Index].Role);
                panel.CreatePanelCellRoleCanDrag();
                panel.InitInfo(Hot.DataNowCellGameArchive.ListRole.Count - 1, E_RoleLocation.RoleList);
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepFor" + panel.PrefabsDynamicContentStepSuffix);
                obj.name = panel.Index.ToString();
                obj.transform.SetParent(Hot.PanelBarRoleList_.Content, false);
                obj.GetComponent<DynamicContentStep>().Init(panel.Index);
                panel.transform.SetParent(obj.GetComponent<DynamicContentStep>().DependentObjRoot, false);

                for (int i = Hot.PaddingIndex; i < Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep.Count; i++)
                {
                    Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                    Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
                }

                DestroyImmediate(Hot.PaddingContentStep_.gameObject);
                Hot.PaddingContentStep_ = null;
                DestroyImmediate(Father.ListDynamicContentStep[Index].gameObject);
                DestroyImmediate(gameObject);

                Hot.PanelBarRoleList_.SortContent();
                Hot.PanelRoleGuildRecruit_.SortContent();
                
                Hot.PanelRoleGuildRecruit_.DisableDetection();
            });
        }
        else
        {
            base.OnEndDrag(eventData);
        }

        Hot.PanelBarRoleList_.DisableDetection();

        Hot.DragingPanelCellRoleRecruit = null;
    }    

    public override void EndDrag()
    {
        transform.SetParent(Hot.PaddingContentStep_.DependentObjRoot, false);
        transform.localPosition = Vector3.zero;
        DestroyImmediate(Hot.PanelRoleGuildRecruit_.ListDynamicContentStep[Index].gameObject);
        Hot.PanelRoleGuildRecruit_.SortContent();
        Hot.PaddingContentStep_ = null;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":
                Hot.PanelRoleDetails_.Show(Index, e_RoleLocation);
                break;
        }
    }    
}
