using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGameArchive : PanelBaseCell
{    
    public Image ImgEnvelope;
    private InputField IptGameArchiveInput;
    public Image ImgGameArchiveLevel;
    private Text TxtLocation;
    private Text TxtWeek;
    private Text TxtTime;    

    protected override void Start()
    {
        base.Start();
        
        transform.FindSonSonSon("ImgGameArchiveChoosed").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGameArchiveDestroy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        

        InitGameArchiveCellControl();
        InitGameArchiveCellData(Data.GetInstance().DataListCellGameArchive[Index]);

        ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeClose");
    }

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
                        DestroyImmediate(gameObject);
                        Hot.PanelGameArchiveChoose_.NowIndex -= 1;
                        Hot.PanelGameArchiveChoose_.SortCellGameArchive();

                        Hot.Data_.Destroy(Index);

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

    public void InitGameArchiveCellData(DataContainer_PanelCellGameArchive data)
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
