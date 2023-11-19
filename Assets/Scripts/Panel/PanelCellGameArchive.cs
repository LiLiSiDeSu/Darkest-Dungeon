using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGameArchive : PanelBaseCellDynamicScrollView,
             IPointerEnterHandler, IPointerExitHandler
{
    public Transform Root;

    private InputField IptGameArchiveName;

    public Image ImgGameArchiveChoosed;
    public Image ImgEnvelope;
    public Image ImgGameArchiveLevel;    

    private Text TxtLocation;
    private Text TxtWeek;
    private Text TxtTime;    

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "ForPanelCellGameArchive";

        Root = transform.FindSonSonSon("Root");
        
        IptGameArchiveName = transform.FindSonSonSon("IptGameArchiveName").GetComponent<InputField>();

        ImgGameArchiveLevel = transform.FindSonSonSon("ImgGameArchiveLevel").GetComponent<Image>();
        ImgEnvelope = transform.FindSonSonSon("ImgEnvelope").GetComponent<Image>();
        ImgGameArchiveChoosed = transform.FindSonSonSon("ImgGameArchiveChoosed").GetComponent<Image>();

        TxtLocation = transform.FindSonSonSon("TxtLocation").GetComponent<Text>();
        TxtWeek = transform.FindSonSonSon("TxtWeek").GetComponent<Text>();
        TxtTime = transform.FindSonSonSon("TxtTime").GetComponent<Text>();
        
        transform.FindSonSonSon("ImgGameArchiveChoosed").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGameArchiveDestroy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;                

        ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeClose");
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Root.localPosition = new Vector3(-50, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Root.localPosition = new Vector3(0, 0, 0);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ImgGameArchiveChoosed.raycastTarget = false;        
    }    

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ImgGameArchiveChoosed.raycastTarget = true;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnGameArchiveChoosed":
                #region ChoosedGameArchive

                if (Hot.Data_.DataListCellGameArchive[Index].GameArchiveName != "" && 
                    Hot.Data_.DataListCellGameArchive[Index].e_GameArchiveLevel != E_GameArchiveLevel.None)
                {
                    Hot.MgrUI_.HidePanel(false, Hot.PanelGameArchiveChoose_.gameObject, "PanelGameArchiveChoose");

                    Hot.NowIndexCellGameArchive = Index;
                    Hot.MgrUI_.ShowPanel<PanelTown>(false, "PanelTown");

                    Hot.PanelOtherResTable_.UpdateInfo();
                    Hot.PanelTownStore_.InitContent();
                    Hot.PanelTownShopItem_.InitContent();
                    Hot.PanelRoleList_.InitContent();
                    Hot.PanelBarExpedition_.InitContent();
                    Hot.PanelExpeditionPrepare_.InitContent();
                    Hot.PanelRoleGuildRecruit_.InitContent();                    

                    Hot.e_NowPlayerLocation = E_PlayerLocation.Town;
                }

                #endregion
                break;

            case "BtnGameArchiveDestroy":
                #region DestroyGameArchive

                Hot.MgrUI_.ShowPanel<PanelOtherDestroyArchiveHint>(true, "PanelOtherDestroyArchiveHint", (panel1) =>
                {
                    Hot.PanelOtherDestroyArchiveHint_.DelConfirm += (panel2) =>
                    {                        
                        Hot.PanelGameArchiveChoose_.NowIndex -= 1;                        
                        
                        DestroyImmediate(Hot.PanelGameArchiveChoose_.ListDynamicContentStep[Index].gameObject);

                        Hot.Data_.Remove(Hot.Data_.DataListCellGameArchive.Count - 1, false);

                        Hot.PanelGameArchiveChoose_.SortContent();                        

                        Hot.MgrUI_.HidePanel(false, panel2, "PanelOtherDestroyArchiveHint");                        
                    };
                    Hot.PanelOtherDestroyArchiveHint_.DelCancel += (panel2) =>
                    {
                        Hot.MgrUI_.HidePanel(false, panel2, "PanelOtherDestroyArchiveHint");
                    };
                });

                #endregion
                break;
        }             
    }

    protected override void InputField_OnValueChange(string controlname, string EventParam)
    {
        base.InputField_OnValueChange(controlname, EventParam);

        switch (controlname)
        {
            case "IptGameArchiveName":
                ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeOpen");                
                break;
        }        
    }

    protected override void InputField_OnEndEdit(string controlname, string EventParam)
    {
        base.InputField_OnEndEdit(controlname, EventParam);
        
        switch (controlname)
        {
            case "IptGameArchiveName":
                ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeClose");
                Hot.Data_.DataListCellGameArchive[Index].GameArchiveName = EventParam;
                Hot.Data_.Save(Index);

                if (Data.GetInstance().DataListCellGameArchive[Index].e_GameArchiveLevel == E_GameArchiveLevel.None)
                {
                    Hot.MgrUI_.ShowPanel<PanelGameArchiveChooseLevel>
                    (true, "PanelGameArchiveChooseLevel",                                                                                
                    (panel) =>
                    {
                        panel.IndexNowGameArchive = Index;
                        panel.ImgGameArchiveLevel = ImgGameArchiveLevel;
                    });
                }                
                break;
        }
    }     

    public void Init(DataContainer_PanelCellGameArchive data)
    {
        IptGameArchiveName.text = data.GameArchiveName;

        ChangeImgGameArchiveLevel(data.e_GameArchiveLevel);

        TxtLocation.text = data.e_ExpeditionLocation.ToString();
        TxtWeek.text = data.Week;
        TxtTime.text = data.Time;
    }

    public void ChangeImgGameArchiveLevel(E_GameArchiveLevel level)
    {
        switch (level)
        {
            case E_GameArchiveLevel.None:
                ImgGameArchiveLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/DecorateGameArchiveLevelNone");
                break;
            case E_GameArchiveLevel.Bright:
                ImgGameArchiveLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/DecorateGameArchiveLevelBright");
                break;
            case E_GameArchiveLevel.Darkness:
                ImgGameArchiveLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/DecorateGameArchiveLevelDarkness");
                break;
            case E_GameArchiveLevel.Bloodmoon:
                ImgGameArchiveLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/DecorateGameArchiveLevelBloodmoon");
                break;
        }
    }
}
