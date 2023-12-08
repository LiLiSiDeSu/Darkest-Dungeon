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

    public PanelCellExpeditionRolePrepareRoot ExpeditionRolePrepareRoot;
    public RectTransform RectRolePortraitCanDrag;
    public PanelCellRole Role;

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
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRole[Role.Index]);
                    panel.BtnDismiss.SetActive(true);
                });
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
            Debug.Log("回到RoleList");
            ExpeditionRolePrepareRoot = null;
            RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
            transform.SetParent(Role.RootPortrait, false);
            transform.localPosition = Vector3.zero;
            Hot.DataNowCellGameArchive.ListCellRole[Role.Index].IndexExpedition = -1;
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
                    Hot.DataNowCellGameArchive.ListCellRole[beReplace.Role.Index].IndexExpedition = beReplace.ExpeditionRolePrepareRoot.Index;
                }
                //从RootContent拖到RootContent里空的Root下
                else
                {
                    ;
                }

                transform.SetParent(Hot.NowEnterExpeditionRolePrepareRoot.transform, false);
                transform.localPosition = Vector3.zero;
                ExpeditionRolePrepareRoot = Hot.NowEnterExpeditionRolePrepareRoot;
                Hot.DataNowCellGameArchive.ListCellRole[Role.Index].IndexExpedition = ExpeditionRolePrepareRoot.Index;
            }
            else
            {
                //从RoleList和RootContent里的替换
                if (Hot.NowEnterExpeditionRolePrepareRoot.transform.childCount > 0)
                {
                    PanelCellRolePortraitCanDrag beReplace = Hot.NowEnterExpeditionRolePrepareRoot.transform.GetComponentInChildren<PanelCellRolePortraitCanDrag>();
                    beReplace.ExpeditionRolePrepareRoot = null;
                    beReplace.RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                    beReplace.transform.SetParent(beReplace.Role.RootPortrait, false);
                    beReplace.transform.localPosition = Vector3.zero;
                    beReplace.Role.ChangeRoleStatus(-1);
                    Hot.DataNowCellGameArchive.ListCellRole[beReplace.Role.Index].IndexExpedition = -1;
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
                Hot.DataNowCellGameArchive.ListCellRole[Role.Index].IndexExpedition = ExpeditionRolePrepareRoot.Index;
            }
        }

        Role.ChangeRoleStatus(Hot.DataNowCellGameArchive.ListCellRole[Role.Index].IndexExpedition);
        ImgRolePortraitCanDrag.raycastTarget = true;
        Hot.DragingRolePortraitCanDrag = null;
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
