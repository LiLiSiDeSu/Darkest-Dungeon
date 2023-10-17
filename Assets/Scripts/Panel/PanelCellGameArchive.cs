using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGameArchive : PanelBase
{
    public int Index;

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

                MgrUI.GetInstance().HidePanel
                (false, MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").gameObject, "PanelGameArchiveChoose");

                MgrUI.GetInstance().ShowPanel<PanelTown>(false, "PanelTown");
                MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive = Index;
                MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").InitContent();

                #endregion
                break;

            case "BtnGameArchiveDestroy":
                #region DestroyGameArchive

                MgrUI.GetInstance().ShowPanel<PanelOtherHint>(true, "PanelOtherHint", (panel1) =>
                {
                    MgrUI.GetInstance().GetPanel<PanelOtherHint>("PanelOtherHint").DelConfirm += (panel2) =>
                    {
                        DestroyImmediate(gameObject);
                        MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").NowIndex -= 1;
                        MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").SortCellGameArchive();

                        Data.GetInstance().Destroy(Index);

                        MgrUI.GetInstance().HidePanel(false, panel2, "PanelOtherHint");
                    };
                    MgrUI.GetInstance().GetPanel<PanelOtherHint>("PanelOtherHint").DelCancel += (panel2) =>
                    {
                        MgrUI.GetInstance().HidePanel(false, panel2, "PanelOtherHint");
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
                    MgrUI.GetInstance().ShowPanel<PanelGameArchiveChooseLevel>
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

        TxtLocation.text = data.Location;
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
