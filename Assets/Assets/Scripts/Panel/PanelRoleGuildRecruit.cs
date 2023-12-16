using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelRoleGuildRecruit : PanelBaseDynamicScrollView
{        
    protected override void Awake()
    {
        base.Awake();
        
        Content = transform.FindSonSonSon("RecruitContent");
    }

    #region EventSystem接口实现

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelRoleGuildRecruit;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
    }

    #endregion

    public override void InitContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListRoleRecruit.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellRoleRecruit>
            (false, "/PanelCellRoleRecruit",
            (panel) =>
            {
                panel.Index = tempi;
                panel.e_RoleLocation = E_RoleLocation.GuildRecruit;

                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepFor" + panel.PrefabsDynamicContentStepSuffix);
                obj.name = tempi.ToString();
                obj.transform.SetParent(Content, false);
                obj.GetComponent<DynamicContentStep>().Init(tempi);
                panel.transform.SetParent(obj.GetComponent<DynamicContentStep>().DependentObjRoot, false);
                ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStep>());

                panel.ImgRolePortrait.sprite =  
                    Hot.MgrRes_.Load<Sprite>("Art/Portrait" + Hot.DataNowCellGameArchive.ListRoleRecruit[tempi].Role.e_RoleName);
            });

            NowIndex++;
        }
    }

    public override void Clear()
    {
        for(int i = 0; i < Content.childCount; i++)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
    }   

    public override void SortContent()
    {
        DynamicContentStep[] allDynamicContentStep = transform.GetComponentsInChildren<DynamicContentStep>();
        List<DynamicContentStep> tempList = new();
        for (int i = 0; i < allDynamicContentStep.Length; i++)
        {
            tempList.Add(allDynamicContentStep[i]);
            tempList[i].SetIndex(i);
            tempList[i].gameObject.name = i.ToString();
        }
        ListDynamicContentStep = tempList;

        PanelCellRoleRecruit[] all = transform.GetComponentsInChildren<PanelCellRoleRecruit>();
        List<DataContainer_CellRoleRecruit> tempData = new();
        for (int i = 0; i < all.Length; i++)
        {
            tempData.Add(Hot.DataNowCellGameArchive.ListRoleRecruit[all[i].Index]);
            all[i].Index = i;
        }
        Hot.DataNowCellGameArchive.ListRoleRecruit = tempData;

        Hot.Data_.Save();
    }
}
