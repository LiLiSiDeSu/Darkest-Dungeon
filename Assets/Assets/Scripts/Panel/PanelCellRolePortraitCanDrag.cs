using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRolePortraitCanDrag : PanelBaseDrag,
             IPointerEnterHandler, IPointerExitHandler
{
    public Image ImgRolePortraitCanDrag;

    public RectTransform RectRolePortraitCanDrag;
    public PanelCellRole Role = new();
    public PanelCellExpeditionRolePrepareRoot ExpeditionRolePrepareRoot = new();

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortraitCanDrag = transform.FindSonSonSon("ImgRolePortraitCanDrag").GetComponent<Image>();

        RectRolePortraitCanDrag = ImgRolePortraitCanDrag.GetComponent<RectTransform>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortraitCanDrag":
                Hot.PanelRoleDetails_.Show(Role.Index, Role.e_RoleLocation);
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Hot.e_NowPointerLocation == E_NowPointerLocation.PanelBarExpedition && Hot.DragingRolePortraitCanDrag != null)
        {
            Hot.ReplaceRolePortraitCanDrag = this;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.ReplaceRolePortraitCanDrag = null;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        RectRolePortraitCanDrag.sizeDelta = new Vector2(100, 100);
        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);

        ImgRolePortraitCanDrag.raycastTarget = false;
        Hot.DragingRolePortraitCanDrag = this;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        //回到RoleList
        if (Hot.NowEnterExpeditionRolePrepareRoot == null)
        {
            ExpeditionRolePrepareRoot = null;
            RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
            transform.SetParent(Role.RootPortrait, false);
            transform.localPosition = Vector3.zero;
            Hot.DataNowCellGameArchive.ListRole[Role.Index].IndexExpeditionRoot = -1;
        }
        else
        {
            if (ExpeditionRolePrepareRoot != null)
            {
                //从RootContent和RootContent里的替换
                if (Hot.NowEnterExpeditionRolePrepareRoot.transform.childCount > 0)
                {
                    PanelCellRolePortraitCanDrag beReplace = Hot.NowEnterExpeditionRolePrepareRoot.transform.GetComponentInChildren<PanelCellRolePortraitCanDrag>();
                    beReplace.transform.SetParent(Hot.DragingRolePortraitCanDrag.ExpeditionRolePrepareRoot.transform, false);
                    beReplace.ExpeditionRolePrepareRoot = Hot.DragingRolePortraitCanDrag.ExpeditionRolePrepareRoot;
                    beReplace.transform.localPosition = Vector3.zero;
                    Hot.DataNowCellGameArchive.ListRole[beReplace.Role.Index].IndexExpeditionRoot = beReplace.ExpeditionRolePrepareRoot.Index;
                }
                //从RootContent拖到RootContent里空的Root下
                else
                {
                    ;
                }

                transform.SetParent(Hot.NowEnterExpeditionRolePrepareRoot.transform, false);
                transform.localPosition = Vector3.zero;
                ExpeditionRolePrepareRoot = Hot.NowEnterExpeditionRolePrepareRoot;
                Hot.DataNowCellGameArchive.ListRole[Role.Index].IndexExpeditionRoot = ExpeditionRolePrepareRoot.Index;
            }
            else
            {
                //从RoleList和RootContent里的替换
                if (Hot.NowEnterExpeditionRolePrepareRoot.transform.childCount > 0)
                {
                    PanelCellRolePortraitCanDrag beReplace = Hot.NowEnterExpeditionRolePrepareRoot.transform.GetComponentInChildren<PanelCellRolePortraitCanDrag>();
                    beReplace.ExpeditionRolePrepareRoot = null;
                    beReplace.RectRolePortraitCanDrag.sizeDelta = new(80, 80);
                    beReplace.transform.SetParent(beReplace.Role.RootPortrait, false);
                    beReplace.transform.localPosition = Vector3.zero;
                    Hot.DataNowCellGameArchive.ListRole[beReplace.Role.Index].IndexExpeditionRoot = -1;
                    beReplace.Role.ChangeRoleStatus();
                }
                //从RoleList拖到空的ExpeditionRolePrepareRoot
                else
                {
                    ;
                }

                RectRolePortraitCanDrag.sizeDelta = new Vector2(100, 100);
                transform.SetParent(Hot.NowEnterExpeditionRolePrepareRoot.transform, false);
                transform.localPosition = Vector3.zero;
                ExpeditionRolePrepareRoot = Hot.NowEnterExpeditionRolePrepareRoot;
                Hot.DataNowCellGameArchive.ListRole[Role.Index].IndexExpeditionRoot = ExpeditionRolePrepareRoot.Index;
            }
        }

        Role.ChangeRoleStatus();
        ImgRolePortraitCanDrag.raycastTarget = true;
        Hot.DragingRolePortraitCanDrag = null;

        Hot.Data_.Save();
    }

    #endregion

    public void Init(PanelCellRole p_Role, Transform p_father, Vector2 p_size)
    {
        Role = p_Role;
        transform.SetParent(p_father, false);
        transform.localPosition = Vector2.zero;
        ImgRolePortraitCanDrag.sprite = Role.ImgRolePortrait.sprite;
        RectRolePortraitCanDrag.sizeDelta = p_size;
    }
}
