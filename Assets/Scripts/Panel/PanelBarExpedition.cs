using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelBarExpedition : PanelBase
{
    public int NowIndex;
    public Transform Content;
    public GameObject ScrollView_;

    public GameObject RootExpeditionRole0;
    public GameObject RootExpeditionRole1;
    public GameObject RootExpeditionRole2;
    public GameObject RootExpeditionRole3;

    public GameObject BtnOpen;
    public GameObject BtnPackUp;

    protected override void Awake()
    {
        base.Awake();        

        transform.FindSonSonSon("ImgOpen").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgPackUp").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgExpedition").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        BtnOpen = transform.FindSonSonSon("BtnOpen").gameObject;
        BtnPackUp = transform.FindSonSonSon("BtnPackUp").gameObject;
        BtnOpen.SetActive(false);

        ScrollView_ = transform.FindSonSonSon("ScrollView_").gameObject;
        Content = transform.FindSonSonSon("Content");

        RootExpeditionRole0 = transform.FindSonSonSon("RootExpeditionRole0").gameObject;
        RootExpeditionRole1 = transform.FindSonSonSon("RootExpeditionRole1").gameObject;
        RootExpeditionRole2 = transform.FindSonSonSon("RootExpeditionRole2").gameObject;
        RootExpeditionRole3 = transform.FindSonSonSon("RootExpeditionRole3").gameObject;

        #region ��������¼�����

        Hot.MgrUI_.AddCustomEventListener
        (ScrollView_, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.e_NowPointerLocation = E_NowPointerLocation.TownPrepareExpedition;
        });
        Hot.MgrUI_.AddCustomEventListener
        (ScrollView_, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.e_NowPointerLocation = E_NowPointerLocation.None;
        });
        Hot.MgrUI_.AddCustomEventListener
        (transform.FindSonSonSon("RootExpedition").gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.e_NowPointerLocation = E_NowPointerLocation.TownExpedition;
        });
        Hot.MgrUI_.AddCustomEventListener
        (transform.FindSonSonSon("RootExpedition").gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.e_NowPointerLocation = E_NowPointerLocation.None;
        });

        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole0, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowRootExpeditionRole = RootExpeditionRole0;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole0, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowRootExpeditionRole = null;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole1, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowRootExpeditionRole = RootExpeditionRole1;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole1, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowRootExpeditionRole = null;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole2, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowRootExpeditionRole = RootExpeditionRole2;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole2, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowRootExpeditionRole = null;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole3, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowRootExpeditionRole = RootExpeditionRole3;
        });
        Hot.MgrUI_.AddCustomEventListener
        (RootExpeditionRole3, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowRootExpeditionRole = null;
        });

        #endregion
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnOpen":
                BtnOpen.SetActive(false);
                BtnPackUp.SetActive(true);
                ScrollView_.SetActive(true);
                break;
            case "BtnPackUp":
                BtnOpen.SetActive(true);
                BtnPackUp.SetActive(false);
                ScrollView_.SetActive(false);
                break;
            case "BtnExpedition":
                Debug.Log("Expedition");
                break;
        }
    }

    public void InitContent()
    {
        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellRole.Count; i++)
        {
            int tempi = i;

            switch (Hot.DataNowCellGameArchive.ListCellRole[tempi].IndexExpedition)
            {
                case 0:
                    Hot.MgrUI_.CreatePanel<PanelCellRoleCanDrag>("/PanelCellRoleCanDrag",
                    (panel) =>
                    {
                        panel.Father = RootExpeditionRole0.transform;
                        Hot.DragingRolePortrait = panel.gameObject;
                        panel.transform.SetParent(RootExpeditionRole0.transform, false);

                        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().sprite =
                        Hot.PanelRoleList_.ListContentStep[tempi].
                        transform.FindSonSonSon("PanelCellRole").GetComponent<PanelCellRole>().ImgPortrait.sprite;

                        panel.PanelCellRole_ = Hot.PanelRoleList_.ListContentStep[tempi].GetComponentInChildren<PanelCellRole>();
                    });
                    break;
                case 1:
                    Hot.MgrUI_.CreatePanel<PanelCellRoleCanDrag>("/PanelCellRoleCanDrag",
                    (panel) =>
                    {
                        panel.Father = RootExpeditionRole1.transform;
                        Hot.DragingRolePortrait = panel.gameObject;
                        panel.transform.SetParent(RootExpeditionRole1.transform, false);

                        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().sprite =
                        Hot.PanelRoleList_.ListContentStep[tempi].
                        transform.FindSonSonSon("PanelCellRole").GetComponent<PanelCellRole>().ImgPortrait.sprite;

                        panel.PanelCellRole_ = Hot.PanelRoleList_.ListContentStep[tempi].GetComponentInChildren<PanelCellRole>();
                    });
                    break;
                case 2:
                    Hot.MgrUI_.CreatePanel<PanelCellRoleCanDrag>("/PanelCellRoleCanDrag",
                    (panel) =>
                    {
                        panel.Father = RootExpeditionRole2.transform;
                        Hot.DragingRolePortrait = panel.gameObject;
                        panel.transform.SetParent(RootExpeditionRole2.transform, false);

                        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().sprite =
                        Hot.PanelRoleList_.ListContentStep[tempi].
                        transform.FindSonSonSon("PanelCellRole").GetComponent<PanelCellRole>().ImgPortrait.sprite;

                        panel.PanelCellRole_ = Hot.PanelRoleList_.ListContentStep[tempi].GetComponentInChildren<PanelCellRole>();
                    });
                    break;
                case 3:
                    Hot.MgrUI_.CreatePanel<PanelCellRoleCanDrag>("/PanelCellRoleCanDrag",
                    (panel) =>
                    {
                        panel.Father = RootExpeditionRole3.transform;
                        Hot.DragingRolePortrait = panel.gameObject;
                        panel.transform.SetParent(RootExpeditionRole3.transform, false);

                        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().sprite =
                        Hot.PanelRoleList_.ListContentStep[tempi].
                        transform.FindSonSonSon("PanelCellRole").GetComponent<PanelCellRole>().ImgPortrait.sprite;

                        panel.PanelCellRole_ = Hot.PanelRoleList_.ListContentStep[tempi].GetComponentInChildren<PanelCellRole>();
                    });
                    break;
            }
        }
    }

    public void Clear()
    {
        ClearRootExpeditionRole();
        ClearContent();
    }

    public void ClearRootExpeditionRole()
    {
        Destroy(RootExpeditionRole0.GetComponentInChildren<PanelCellRoleCanDrag>().gameObject);
        Destroy(RootExpeditionRole1.GetComponentInChildren<PanelCellRoleCanDrag>().gameObject);
        Destroy(RootExpeditionRole2.GetComponentInChildren<PanelCellRoleCanDrag>().gameObject);
        Destroy(RootExpeditionRole3.GetComponentInChildren<PanelCellRoleCanDrag>().gameObject);
    }

    public void ClearContent()
    {

    }
}