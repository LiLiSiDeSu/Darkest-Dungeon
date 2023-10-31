using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelRoleList : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    private bool IsOpen = true;

    public int NowIndex;    
    public List<GameObject> ListContentStep = new();

    public GameObject ScrollView_;
    public GameObject BtnPackUp;
    public GameObject BtnOpen;
    public Transform ImgDecorateFrameTop;
    public Transform ImgDecorateFrameBottom;
    public Image ImgPackUp;
    public Image ImgOpen;

    public Transform RoleContent;    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.PanelRole && Hot.NowIndexCellGameArchive != -1)
            {

                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelRoleList"))
                    Hot.MgrUI_.HidePanel(false, Hot.PanelRoleList_.gameObject, "PanelRoleList");
                else
                    Hot.MgrUI_.ShowPanel<PanelRoleList>(true, "PanelRoleList");
            }
        });

        ScrollView_ = transform.FindSonSonSon("ScrollView_").gameObject;
        BtnPackUp = transform.FindSonSonSon("BtnPackUp").gameObject;
        BtnOpen = transform.FindSonSonSon("BtnOpen").gameObject;
        ImgDecorateFrameTop = transform.FindSonSonSon("ImgDecorateFrameTop");
        ImgDecorateFrameBottom = transform.FindSonSonSon("ImgDecorateFrameBottom");
        ImgPackUp = transform.FindSonSonSon("ImgPackUp").GetComponent<Image>();
        ImgOpen = transform.FindSonSonSon("ImgOpen").GetComponent<Image>();
        ImgPackUp.alphaHitTestMinimumThreshold = 0.2f;
        ImgOpen.alphaHitTestMinimumThreshold = 0.2f;

        RoleContent = transform.FindSonSonSon("RoleContent");

        BtnOpen.SetActive(false);
    }

    #region EventSystem接口实现、

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelRoleList;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnPackUp":
                IsOpen = false;                
                BtnPackUp.SetActive(false);
                BtnOpen.SetActive(true);
                ScrollView_.SetActive(false);
                ChangePosImgDecorateFrameBottom();
                break;
            case "BtnOpen":
                IsOpen = true;
                BtnPackUp.SetActive(true);
                BtnOpen.SetActive(false);
                ScrollView_.SetActive(true);
                ChangePosImgDecorateFrameBottom();
                break;
        }
    }

    public void InitContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellRole.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellRole>
            (false, "/PanelCellRole", 
            (panel) =>
            {
                panel.Index = NowIndex;
                panel.CreatePanelCellRoleCanDrag();
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj.name = tempi.ToString();
                obj.transform.SetParent(RoleContent, false);
                panel.transform.SetParent(obj.transform, false);
                ListContentStep.Add(obj);
                panel.InitInfo();                
                NowIndex++;
            });
        }
    }

    public void Clear()
    {
        ContentStep[] all = RoleContent.GetComponentsInChildren<ContentStep>();
        for (int i = 0; i < all.Length; i++)
        {
            DestroyImmediate(all[i].gameObject);
        }        
    }

    public void SortContent()
    {

    }

    public PanelCellRole GetCellRole()
    {
        return null;
    }

    public void ChangePosPanelCellRole(int sourece, int replace)
    {
        
    }

    private void ChangePosImgDecorateFrameBottom()
    {
        if (IsOpen && ListContentStep.Count > 0)
            ImgDecorateFrameBottom.transform.localPosition =
                new Vector3(ImgDecorateFrameBottom.transform.localPosition.x, -445, 0);
        else
            ImgDecorateFrameBottom.transform.position =
                new Vector3(ImgDecorateFrameBottom.transform.position.x,
                ImgDecorateFrameTop.position.y - 40,
                0);
    }    

    public void AddRole(DataContainer_CellRole role)
    {
        Hot.DataNowCellGameArchive.ListCellRole.Add(role);

        Hot.MgrUI_.CreatePanel<PanelCellRole>
            (false, "/PanelCellRole",
            (panel) =>
            {
                panel.Index = NowIndex;
                panel.CreatePanelCellRoleCanDrag();
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj.name = NowIndex.ToString();
                obj.transform.SetParent(RoleContent, false);
                panel.transform.SetParent(obj.transform, false);
                ListContentStep.Add(obj);
                panel.InitInfo();
                NowIndex++;
            });        

        Hot.Data_.Save();
    }

    public void RemoveRole(int index, GameObject obj)
    {

    }
}
