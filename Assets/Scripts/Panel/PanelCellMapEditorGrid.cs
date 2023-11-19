using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMapEditorGrid : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public int W;
    public int H;

    public bool IsHave;

    public Image ImgStatus;

    public GameObject DependentObj;

    public E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall = E_CellExpeditionMiniMapHall.None;
    public E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom = E_CellExpeditionMiniMapRoom.None;

    protected override void Awake()
    {
        base.Awake();

        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();        
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (JudegeHallCanPut())
        {
            Hot.PanelOtherMapEditor_.Map[W][H].ImgStatus.sprite =
                        Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
        }

        if (JudegeRoomCanPut())
        {
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Hot.PanelOtherMapEditor_.Map[W - 1 + i1][H + 1 - i2].ImgStatus.sprite =
                        Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (JudegeHallCanPut())
        {
            Hot.PanelOtherMapEditor_.Map[W][H].ImgStatus.sprite =
                Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
        }

        if (JudegeRoomCanPut())
        {
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Hot.PanelOtherMapEditor_.Map[W - 1 + i1][H + 1 - i2].ImgStatus.sprite =
                        Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                }
            }
        }
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnPut":                
                if (JudegeRoomCanPut())
                {
                    DependentObj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgRoom");
                    DependentObj.GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMap" + Hot.e_NowChooseRoom);
                    DependentObj.transform.SetParent(Hot.PanelOtherMapEditor_.DependentObj[W][H], false);
                    DependentObj.transform.localPosition = Vector3.zero;

                    for (int i1 = 0; i1 < 3; i1++)
                    {
                        for (int i2 = 0; i2 < 3; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Map[W - 1 + i1][H + 1 - i2].IsHave = true;
                        }
                    }

                    Hot.PanelOtherMapEditor_.Map[W][H].e_CellExpeditionMiniMapRoom = Hot.e_NowChooseRoom;
                }

                if (JudegeHallCanPut())
                {
                    DependentObj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgHall");
                    DependentObj.GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMap" + Hot.e_NowChooseHall);
                    DependentObj.transform.SetParent(Hot.PanelOtherMapEditor_.DependentObj[W][H], false);
                    DependentObj.transform.localPosition = Vector3.zero;

                    Hot.PanelOtherMapEditor_.Map[W][H].IsHave = true;
                    Hot.PanelOtherMapEditor_.Map[W][H].e_CellExpeditionMiniMapHall = Hot.e_NowChooseHall;
                }
                break;
        }
    }

    public void Init(int w, int h)
    {
        W = w;
        H = h;
    }

    public void Init(int w, int h, DataContainer_ExpeditionMiniMap MapData)
    {
        W = w;
        H = h;        

        IsHave = MapData.ListCellMiniMap[w][h].IsHave;
        e_CellExpeditionMiniMapHall = MapData.ListCellMiniMap[w][h].e_CellExpeditionMiniMapHall;
        e_CellExpeditionMiniMapRoom = MapData.ListCellMiniMap[w][h].e_CellExpeditionMiniMapRoom;

        if (MapData.ListCellMiniMap[w][h].e_CellExpeditionMiniMapRoom != E_CellExpeditionMiniMapRoom.None)
        {
            DependentObj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgRoom");
            DependentObj.GetComponent<Image>().sprite =
                Hot.MgrRes_.Load<Sprite>("Art/CellMap" + MapData.ListCellMiniMap[w][h].e_CellExpeditionMiniMapRoom);
            DependentObj.transform.SetParent(Hot.PanelOtherMapEditor_.DependentObj[w][h], false);
            DependentObj.transform.localPosition = Vector3.zero;
        }

        if (MapData.ListCellMiniMap[w][h].e_CellExpeditionMiniMapHall != E_CellExpeditionMiniMapHall.None)
        {
            DependentObj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgHall");
            DependentObj.GetComponent<Image>().sprite =
                Hot.MgrRes_.Load<Sprite>("Art/CellMap" + MapData.ListCellMiniMap[w][h].e_CellExpeditionMiniMapHall);
            DependentObj.transform.SetParent(Hot.PanelOtherMapEditor_.DependentObj[w][h], false);
            DependentObj.transform.localPosition = Vector3.zero;
        }
    }

    public bool JudegeHallCanPut()
    {
        return (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None) && !Hot.PanelOtherMapEditor_.Map[W][H].IsHave;
    }

    public bool JudegeRoomCanPut()
    {
        bool result = true;

        if (!(W > 0 && W < int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text) - 1 &&
              H > 0 && H < int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) - 1 &&
              Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None))
        {
            return false;
        }

        for (int i1 = 0; i1 < 3; i1++)
        {
            for (int i2 = 0; i2 < 3; i2++)
            {
                result &= !Hot.PanelOtherMapEditor_.Map[W - 1 + i1][H + 1 - i2].IsHave;                
            }
        }

        return result;
    }
}
