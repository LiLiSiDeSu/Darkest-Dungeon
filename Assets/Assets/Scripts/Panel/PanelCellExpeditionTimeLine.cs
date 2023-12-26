using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionTimeLine : PanelBaseCell
{
    public Image ImgStatus;
    public Image ImgRolePortrait;

    public PanelCellExpeditionRoom CellExpeditionRoom;

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
                if (Hot.ChoseCellExpeditionRoom == null)
                {
                    Hot.ChoseCellExpeditionRoom = CellExpeditionRoom;
                    Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                    Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole);
                    Hot.ChoseCellExpeditionRoom.UpdateImgStatus(false);

                    return;
                }
                if (Hot.ChoseCellExpeditionRoom == CellExpeditionRoom && Hot.UpdateOver)
                {
                    Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
                    Hot.ChoseCellExpeditionRoom = null;
                    Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(-1);
                    Hot.PanelExpeditionRoom_.ClearMoveStaus();

                    return;
                }
                if (Hot.ChoseCellExpeditionRoom != CellExpeditionRoom && Hot.UpdateOver)
                {
                    Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
                    Hot.PanelExpeditionRoom_.ClearMoveStaus();
                    Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(-1);
                    Hot.ChoseCellExpeditionRoom = CellExpeditionRoom;
                    Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole);
                    Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                    Hot.ChoseCellExpeditionRoom.UpdateImgStatus(false);

                    return;
                }
                break;
        }
    }

    public void Init(int p_Index, PanelCellExpeditionRoom p_CellExpeditionRoom, Transform p_Fahter)
    {
        Index = p_Index;

        CellExpeditionRoom = p_CellExpeditionRoom;
        CellExpeditionRoom.CellTimeLine = this;

        transform.SetParent(p_Fahter, false);

        if (p_CellExpeditionRoom.RootGrid.Data.IndexListRole != -1)
        {
            E_RoleName e_RoleName = Hot.DataNowCellGameArchive.ListRole[p_CellExpeditionRoom.RootGrid.Data.IndexListRole].e_RoleName;
            ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + e_RoleName.ToString());
        }
        else
        {
            E_RoleName e_RoleName = p_CellExpeditionRoom.RootGrid.Data.OtherRole.e_RoleName;
            ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + e_RoleName.ToString());
        }
        
    }
}
