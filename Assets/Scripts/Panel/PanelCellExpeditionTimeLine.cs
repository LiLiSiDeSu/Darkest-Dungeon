using UnityEngine.UI;

public class PanelCellExpeditionTimeLine : PanelBase
{
    public Image ImgStatus;
    public Image ImgRolePortrait;

    public PanelCellExpeditionRoom CellExpeditionRoom;

    public DataContainer_CellRole Data
    {
        get
        {
            if (CellExpeditionRoom.RootGrid.Data.IndexListRole != -1)
            {
                return Hot.DataNowCellGameArchive.ListRole[CellExpeditionRoom.RootGrid.Data.IndexListRole];
            }
            else
            {
                return CellExpeditionRoom.RootGrid.Data.OtherRole;
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":
                Hot.PanelExpeditionRoom_.RoleOnClick(CellExpeditionRoom);
                break;
        }
    }

    public void Init(int p_Speed, PanelCellExpeditionRoom p_CellExpeditionRoom)
    {
        int NowTimeLinePos = Hot.ExpeditionTimeLineLength - p_Speed;

        CellExpeditionRoom = p_CellExpeditionRoom;
        CellExpeditionRoom.CellTimeLine = this;

        Data.NowTimeLinePos = NowTimeLinePos;
        ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + Data.e_RoleName.ToString());
        transform.SetParent(Hot.PanelBarExpeditionTimeLine_.GetContentStepContent(NowTimeLinePos), false);

        Hot.Data_.Save();
    }

    public void NextTurn()
    {
        Data.NowTimeLinePos -= Data.NowSpeed;

        if (Data.NowTimeLinePos < 0)
        {
            Data.NowTimeLinePos = 0;
        }

        transform.SetParent(Hot.PanelBarExpeditionTimeLine_.GetContentStepContent(Data.NowTimeLinePos), false);
    }
}
