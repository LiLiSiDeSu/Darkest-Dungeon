using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelOtherSetting : PanelBase
{
    private Transform ImgCurrentChoice;
    private float PosOffsetForImgCurrentChoice = 85f;
    private Dictionary<string, Transform> PosBtnRoom = new Dictionary<string, Transform>();

    protected override void Awake()
    {
        base.Awake();

        CenterEvent.GetInstance().AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == MgrInput.GetInstance().Setting)
            {
                MgrUI.GetInstance().ShowPanel<PanelOtherSetting>(true, "PanelOtherSetting");
            }
        });

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");

        Button[] temppos = transform.FindSonSonSon("BtnRoot").GetComponentsInChildren<Button>();
        for (int i = 0; i < temppos.Length; i++)
        {
            PosBtnRoom.Add(temppos[i].gameObject.name, temppos[i].transform);
        }
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnQuitGame":                
                Application.Quit();
                break;

            case "BtnBackStart":                
                MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").DestroyContent();
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

    public void ChangeImgCurrentChoicePos(string Key)
    {
        ImgCurrentChoice.gameObject.SetActive(true);
        ImgCurrentChoice.position = new Vector3
                         (PosBtnRoom[Key].position.x - PosOffsetForImgCurrentChoice, PosBtnRoom[Key].position.y, 0);
    }
}
