using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionRole : PanelBaseCell,
             IPointerEnterHandler, IPointerExitHandler
{
    public int IndexRole;

    public Image ImgRolePortrait;
    public Image ImgBanner;

    public PanelCellExpeditionRoom CellExpeditionRoom;

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
        ImgBanner = transform.FindSonSonSon("ImgBanner").GetComponent<Image>();
        ImgBanner.gameObject.SetActive(false);
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImgRolePortrait.transform.localPosition = new(0, -20);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImgRolePortrait.transform.localPosition = new(0, 0);
    }

    #endregion

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

    public void Init(int p_Index, int p_IndexRoleList, Transform p_father)
    {
        transform.SetParent(p_father, false);
        Index = p_Index;
        IndexRole = p_IndexRoleList;
        ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + Hot.DataNowCellGameArchive.ListRole[IndexRole].e_RoleName.ToString());
    }
}
