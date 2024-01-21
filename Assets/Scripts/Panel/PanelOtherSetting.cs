using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelOtherSetting : PanelBase
{
    private Transform ImgCurrentChoice;
    private float PosOffsetForImgCurrentChoice = 10f;

    protected override void Awake()
    {
        base.Awake();

        CenterEvent.GetInstance().AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(), (key) =>
        {
            if (key == Hot.MgrInput_.Setting)
            {
                if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelOtherSetting))
                {
                    Hot.MgrUI_.HidePanel(false, Hot.PanelOtherSetting_.gameObject, E_PanelName.PanelOtherSetting);
                }
                else
                {
                    Hot.MgrUI_.ShowPanel<PanelOtherSetting>(true, E_PanelName.PanelOtherSetting);
                }
            }
        });

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");
        ImgCurrentChoice.gameObject.SetActive(false);

        Button[] btns = transform.FindSonSonSon("BtnRoot").GetComponentsInChildren<Button>();
        Text[] txts = transform.FindSonSonSon("BtnRoot").GetComponentsInChildren<Text>();
        RectTransform[] pos = new RectTransform[txts.Length];
        for (int i = 0; i < txts.Length; i++)
        {
            pos[i] = txts[i].GetComponent<RectTransform>();

            int tempi = i;

            Hot.MgrUI_.AddCustomEventListener
            (btns[i].gameObject, EventTriggerType.PointerEnter,
            (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(true);
                ImgCurrentChoice.position = new((pos[tempi].position.x - pos[tempi].rect.width / 2) - PosOffsetForImgCurrentChoice, pos[tempi].position.y, 0);
            });
            Hot.MgrUI_.AddCustomEventListener
            (btns[i].gameObject, EventTriggerType.PointerExit, (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(false);
            });
        }

        btns = null;
    }

    protected override void Button_OnClick(string Controlname)
    {
        base.Button_OnClick(Controlname);

        switch (Controlname)
        {
            case "BtnQuitGame":
                Application.Quit();
                break;

            case "BtnBackStart":
                if (Hot.NowIndexCellGameArchive != -1)
                {
                    Hot.Data_.Save();

                    Hot.MgrUI_.HideAllPanel();

                    Hot.PanelBarTownStore_.Clear();
                    Hot.PanelBarRoleList_.Clear();
                    Hot.PanelBarExpedition_.Clear();
                    Hot.PanelBarRoleListExpedition_.ClearNoData();
                    Hot.PanelBarExpeditionTimeLine_.Clear();
                    Hot.PanelExpeditionRoom_.Clear();
                    Hot.PanelTownShopItem_.ClearAll();
                    Hot.PanelRoleGuildRecruit_.Clear();
                    Hot.PanelExpeditionPrepare_.Clear();
                    Hot.e_NowPlayerLocation = E_PlayerLocation.ChooseGameArchive;

                    Hot.MgrUI_.ShowPanel<PanelOtherStart>(false, E_PanelName.PanelOtherStart);

                    Hot.NowIndexCellGameArchive = -1;
                }
                break;

            case "BtnKeySetting":
                Debug.Log("BtnKeySetting!!!");
                break;

            case "BtnThanks":
                Debug.Log("Thanks!!!");
                break;

            case "Btn>-<":
                Debug.Log(">-<");
                break;
        }
    }
}
