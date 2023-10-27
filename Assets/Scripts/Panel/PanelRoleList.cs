using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoleList : PanelBase
{
    private bool IsOpen = true;

    public int NowIndex;    
    public List<GameObject> ListContentStep = new List<GameObject>();

    public GameObject ScrollView_;
    public GameObject BtnPackUp;
    public GameObject BtnOpen;
    public Transform ImgDecorateFrameTop;
    public Transform ImgDecorateFrameBottom;
    public Image ImgPackUp;
    public Image ImgOpen;

    public Transform Content;    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.PanelRole && Hot.NowIndexCellGameArchive != -1)
            {

                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelRoleList"))
                {
                    Hot.MgrUI_.HidePanel
                        (false, Hot.PanelRole_.gameObject, "PanelRoleList");
                }
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

        Content = transform.FindSonSonSon("Content");

        BtnOpen.SetActive(false);
    }

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

            Hot.MgrUI_.CreatePanel<PanelCellRole>("/PanelCellRole", 
            (panel) =>
            {
                panel.Index = NowIndex;
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj.name = tempi.ToString();
                obj.transform.SetParent(Content, false);
                panel.transform.SetParent(obj.transform, false);
                ListContentStep.Add(obj);
                panel.InitInfo();                
                NowIndex++;
            });
        }
    }

    public void ClearContent()
    {
        ContentStep[] all = Content.GetComponentsInChildren<ContentStep>();
        for (int i = 0; i < all.Length; i++)
        {
            DestroyImmediate(all[i].gameObject);
        }        
    }

    public void SortContent()
    {

    }

    public void ChangePosPanelCellRole(int Sourece, int Replace)
    {
        
    }

    private void ChangePosImgDecorateFrameBottom()
    {
        if (IsOpen && ListContentStep.Count > 0)
            ImgDecorateFrameBottom.transform.localPosition =
                new Vector3(ImgDecorateFrameBottom.transform.localPosition.x, -367, 0);
        else
            ImgDecorateFrameBottom.transform.position =
                new Vector3(ImgDecorateFrameBottom.transform.position.x,
                ImgDecorateFrameTop.position.y - 40,
                0);
    }
}
