using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoleCanDrag : PanelBase, 
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform Father;
    public PanelCellRole PanelCellRole_;
    private Vector2 DragOffSet;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":
                Debug.Log("cao");
                break;
        }
    }

    #region EventSystem接口实现

    public void OnBeginDrag(PointerEventData eventData)
    {        
        transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().raycastTarget = false;
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        transform.SetParent(Hot.PanelBarExpedition_.transform, false);
        Hot.DragingRolePortrait = gameObject;        
    }

    public void OnDrag(PointerEventData eventData)
    {        
        gameObject.transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>().raycastTarget = true;
        
        if (Hot.e_NowPointerLocation != E_NowPointerLocation.TownExpedition)
        {
            Destroy(gameObject);
            Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition = -1;
        }        
        else
        {
            if (Hot.NowRootExpeditionRole != null)
            {
                if (Hot.NowRootExpeditionRole.transform.childCount != 0)
                {
                    Hot.ReplaceRolePortrait = Hot.NowRootExpeditionRole.GetComponentInChildren<PanelCellRoleCanDrag>().gameObject;
                    Hot.ReplaceRolePortrait.transform.SetParent(Father);
                    transform.SetParent(Hot.NowRootExpeditionRole.transform, false);

                    Hot.ReplaceRolePortrait.transform.localPosition = Vector3.zero;
                    transform.localPosition = Vector3.zero;

                    Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", "")));
                    Hot.DataNowCellGameArchive.ListCellRole
                        [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Father.name.Replace("RootExpeditionRole", "")));

                    Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRoleCanDrag>().Father = Father;                    
                }
                else
                {
                    transform.SetParent(Hot.NowRootExpeditionRole.transform, false);
                    Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", "")));
                    transform.localPosition = Vector3.zero;
                }

                Father = Hot.NowRootExpeditionRole.transform;
            }
            else
            {
                transform.SetParent(Father, false);
                transform.localPosition = Vector3.zero;
            }
        }        

        Hot.DragingRolePortrait = null;
        Hot.ReplaceRolePortrait = null;
        Hot.NowRootExpeditionRole = null;                
        

        Hot.Data_.Save();
    }

    #endregion
}
