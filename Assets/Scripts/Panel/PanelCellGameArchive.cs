using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGameArchive : PanelBaseCell,
             IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform Root;

    private InputField IptGameArchiveInput;
    public Image ImgGameArchiveChoosed;
    public Image ImgEnvelope;
    public Image ImgGameArchiveLevel;    
    private Text TxtLocation;
    private Text TxtWeek;
    private Text TxtTime;

    public Vector2 DragOffSet;

    protected override void Awake()
    {
        base.Awake();

        Root = transform.FindSonSonSon("Root");

        ImgGameArchiveChoosed = transform.FindSonSonSon("ImgGameArchiveChoosed").GetComponent<Image>();
        transform.FindSonSonSon("ImgGameArchiveChoosed").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGameArchiveDestroy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        

        InitGameArchiveCellControl();        

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        ImgGameArchiveChoosed.raycastTarget = false;

        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;

        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
        Hot.PanelGameArchiveChoose_.ListDynamicContentStep[Index].gameObject.SetActive(false);

        Hot.PaddingContentStep_ =
            Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepForPanelCellGameArchive").GetComponent<DynamicContentStepForPanelCellRole>();
        Hot.PaddingContentStep_.Init(-1);
        Hot.PanelGameArchiveChoose_.EnableDetection();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ImgGameArchiveChoosed.raycastTarget = true;

        Hot.PanelGameArchiveChoose_.DisableDetection();

        if (Hot.e_NowPointerLocation == E_NowPointerLocation.PanelGameArchiveChoose)
        {
            Hot.PaddingContentStep_.transform.SetParent(Hot.PanelGameArchiveChoose_.GameArchiveContent, false);
            transform.SetParent(Hot.PaddingContentStep_.DependentObjRoot, false);
            transform.localPosition = Vector3.zero;

            DestroyImmediate(Hot.PanelGameArchiveChoose_.ListDynamicContentStep[Index].gameObject);
            Hot.PanelGameArchiveChoose_.SortContent();
        }
        else
        {
            Hot.PanelGameArchiveChoose_.ListDynamicContentStep[Index].gameObject.SetActive(true);
            transform.SetParent(Hot.PanelGameArchiveChoose_.ListDynamicContentStep[Index].DependentObjRoot, false);
            transform.localPosition = Vector3.zero;

            DestroyImmediate(Hot.PaddingContentStep_.gameObject);
            Hot.PaddingContentStep_ = null;
        }
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
            case "IptGameArchiveInput":
                ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeOpen");                
                break;
        }        
    }

    protected override void InputField_OnEndEdit(string controlname, string EventParam)
    {
        base.InputField_OnEndEdit(controlname, EventParam);
        
        switch (controlname)
        {
            case "IptGameArchiveInput":
                ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeClose");
                Data.GetInstance().DataListCellGameArchive[Index].GameArchiveName = EventParam;
                Data.GetInstance().Save(Index);

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

    private void InitGameArchiveCellControl()
    {
        ImgEnvelope = transform.FindSonSonSon("ImgEnvelope").GetComponent<Image>();
        IptGameArchiveInput = transform.FindSonSonSon("IptGameArchiveInput").GetComponent<InputField>();
        ImgGameArchiveLevel = transform.FindSonSonSon("ImgGameArchiveLevel").GetComponent<Image>();
        TxtLocation = transform.FindSonSonSon("TxtLocation").GetComponent<Text>();
        TxtWeek = transform.FindSonSonSon("TxtWeek").GetComponent<Text>();
        TxtTime = transform.FindSonSonSon("TxtTime").GetComponent<Text>();
    }    

    public void Init(DataContainer_PanelCellGameArchive data)
    {
        IptGameArchiveInput.text = data.GameArchiveName;

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
