using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionRoom : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelBaseGrid<PanelCellExpeditionRoom> RootGrid = new();

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellRoomEditor":
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterCellExpeditionRoom = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterCellExpeditionRoom = null;
    }

    #endregion

    public void Init(PanelBaseGrid<PanelCellExpeditionRoom> p_rootGrid, bool isCreateByPut)
    {
        RootGrid = p_rootGrid;
        transform.SetParent(Hot.PanelExpeditionRoom_.ItemRoot[RootGrid.Y][RootGrid.X], false);
        transform.localPosition = new(-20, 20);

        PanelGridExpeditionRoom tempRootGrid = RootGrid as PanelGridExpeditionRoom;
        if (tempRootGrid.Data.MapObj != null)
        {
            tempRootGrid.InitGridByMapObject(this);
        }
        else
        {
            E_RoleName e_RoleName;

            if (tempRootGrid.Data.IndexListRole != -1)
            {
                e_RoleName = Hot.DataNowCellGameArchive.ListRole[tempRootGrid.Data.IndexListRole].e_RoleName;

                if (isCreateByPut)
                {
                    Hot.DataNowCellGameArchive.ListRole[tempRootGrid.Data.IndexListRole].VFlip = Hot.VFlip;
                }
            }
            else
            {
                e_RoleName = tempRootGrid.Data.OtherRole.e_RoleName;
            }

            tempRootGrid.InitGridByRole(e_RoleName, this, Hot.DataNowCellGameArchive.ListRole[tempRootGrid.Data.IndexListRole].VFlip);
        }

        int X = 0;
        int Y = 0;
        string itemName = "";
        if (tempRootGrid.Data.MapObj != null)
        {
            X = Hot.BodyDicMapObject[tempRootGrid.Data.MapObj.e_Obj].X;
            Y = Hot.BodyDicMapObject[tempRootGrid.Data.MapObj.e_Obj].Y;
            itemName = tempRootGrid.Data.MapObj.e_Obj.ToString();
        }
        else
        {
            E_RoleName e_RoleName;

            if (tempRootGrid.Data.IndexListRole != -1)
            {
                e_RoleName = Hot.DataNowCellGameArchive.ListRole[tempRootGrid.Data.IndexListRole].e_RoleName;
            }
            else
            {
                e_RoleName = tempRootGrid.Data.OtherRole.e_RoleName;
            }

            X = Hot.DicRoleConfig[e_RoleName].BodySize.X;
            Y = Hot.DicRoleConfig[e_RoleName].BodySize.Y;
            itemName = "Role" + e_RoleName.ToString() + "Await";

            if (Hot.DataNowCellGameArchive.ListRole[tempRootGrid.Data.IndexListRole].VFlip == -1)
            {
                transform.localRotation = new(0, 180, 0, 0);
                transform.localPosition += new Vector3(Hot.BodyGrid.X / 2 * Hot.DicRoleConfig[e_RoleName].BodySize.X, 0);
            }
        }

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + itemName);
        ImgItem.GetComponent<RectTransform>().sizeDelta = new(X * Hot.BodyGrid.X, Y * Hot.BodyGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta = new(X * Hot.BodyGrid.X, Y * Hot.BodyGrid.Y);
    }
}
