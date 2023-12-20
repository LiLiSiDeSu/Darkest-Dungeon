using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionRoom : PanelBaseCellVector2
{
    public PanelGridExpeditionRoom RootGrid = new();
    public Image VFlipCast;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellRoomEditor":
                if (Hot.NowChoseCellExpeditionRoom == null)
                {
                    Hot.NowChoseCellExpeditionRoom = this;
                    GenerateMoveArea();
                    Hot.NowChoseCellExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);

                    return;
                }
                if (Hot.NowChoseCellExpeditionRoom == this)
                {
                    Hot.NowChoseCellExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    Hot.NowChoseCellExpeditionRoom = null;
                    Hot.PanelExpeditionRoom_.ClearImgStatus();

                    return;
                }
                if (Hot.NowChoseCellExpeditionRoom != this)
                {
                    Hot.NowChoseCellExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    Hot.PanelExpeditionRoom_.ClearImgStatus();
                    Hot.NowChoseCellExpeditionRoom = this;
                    GenerateMoveArea();
                    Hot.NowChoseCellExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);

                    return;
                }
                break;
        }
    }

    public void Init(PanelGridExpeditionRoom p_rootGrid, bool isCreateByPut)
    {
        RootGrid = p_rootGrid;
        transform.SetParent(Hot.PanelExpeditionRoom_.ItemRoot[RootGrid.Y][RootGrid.X], false);
        transform.localPosition = new(-20, 20);

        if (RootGrid.Data.MapObj != null)
        {
            RootGrid.InitGridByMapObject(this);
        }
        else
        {
            E_RoleName e_RoleName;

            if (RootGrid.Data.IndexListRole != -1)
            {
                e_RoleName = Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].e_RoleName;

                if (isCreateByPut)
                {
                    Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].VFlip = Hot.VFlip;
                }
            }
            else
            {
                e_RoleName = RootGrid.Data.OtherRole.e_RoleName;
            }

            RootGrid.InitGridByRole(e_RoleName, this, Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].VFlip);
        }

        int X = 0;
        int Y = 0;
        string itemName = "";
        if (RootGrid.Data.MapObj != null)
        {
            X = Hot.BodyDicMapObject[RootGrid.Data.MapObj.e_Obj].X;
            Y = Hot.BodyDicMapObject[RootGrid.Data.MapObj.e_Obj].Y;
            itemName = RootGrid.Data.MapObj.e_Obj.ToString();
        }
        else
        {
            E_RoleName e_RoleName;

            if (RootGrid.Data.IndexListRole != -1)
            {
                e_RoleName = Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].e_RoleName;
            }
            else
            {
                e_RoleName = RootGrid.Data.OtherRole.e_RoleName;
            }

            X = Hot.DicRoleConfig[e_RoleName].SizeBody.X;
            Y = Hot.DicRoleConfig[e_RoleName].SizeBody.Y;
            itemName = "Role" + e_RoleName.ToString() + "Await";

            if (Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].VFlip == -1)
            {
                transform.localRotation = new(0, 180, 0, 0);
                transform.localPosition += new Vector3(40, 0);
                ImgItem.raycastTarget = false;
                Image img = Instantiate(ImgItem, ImgItem.transform.parent);
                VFlipCast = img;
                img.transform.localRotation = new(0, 180, 0, 0);
                img.transform.localPosition += new Vector3(Hot.BodyGrid.X * Hot.DicRoleConfig[e_RoleName].SizeBody.X, 0);
                img.GetComponent<Image>().raycastTarget = true;
            }
        }

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + itemName);
        ImgItem.GetComponent<RectTransform>().sizeDelta = new(X * Hot.BodyGrid.X, Y * Hot.BodyGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta = new(X * Hot.BodyGrid.X, Y * Hot.BodyGrid.Y);

        if (RootGrid.Data.IndexListRole != -1 && Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].VFlip == -1)
        {
            VFlipCast.GetComponent<RectTransform>().sizeDelta = new(X * Hot.BodyGrid.X, Y * Hot.BodyGrid.Y);
            VFlipCast.GetComponent<RectTransform>().sizeDelta = new(X * Hot.BodyGrid.X, Y * Hot.BodyGrid.Y);
        }
    }

    public void GenerateMoveArea()
    {
        if (RootGrid.Data.IndexListRole != -1)
        {
            E_RoleName e_RoleName = Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].e_RoleName;
            bool isQuit = false;
            int count = 0;
            int rX = 0;
            int VFlip = Hot.DataNowCellGameArchive.ListRole[RootGrid.Data.IndexListRole].VFlip;

            for (int i = 0; i < Hot.DicRoleConfig[e_RoleName].SizeMove.Jump; i++)
            {
                if (RootGrid.Y - 1 - i < 0)
                {
                    break;
                }

                if (isQuit)
                {
                    isQuit = false;
                    break;
                }

                for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++)
                {
                    if (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y - 1 - i][RootGrid.X + iX * VFlip].Item == null)
                    {
                        (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y - 1 - i][RootGrid.X + iX * VFlip] as PanelGridExpeditionRoom).SetCanMoveTrue();
                    }
                    else
                    {
                        for (int t_iX = 0; t_iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; t_iX++)
                        {
                            (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y - 1 - i][RootGrid.X + t_iX * VFlip] as PanelGridExpeditionRoom).SetCanMoveFalse();
                        }
                        isQuit = true;
                        break;
                    }
                }
            }

            if (Hot.DicRoleConfig[e_RoleName].e_MoveType == E_RoleMoveType.Sky)
            {
                for (int i = 0; i < Hot.DicRoleConfig[e_RoleName].SizeMove.Fall; i++)
                {
                    if (RootGrid.Y + Hot.DicRoleConfig[e_RoleName].SizeBody.Y + i > Hot.BodyMap.Y - 1)
                    {
                        break;
                    }

                    if (isQuit)
                    {
                        isQuit = false;
                        break;
                    }

                    for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++) 
                    {
                        if (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + Hot.DicRoleConfig[e_RoleName].SizeBody.Y + i][RootGrid.X + iX * VFlip].Item == null)
                        {
                            (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + Hot.DicRoleConfig[e_RoleName].SizeBody.Y + i][RootGrid.X + iX * VFlip]
                                as PanelGridExpeditionRoom).SetCanMoveTrue();
                        }
                        else
                        {
                            for (int t_iX = 0; t_iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; t_iX++)
                            {
                                (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + Hot.DicRoleConfig[e_RoleName].SizeBody.Y + i][RootGrid.X + t_iX * VFlip]
                                    as PanelGridExpeditionRoom).SetCanMoveFalse();
                            }
                            isQuit = true;
                            break;
                        }
                    }
                }
            }

            if (VFlip == 1)
            {
                count = Hot.DicRoleConfig[e_RoleName].SizeMove.BackUp;
            }
            else
            {
                count = Hot.DicRoleConfig[e_RoleName].SizeMove.Forward;
            }
            for (int i = 0; i < count; i++)
            {
                if (VFlip == 1)
                {
                    rX = RootGrid.X - 1 - i;
                }
                else
                {
                    rX = RootGrid.X - Hot.DicRoleConfig[e_RoleName].SizeBody.X - i;
                }

                if (VFlip == 1 && rX < 0)
                {
                    break;
                }
                else if (VFlip == -1 && rX < 0)
                {
                    break;
                }

                if (isQuit)
                {
                    isQuit = false;
                    break;
                }

                for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
                {
                    if (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + iY][rX].Item == null)
                    {
                        (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + iY][rX] as PanelGridExpeditionRoom).SetCanMoveTrue();
                    }
                    else
                    {
                        for (int t_iY = 0; t_iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; t_iY++)
                        {
                            (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + t_iY][rX] as PanelGridExpeditionRoom).SetCanMoveFalse();
                        }
                        isQuit = true;
                        break;
                    }
                }
            }

            if (VFlip == 1)
            {
                count = Hot.DicRoleConfig[e_RoleName].SizeMove.Forward;
            }
            else
            {
                count = Hot.DicRoleConfig[e_RoleName].SizeMove.BackUp;
            }
            for (int i = 0; i < count; i++)
            {
                if (VFlip == 1)
                {
                    rX = RootGrid.X + Hot.DicRoleConfig[e_RoleName].SizeBody.X + i;
                }
                else
                {
                    rX = RootGrid.X + 1 + i;
                }

                if (VFlip == 1 && rX > Hot.BodyMap.X - 1)
                {
                    break;
                }
                else if (VFlip == -1 && rX > Hot.BodyMap.X - 1)
                {
                    break;
                }

                if (isQuit)
                {
                    isQuit = false;
                    break;
                }

                for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
                {
                    if (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + iY][rX].Item == null)
                    {
                        (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + iY][rX] as PanelGridExpeditionRoom).SetCanMoveTrue();
                    }
                    else
                    {
                        for (int t_iY = 0; t_iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; t_iY++)
                        {
                            (Hot.PanelExpeditionRoom_.Grids[RootGrid.Y + t_iY][rX] 
                                as PanelGridExpeditionRoom).SetCanMoveFalse();
                        }
                        isQuit = true;
                        break;
                    }
                }
            }
        }
    }
}
