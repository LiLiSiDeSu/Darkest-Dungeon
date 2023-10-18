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

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");
        ImgCurrentChoice.gameObject.SetActive(false);

        CenterEvent.GetInstance().AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == MgrInput.GetInstance().Setting)
            {
                MgrUI.GetInstance().ShowPanel<PanelOtherSetting>(true, "PanelOtherSetting");
            }
        });

        Button[] btns = transform.FindSonSonSon("BtnRoot").GetComponentsInChildren<Button>();
        Text[] txts = transform.FindSonSonSon("BtnRoot").GetComponentsInChildren<Text>();
        RectTransform[] pos = new RectTransform[txts.Length];
        for (int i = 0; i < txts.Length; i++)
        {
            pos[i] = txts[i].GetComponent<RectTransform>();

            int tempi = i;

            MgrUI.GetInstance().AddCustomEventListener
            (btns[i].gameObject, EventTriggerType.PointerEnter,
            (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(true);      
                ImgCurrentChoice.position = new Vector3
                                 ((pos[tempi].position.x - pos[tempi].rect.width / 2) - PosOffsetForImgCurrentChoice, pos[tempi].position.y, 0);
            });
            MgrUI.GetInstance().AddCustomEventListener
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
                MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").DestroyContent();
                (MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").AllPanel["PanelRoomShop"] as PanelRoomShop).PanelShopItem_.DestroyContent();

                MgrUI.GetInstance().HidePanel
                (false, MgrUI.GetInstance().GetPanel<PanelTown>("PanelTown").gameObject,
                MgrUI.GetInstance().GetPanel<PanelTown>("PanelTown").gameObject.name);
                PoolEsc.GetInstance().HideAll();
                MgrUI.GetInstance().ShowPanel<PanelOtherStart>(false, "PanelOtherStart");
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
