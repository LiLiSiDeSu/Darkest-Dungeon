using UnityEngine;
using UnityEngine.EventSystems;

public class PanelCellRoleConfig : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelGridRoleConfig RootGrid;

    public E_RoleName e_RoleName = E_RoleName.None;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellRoleConfig":
                if (Hot.ChoseCellRoleConfig == null && e_RoleName != E_RoleName.None)
                {
                    Hot.ChoseCellRoleConfig = this;
                    Hot.ChoseCellRoleConfig.ImgStatus.sprite = Hot.MgrRes_.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                    Hot.ChoseCellRoleConfig.ImgItem.raycastTarget = false;
                }
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterCellRoleConfig = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterCellRoleConfig = null;
    }

    #endregion

    public void Init(E_RoleName p_e_RoleName, PanelGridRoleConfig p_RootGrid)
    {
        e_RoleName = p_e_RoleName;
        RootGrid = p_RootGrid;

        transform.SetParent(Hot.PanelOtherEditorRoleConfig_.ItemRoot[RootGrid.Y][RootGrid.X].transform, false);
        transform.localPosition = new(-20, 20);

        if (e_RoleName != E_RoleName.None)
        {
            ImgItem.sprite = Hot.MgrRes_.LoadSprite("Role" + e_RoleName + E_RoleAction.Await);
        }
        else
        {
            ImgItem.sprite = Hot.MgrRes_.LoadSprite("CellRoleSkillArea");
        }

        ChangeRoomSize();
    }

    public void ChangeRoomSize()
    {
        if (e_RoleName != E_RoleName.None)
        {
            ImgItem.GetComponent<RectTransform>().sizeDelta =
                new(Hot.DicRoleConfig[e_RoleName].SizeBody.X * Hot.BodySizeCellMinimap.X, Hot.DicRoleConfig[e_RoleName].SizeBody.Y * Hot.BodySizeCellMinimap.Y);
            ImgStatus.GetComponent<RectTransform>().sizeDelta =
                new(Hot.DicRoleConfig[e_RoleName].SizeBody.X * Hot.BodySizeCellMinimap.X, Hot.DicRoleConfig[e_RoleName].SizeBody.Y * Hot.BodySizeCellMinimap.Y);
        }
        else
        {
            ImgItem.GetComponent<RectTransform>().sizeDelta = new(Hot.BodySizeCellMinimap.X, Hot.BodySizeCellMinimap.Y);
            ImgStatus.GetComponent<RectTransform>().sizeDelta = new(Hot.BodySizeCellMinimap.X, Hot.BodySizeCellMinimap.Y);
        }
    }
}
