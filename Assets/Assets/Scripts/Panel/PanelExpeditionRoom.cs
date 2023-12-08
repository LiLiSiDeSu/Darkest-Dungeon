using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoom : PanelBaseVector2<PanelGridExpeditionRoom>
{
    public Transform ImgRoomBk;

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == Hot.MgrInput_.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(false);
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyUp",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == Hot.MgrInput_.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(true);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && !Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap"))
            {
                if (key == Hot.MgrInput_.Add)
                {
                    AllContent.localScale +=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }

                if (AllContent.localScale.x > 1f && key == Hot.MgrInput_.Reduce)
                {
                    AllContent.localScale -=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
            }
        });

        Hot.MgrUI_.CreatePanel<PanelExpeditionRoleDetails>(true, "/PanelExpeditionRoleDetails",
        (panel) =>
        {
            panel.transform.SetParent(transform, false);
        });

        InitGrid(Hot.BodyExpeditionRoom.Y, Hot.BodyExpeditionRoom.X);
    }    

    public void LoadRoomData(int p_x, int p_y)
    {
        ClearList();

        List<List<DataContainer_CellExpeditionMapGrid>> Map = Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[p_y][p_x].Map;

        for (int Y = 0; Y < Map.Count; Y++)
        {
            int tempY = Y;

            for (int X = 0; X < Map[Y].Count; X++)
            {
                int tempX = X;

                if (Map[tempY][tempX].Obj.e_Obj != E_MapObject.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
                    (panel) =>
                    {
                        panel.Init(Map[tempY][tempX].Obj.e_Obj, Grids[tempY][tempX]);
                        panel.transform.SetParent(ItemRoot[tempY][tempX], false);
                        panel.transform.localPosition = new(-20, 20);

                        for (int Y = 0; Y < Hot.BodyDicMapObject[panel.e_Obj].Y; Y++)
                        {
                            for (int X = 0; X < Hot.BodyDicMapObject[panel.e_Obj].X; X++)
                            {
                                Grids[tempY + Y][tempX + X].CellExpeditionRoom = panel;
                            }
                        }
                    });
                }
            }
        }
    }

    public override void ClearList()
    {
        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                if (item.CellExpeditionRoom != null)
                {
                    Destroy(item.CellExpeditionRoom.gameObject);
                    item.CellExpeditionRoom = null;
                }
            }
        }
    }
}
