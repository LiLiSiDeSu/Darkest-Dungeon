using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoleExpedition : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public bool IsPut;
    public int IndexRoleList;
    public Image ImgRolePortrait;
    public PanelCellExpeditionRoom RoleObj;

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
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
                Debug.Log("Cao");
                break;
        }
    }

    public void Init(int p_IndexRoleList, Transform p_father)
    {
        transform.SetParent(p_father, false);
        IndexRoleList = p_IndexRoleList;
        ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + Hot.DataNowCellGameArchive.RoleList[IndexRoleList].e_RoleName.ToString());
    }
}
