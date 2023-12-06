using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PanelExpeditionMiniMap : PanelBase
{
    public List<List<Transform>> ItemRoot = new();

    public Transform ExpeditionMiniMapContent;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
        {
            if (Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.Map)
            {
                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelExpeditionMiniMap"))
                {
                    Hot.MgrUI_.HidePanel(false, Hot.PanelExpeditionMiniMap_.gameObject, "PanelExpeditionMiniMap");
                }
                else
                {
                    Hot.MgrUI_.ShowPanel<PanelExpeditionMiniMap>(true, "PanelExpeditionMiniMap");
                }
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap") && key == Hot.MgrInput_.Add)
            {
                ExpeditionMiniMapContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap") && key == Hot.MgrInput_.Reduce && ExpeditionMiniMapContent.localScale.x > 0.5f)
            {
                ExpeditionMiniMapContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        ExpeditionMiniMapContent = transform.FindSonSonSon("ExpeditionMiniMapContent");
    }    

    public void Init()
    {
        ExpeditionMiniMapContent.GetComponent<RectTransform>().sizeDelta = 
            new(Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[0].Count * Hot.BodySizeCellMinimap.X, Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap.Count * Hot.BodySizeCellMinimap.Y);

        for (int Y = 0; Y < Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap.Count; Y++)
        {
            int tempY = Y;
            GameObject StepY = Hot.CreateContentStepY(Y, ExpeditionMiniMapContent);
            ItemRoot.Add(new());

            for (int X = 0; X < Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y].Count; X++)
            {
                int tempX = X;
                GameObject StepX = Hot.CreateContentStepY(X, StepY.transform);
                ItemRoot[Y].Add(StepX.transform);

                if (Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[Y][X].e_Room != E_CellMiniMapRoom.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionMiniMap>(false, "/PanelCellExpeditionMiniMap",
                    (panel) =>
                    {
                        panel.Init(tempX, tempY);
                        panel.transform.SetParent(StepX.transform, false);
                    });
                }
            }
        }
    }
}
