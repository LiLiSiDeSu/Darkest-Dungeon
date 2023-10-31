using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelRoleGuildRecruit : PanelBase
{
    public int NowIndex;
    public Transform RecruitContent;

    protected override void Awake()
    {
        base.Awake();
        
        RecruitContent = transform.FindSonSonSon("RecruitContent");
    }

    public void InitContent()
    {
        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellRoleRecruit.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellRoleRecruit>(false, "/PanelCellRoleRecruit", 
            (panel) =>
            {
                panel.transform.SetParent(RecruitContent, false);
                panel.Index = tempi;
                panel.Init();
            });

            NowIndex++;
        }
    }

    public void Clear()
    {
        for(int i = 0; i < RecruitContent.childCount; i++)
        {
            Destroy(RecruitContent.GetChild(i).gameObject);
        }
    }

    public void RemoveRole(GameObject obj)
    {        
        DestroyImmediate(obj);
        NowIndex--;        

        Hot.Data_.Save();
    }

    public void SortContent()
    {
        List<DataContainer_CellRoleRecruit> data = new List<DataContainer_CellRoleRecruit>();
        PanelCellRoleRecruit[] all = transform.GetComponentsInChildren<PanelCellRoleRecruit>();
        for (int i = 0; i < all.Length; i++)
        {            
            data.Add(Hot.DataNowCellGameArchive.ListCellRoleRecruit[all[i].Index]);
            all[i].Index = i;
        }
        Hot.DataNowCellGameArchive.ListCellRoleRecruit = data;

        Hot.Data_.Save();
    }
}
