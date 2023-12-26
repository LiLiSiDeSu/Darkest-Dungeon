using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PanelBarExpeditionTimeLine : PanelBase
{
    public Transform ExpeditionTimeLineContent;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.V && Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition)
            {
                if (Hot.PoolNowPanel_.ContainPanel("PanelBarExpeditionTimeLine"))
                {
                    Hot.MgrUI_.HidePanel(false, gameObject, "PanelBarExpeditionTimeLine");
                }
                else
                {
                    Hot.MgrUI_.ShowPanel<PanelBarExpeditionTimeLine>(true, "PanelBarExpeditionTimeLine");
                }
            }
        });

        ExpeditionTimeLineContent = transform.FindSonSonSon("ExpeditionTimeLineContent");

        Init();
    }

    public Transform GetContentStepContent(int p_Index)
    {
        return ExpeditionTimeLineContent.GetChild(p_Index).FindSonSonSon("ContentStepContent");
    }

    public void Init()
    {
        for (int i = 0; i < Hot.ExpeditionTimeLineLength; i++)
        {
            int tempi = i;

            Hot.MgrRes_.LoadAsync<GameObject>("Prefabs/" + "ContentStepScrollView",
            (obj) =>
            {
                obj.name = tempi.ToString();
                obj.transform.SetParent(ExpeditionTimeLineContent, false);
            });
        }
    }

    public void InitTimeLine()
    {
        List<List<DataContainer_GridExpeditionMap>> Map = Hot.DataNowCellGameArchive.DataNowCellMiniMap.Map;

        for (int iY = 0; iY < Map.Count; iY++)
        {
            int tempiY = iY;

            for (int iX = 0; iX < Map[tempiY].Count; iX++)
            {
                int tempiX = iX;

                if (Map[tempiY][tempiX].IndexListRole != -1)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionTimeLine>(false, "/PanelCellExpeditionTimeLine",
                    (panel) =>
                    {
                        int Speed = Hot.DataNowCellGameArchive.ListRole[Map[tempiY][tempiX].IndexListRole].NowSpeed;
                        E_RoleName e_RoleName = Hot.DataNowCellGameArchive.ListRole[Map[tempiY][tempiX].IndexListRole].e_RoleName;
                        panel.Init(Hot.ExpeditionTimeLineLength - Speed, Hot.PanelExpeditionRoom_.Grids[tempiY][tempiX].Item, 
                                   GetContentStepContent(Hot.ExpeditionTimeLineLength - Speed));
                    });
                }
                else if (Map[tempiY][tempiX].OtherRole != null)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionTimeLine>(false, "/PanelCellExpeditionTimeLine",
                    (panel) =>
                    {
                        int Speed = Map[tempiY][tempiX].OtherRole.NowSpeed;
                        E_RoleName e_RoleName = Map[tempiY][tempiX].OtherRole.e_RoleName;
                        panel.Init(Hot.ExpeditionTimeLineLength - Speed, Hot.PanelExpeditionRoom_.Grids[tempiY][tempiX].Item,
                                   GetContentStepContent(Hot.ExpeditionTimeLineLength - Speed));
                    });
                }
            }
        }
    }

    public void Clear()
    {
        int Count0 = ExpeditionTimeLineContent.childCount;
        for (int i1 = 0; i1 < Count0; i1++)
        {
            int Count1 = ExpeditionTimeLineContent.GetChild(i1).FindSonSonSon("ContentStepContent").childCount;
            for (int i2 = 0; i2 < Count1; i2++)
            {
                Destroy(ExpeditionTimeLineContent.GetChild(i1).FindSonSonSon("ContentStepContent").GetChild(i2).gameObject);
            }
        }
    }
}
