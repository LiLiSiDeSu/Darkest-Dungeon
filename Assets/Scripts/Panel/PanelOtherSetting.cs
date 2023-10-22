using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        CenterEvent.GetInstance().AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.Setting)
            {
                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelOtherSetting"))
                    Hot.MgrUI_.HidePanel(false, Hot.MgrUI_.GetPanel<PanelOtherSetting>("PanelOtherSetting").gameObject, "PanelOtherSetting");
                Hot.MgrUI_.ShowPanel<PanelOtherSetting>(true, "PanelOtherSetting");
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
                ImgCurrentChoice.position = new Vector3
                                 ((pos[tempi].position.x - pos[tempi].rect.width / 2) - PosOffsetForImgCurrentChoice, pos[tempi].position.y, 0);
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
                    Hot.PanelTownStore_.ClearContent();
                    Hot.PanelRoomTownShop_.PanelTownShopItem_.DestroyContent();

                    Hot.MgrUI_.HidePanel(false, Hot.MgrUI_.GetPanel<PanelTown>("PanelTown").gameObject,
                    Hot.MgrUI_.GetPanel<PanelTown>("PanelTown").gameObject.name);
                    PoolEsc.GetInstance().HideAll();
                    Hot.MgrUI_.ShowPanel<PanelOtherStart>(false, "PanelOtherStart");

                    Hot.NowIndexCellGameArchive = -1;
                }
                break;

            case "BtnKeySetting":
                break;

            case "BtnThanks":
                Debug.Log("°¢Àê¸Á¶¼");
                break;

            case "Btn>-<":
                Debug.Log(">-<");
                break;
        }
    }
}
