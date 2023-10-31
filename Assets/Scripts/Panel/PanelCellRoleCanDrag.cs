using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoleCanDrag : PanelBase, 
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image ImgRolePortraitCanDrag;

    public RectTransform RectRolePortraitCanDrag;
    public Transform RootExpeditionRole;    
    private Vector2 DragOffSet;

    public PanelCellRole PanelCellRole_;

    protected override void Awake()
    {
        base.Awake();

        PanelCellRole_ = transform.GetComponentInParent<PanelCellRole>();
        ImgRolePortraitCanDrag = transform.FindSonSonSon("ImgRolePortraitCanDrag").GetComponent<Image>();
        RectRolePortraitCanDrag = ImgRolePortraitCanDrag.GetComponent<RectTransform>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortraitCanDrag":                
                Hot.PanelRoleDetails_.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index]);
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.NowRole = PanelCellRole_;
                    panel.BtnDismiss.SetActive(true);
                });
                break;
        }
    }    

    #region EventSystem接口实现

    public void OnBeginDrag(PointerEventData eventData)
    {
        ImgRolePortraitCanDrag.raycastTarget = false;
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;        

        RectRolePortraitCanDrag.sizeDelta = new Vector2(100, 100);
        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);                     
        Hot.DragingRolePortrait = gameObject;        
    }

    public void OnDrag(PointerEventData eventData)
    {        
        transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ImgRolePortraitCanDrag.raycastTarget = true;
        
        if (Hot.e_NowPointerLocation != E_NowPointerLocation.TownExpedition)
        {
            Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].e_SpriteNameRoleStatus = E_SpriteNameRoleStatus.RoleStatusNone;
            Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition = -1;
            PanelCellRole_.ChangeRoleStatus(E_SpriteNameRoleStatus.RoleStatusNone);
            transform.SetParent(PanelCellRole_.RootPortrait, false);
            RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
            RootExpeditionRole = null;
        }        
        else
        {
            if (Hot.NowRootExpeditionRole != null)
            {
                if (Hot.NowRootExpeditionRole.transform.childCount != 0)
                {
                    Hot.ReplaceRolePortrait = Hot.NowRootExpeditionRole.GetComponentInChildren<PanelCellRoleCanDrag>().gameObject;

                    if (RootExpeditionRole != null)
                    {
                        Hot.ReplaceRolePortrait.transform.SetParent(RootExpeditionRole);
                        Hot.ReplaceRolePortrait.transform.localPosition = Vector3.zero;
                        Hot.DataNowCellGameArchive.ListCellRole
                            [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().PanelCellRole_.Index].IndexExpedition =
                            int.Parse((RootExpeditionRole.name.Replace("RootExpeditionRole", "")));

                        Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().RootExpeditionRole = RootExpeditionRole;
                    }
                    else
                    {
                        Hot.DataNowCellGameArchive.ListCellRole
                            [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().PanelCellRole_.Index].
                            e_SpriteNameRoleStatus = E_SpriteNameRoleStatus.RoleStatusNone;
                        Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().PanelCellRole_.
                            ChangeRoleStatus(E_SpriteNameRoleStatus.RoleStatusNone);
                        Hot.DataNowCellGameArchive.ListCellRole
                            [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().PanelCellRole_.Index].
                            IndexExpedition = -1;
                        Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().RootExpeditionRole = null;

                        Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].e_SpriteNameRoleStatus =
                            E_SpriteNameRoleStatus.RoleStatusExpedition;
                        PanelCellRole_.ChangeRoleStatus(E_SpriteNameRoleStatus.RoleStatusExpedition);
                        Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition = 
                            int.Parse(Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", ""));

                        Hot.ReplaceRolePortrait.transform.
                            SetParent(Hot.ReplaceRolePortrait.GetComponent<PanelCellRoleCanDrag>().PanelCellRole_.RootPortrait, false);                        
                        Hot.ReplaceRolePortrait.GetComponent<PanelCellRoleCanDrag>().RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                        Hot.ReplaceRolePortrait.transform.localPosition = Vector3.zero;                        
                    }

                    transform.SetParent(Hot.NowRootExpeditionRole.transform, false);                                      
                    Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", "")));                                  
                }
                else
                {                    
                    if (RootExpeditionRole == null)
                    {
                        Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].e_SpriteNameRoleStatus = 
                            E_SpriteNameRoleStatus.RoleStatusExpedition;
                        PanelCellRole_.ChangeRoleStatus(E_SpriteNameRoleStatus.RoleStatusExpedition);
                        RectRolePortraitCanDrag.sizeDelta = new Vector2(100, 100);
                    }
                    Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", "")));                    
                    transform.SetParent(Hot.NowRootExpeditionRole.transform, false);                    
                }

                RootExpeditionRole = Hot.NowRootExpeditionRole.transform;
            }
            else
            {
                if (RootExpeditionRole == null)
                {
                    transform.SetParent(PanelCellRole_.RootPortrait, false);
                    RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                }
                else
                {
                    transform.SetParent(RootExpeditionRole, false);                    
                }
            }
        }

        transform.localPosition = Vector3.zero;

        Hot.DragingRolePortrait = null;
        Hot.ReplaceRolePortrait = null;
        Hot.NowRootExpeditionRole = null;                
        
        Hot.Data_.Save();
    }

    #endregion

    public void InitSprite()
    {
        transform.FindSonSonSon("ImgRolePortraitCanDrag").GetComponent<Image>().sprite = PanelCellRole_.ImgRolePortrait.sprite;
    }
}
