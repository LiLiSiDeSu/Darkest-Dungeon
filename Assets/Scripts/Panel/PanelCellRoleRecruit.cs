using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoleRecruit : PanelBaseCell,
             IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 DragOffSet;
    private Image ImgBk;
    private Image ImgRolePortrait;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {        
        Hot.PanelRoleGuildRecruitCost_.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRoleRecruit[Index].Cost);
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        Hot.PanelRoleGuildRecruitCost_.Clear();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {        
        if (Hot.PanelRoleGuildRecruitCost_.CanBuy)
        {
            DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;

            ImgBk.raycastTarget = false;
            ImgRolePortrait.raycastTarget = false;

            Hot.DragingPanelCellRoleRecruit = this;

            Hot.PaddingContentStep_ =
                Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepForPanelCellRole").GetComponent<DynamicContentStepForPanelCellRole>();
            Hot.PaddingContentStep_.Init(-1);
            Hot.PanelRoleList_.EnableDetection();

            transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
        }
        else
        {
            Hot.DragingPanelCellRoleRecruit = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Hot.DragingPanelCellRoleRecruit != null)
        {
            transform.position = eventData.position + DragOffSet;
        }
    }    

    public void OnEndDrag(PointerEventData eventData)
    {
        ImgBk.raycastTarget = true;
        ImgRolePortrait.raycastTarget = true;

        Hot.PanelRoleList_.DisableDetection();

        if (Hot.DragingPanelCellRoleRecruit != null)
        {
            if (Hot.e_NowPointerLocation == E_NowPointerLocation.PanelRoleList)
            {
                Hot.PanelRoleList_.AddRole(Hot.DataNowCellGameArchive.ListCellRoleRecruit[Index].Role, Hot.PaddingContentStep_);

                Hot.PanelRoleGuildRecruit_.RemoveRole(Hot.DragingPanelCellRoleRecruit.gameObject);                                
            }
            else
            {
                DestroyImmediate(Hot.PaddingContentStep_.gameObject);
                Hot.PaddingContentStep_ = null;

                transform.SetParent(Hot.PanelRoleGuildRecruit_.RecruitContent, false);                
            }
        }        

        Hot.DragingPanelCellRoleRecruit = null;

        Hot.PanelRoleGuildRecruit_.SortContent();
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":                
                Hot.PanelRoleDetails_.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRoleRecruit[Index].Role);                
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails", 
                (panel) =>
                {
                    panel.BtnDismiss.SetActive(false);
                });                
                break;
        }
    }

    public void Init()
    {
        transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().sprite =
            Hot.MgrRes_.Load<Sprite>
            ("Art/Portrait" + Hot.DataNowCellGameArchive.ListCellRoleRecruit[Index].Role.e_RoleName);
    }
}
