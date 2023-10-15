using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGameArchive : PanelBase
{
    public int IndexCellGameArchive;

    public Image ImgEnvelope;
    private InputField IptGameArchiveInput;
    private Image ImgGameArchiveLevel;
    private Text TxtLocation;
    private Text TxtWeek;
    private Text TxtTime;

    public DataContainer_PanelCellGameArchive DataPanelCellGameArchive = new DataContainer_PanelCellGameArchive();

    protected override void Start()
    {
        base.Start();

        transform.FindSonSonSon("BtnGameArchiveChoosed").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("BtnGameArchiveDestroy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        

        InitGameArchiveCellControl();
        InitGameArchiveCellData(DataPanelCellGameArchive);

        ImgEnvelope.sprite = MgrRes.GetInstance().Load<Sprite>("Art/EnvelopeClose");
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnGameArchiveChoosed":
                MgrUI.GetInstance().HidePanel
                (false, MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").gameObject, 
                "PanelGameArchiveChoose");

                MgrUI.GetInstance().ShowPanel<PanelTown>(false, "PanelTown");
                MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").NowGameArchive = this;
                MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").InitContent();
                break;

            case "BtnGameArchiveDestroy":
                MgrUI.GetInstance().ShowPanel<PanelOtherHint>(true, "PanelOtherHint", (panel1) =>
                {
                    MgrUI.GetInstance().GetPanel<PanelOtherHint>("PanelOtherHint").DelConfirm += (panel2) =>
                    {                        
                        DestroyImmediate(gameObject);
                        MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").
                                                                            NowIndex -= 1;
                        MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").SortCellGameArchive();

                        MgrData.GetInstance().DataListCellGameArchive.RemoveAt(IndexCellGameArchive);
                        MgrData.GetInstance().Save();

                        MgrUI.GetInstance().HidePanel(false, panel2, "PanelOtherHint");                        
                    };
                    MgrUI.GetInstance().GetPanel<PanelOtherHint>("PanelOtherHint").DelCancel += (panel2) =>
                    {                        
                        MgrUI.GetInstance().HidePanel(false, panel2, "PanelOtherHint");                        
                    };
                });                
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
                DataPanelCellGameArchive.GameArchiveName = EventParam;
                MgrData.GetInstance().Save();

                if (DataPanelCellGameArchive.e_GameArchiveLevel == E_GameArchiveLevel.None)
                {
                    MgrUI.GetInstance().ShowPanel<PanelGameArchiveChooseLevel>
                    (true, "PanelGameArchiveChooseLevel",                                                                                
                    (panel) =>
                    {
                        panel.Cell = this;
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

        switch (data.e_GameArchiveLevel)
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

        TxtLocation.text = data.Location;
        TxtWeek.text = data.Week;
        TxtTime.text = data.Time;
    }
}
