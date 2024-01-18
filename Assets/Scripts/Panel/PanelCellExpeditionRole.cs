using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionRole : PanelBaseCell,
             IPointerEnterHandler, IPointerExitHandler
{
    public int IndexRoleList;

    public Image ImgRolePortrait;
    public Image ImgBanner;

    public PanelCellExpeditionRoom CellExpeditionRoom;

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
        ImgBanner = transform.FindSonSonSon("ImgBanner").GetComponent<Image>();
        ImgBanner.gameObject.SetActive(false);
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImgRolePortrait.transform.localPosition = new(0, -20);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImgRolePortrait.transform.localPosition = new(0, 0);
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":
                if (Hot.UpdateOver)
                {
                    if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count != 0)
                    {
                        return;
                    }

                    if (Hot.PanelExpeditionRoleDetails_.IndexRole == IndexRoleList)
                    {
                        Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(-1);
                    }
                    else
                    {
                        Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(IndexRoleList);
                    }

                    if (Hot.ChoseCellExpeditionRoom == null)
                    {
                        Hot.ChoseCellExpeditionRoom = CellExpeditionRoom;
                        Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                        Hot.ChoseCellExpeditionRoom.UpdateImgStatus(false);

                        return;
                    }
                    if (Hot.ChoseCellExpeditionRoom == CellExpeditionRoom)
                    {
                        Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
                        Hot.ChoseCellExpeditionRoom = null;
                        Hot.PanelExpeditionRoom_.ClearMoveStaus();

                        return;
                    }
                    if (Hot.ChoseCellExpeditionRoom != CellExpeditionRoom)
                    {
                        Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
                        Hot.PanelExpeditionRoom_.ClearMoveStaus();
                        Hot.ChoseCellExpeditionRoom = CellExpeditionRoom;
                        Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                        Hot.ChoseCellExpeditionRoom.UpdateImgStatus(false);

                        return;
                    }
                }
                break;
        }
    }

    public void Init(int p_Index, int p_IndexRoleList, Transform p_father)
    {
        transform.SetParent(p_father, false);
        Index = p_Index;
        IndexRoleList = p_IndexRoleList;
        ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + Hot.DataNowCellGameArchive.ListRole[IndexRoleList].e_RoleName.ToString());
    }
}
