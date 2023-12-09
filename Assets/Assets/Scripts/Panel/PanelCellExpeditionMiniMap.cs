using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionMiniMap : PanelBaseCellVector2
{
    public int X;
    public int Y;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellExpeditionMiniMap":
                Hot.PanelExpeditionRoom_.LoadRoomData(X, Y);
                break;
        }
    }

    public void Init(int p_x, int p_y)
    {
        X = p_x;
        Y = p_y;

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y][X].e_Room);
        ChangeRoomSize();
    }

    public void ChangeRoomSize()
    {
        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicRoom[Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y][X].e_Room].X * Hot.BodySizeCellMinimap.X, 
                Hot.BodyDicRoom[Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y][X].e_Room].Y * Hot.BodySizeCellMinimap.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicRoom[Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y][X].e_Room].X * Hot.BodySizeCellMinimap.X, 
                Hot.BodyDicRoom[Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y][X].e_Room].Y * Hot.BodySizeCellMinimap.Y);
    }
}
