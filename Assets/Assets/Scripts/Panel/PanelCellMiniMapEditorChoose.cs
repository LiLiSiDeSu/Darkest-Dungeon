using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMiniMapEditorChoose : PanelBase
{
    public E_CellMap e_CellExpeditionMiniMap = E_CellMap.None;
    public Image ImgCellMiniMapEditorChoose;

    protected override void Awake()
    {
        base.Awake();

        ImgCellMiniMapEditorChoose = transform.FindSonSonSon("ImgCellMiniMapEditorChoose").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellMiniMapEditorChoose":
                Hot.e_ChoseRoom = e_CellExpeditionMiniMap;

                if (Hot.PanelOtherMiniMapEditor_.EntrancePos.X != -1 && Hot.e_ChoseRoom == E_CellMap.CellMapRoomEntrance)
                {
                    Hot.e_ChoseRoom = E_CellMap.None;
                    return;
                }

                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + e_CellExpeditionMiniMap.ToString());
                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.GetComponent<RectTransform>().sizeDelta = new(60, 60);                
                break;
        }
    }

    public void Init(E_CellMap p_e_CellExpeditionMiniMap)
    {
        e_CellExpeditionMiniMap = p_e_CellExpeditionMiniMap;
        ImgCellMiniMapEditorChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + p_e_CellExpeditionMiniMap.ToString());

        if (e_CellExpeditionMiniMap.ToString().Contains("Hall"))
        {
            ImgCellMiniMapEditorChoose.GetComponent<RectTransform>().sizeDelta = new(10, 10);
        }
    }
}
