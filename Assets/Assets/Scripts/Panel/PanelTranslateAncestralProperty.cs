using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PanelTranslateAncestralProperty : PanelBase
{
    private List<E_AncestralProperty> ListBtnStatus = new List<E_AncestralProperty>() 
    {
        E_AncestralProperty.Statue,
        E_AncestralProperty.Deed,
        E_AncestralProperty.Picture,
        E_AncestralProperty.Badge,
        E_AncestralProperty.Crystal
    };    

    public Image Img0;
    public Image Img1;
    public Image Img2;
    public Image Img3;
    public Image Img4;

    protected override void Awake()
    {
        base.Awake();

        transform.FindSonSonSon("ImgArrowUp").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgArrowDown").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        

        Img0 = transform.FindSonSonSon("Img0").GetComponent<Image>();
        Img1 = transform.FindSonSonSon("Img1").GetComponent<Image>();
        Img2 = transform.FindSonSonSon("Img2").GetComponent<Image>();
        Img3 = transform.FindSonSonSon("Img3").GetComponent<Image>();
        Img4 = transform.FindSonSonSon("Img4").GetComponent<Image>();
        Img0.alphaHitTestMinimumThreshold = 0.2f;
        Img1.alphaHitTestMinimumThreshold = 0.2f;
        Img2.alphaHitTestMinimumThreshold = 0.2f;
        Img3.alphaHitTestMinimumThreshold = 0.2f;
        Img4.alphaHitTestMinimumThreshold = 0.2f;

        UpdateImg();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnArrowUp":
                UpDateBtnStatus(E_ArrowDirection.Up);                
                break;
            case "BtnArrowDown":
                UpDateBtnStatus(E_ArrowDirection.Down);
                break;
            case "Btn0":
                ;
                break;
            case "Btn1":
                Translate(1);                
                break;
            case "Btn2":
                Translate(2);                
                break;
            case "Btn3":
                Translate(3);                
                break;
            case "Btn4":
                Translate(4);                
                break;
        }
    }

    private void Translate(int index)
    {
        switch (ListBtnStatus[0])
        {
            case E_AncestralProperty.Statue:
                switch (ListBtnStatus[index])
                {
                    case E_AncestralProperty.Deed:
                        if (Hot.DataPanelResTable.NowStatue >= Hot.DataPanelResTable.RateStatueToDeed * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.DataPanelResTable.RateStatueToDeed * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowDeed += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        if (Hot.DataPanelResTable.NowStatue >= Hot.DataPanelResTable.RateStatueToPicture * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.DataPanelResTable.RateStatueToPicture * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowPicture += Hot.NowTranslateRate;

                        }
                        break;                    
                    case E_AncestralProperty.Crystal:
                        if (Hot.DataPanelResTable.NowStatue >= Hot.DataPanelResTable.RateStatueToCrystal * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.DataPanelResTable.RateStatueToCrystal * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        if (Hot.DataPanelResTable.NowStatue >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RateStatueToBadge * Hot.NowTranslateRate;
                        }
                        break;
                }
                break;
            case E_AncestralProperty.Deed:
                switch (ListBtnStatus[index])
                {
                    case E_AncestralProperty.Crystal:
                        if (Hot.DataPanelResTable.NowDeed >= Hot.DataPanelResTable.RateDeedToCrystal * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowDeed -= Hot.DataPanelResTable.RateDeedToCrystal * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Statue:
                        if (Hot.DataPanelResTable.NowDeed >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowDeed -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowStatue += Hot.DataPanelResTable.RateStatueToDeed * Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        if (Hot.DataPanelResTable.NowDeed >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowDeed -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowPicture += Hot.DataPanelResTable.RateDeedToPicture * Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        if (Hot.DataPanelResTable.NowDeed >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowDeed -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RateDeedToBadge * Hot.NowTranslateRate;
                        }
                        break;
                }
                break;
            case E_AncestralProperty.Picture:
                switch (ListBtnStatus[index])
                {
                    case E_AncestralProperty.Deed:
                        if (Hot.DataPanelResTable.NowPicture >= Hot.DataPanelResTable.RateDeedToPicture * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowPicture -= Hot.DataPanelResTable.RateDeedToPicture * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowDeed += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Crystal:
                        if (Hot.DataPanelResTable.NowPicture >= Hot.DataPanelResTable.RatePictureToCrystal * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowPicture -= Hot.DataPanelResTable.RatePictureToCrystal * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Statue:
                        if (Hot.DataPanelResTable.NowPicture >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowPicture -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowStatue += Hot.DataPanelResTable.RateStatueToPicture * Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        if (Hot.DataPanelResTable.NowPicture >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowPicture -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RatePictureToBadge * Hot.NowTranslateRate;
                        }
                        break;
                }
                break;
            case E_AncestralProperty.Badge:
                switch (ListBtnStatus[index])
                {
                    case E_AncestralProperty.Statue:
                        if (Hot.DataPanelResTable.NowBadge >= Hot.DataPanelResTable.RateStatueToBadge * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RateStatueToBadge * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowStatue += Hot.NowTranslateRate;
                        }                        
                        break;
                    case E_AncestralProperty.Deed:
                        if (Hot.DataPanelResTable.NowBadge >= Hot.DataPanelResTable.RateDeedToBadge * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RateDeedToBadge * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowDeed += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        if (Hot.DataPanelResTable.NowBadge >= Hot.DataPanelResTable.RatePictureToBadge * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RatePictureToBadge * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowPicture += Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Crystal:
                        if (Hot.DataPanelResTable.NowBadge >= Hot.DataPanelResTable.RateBadgeToCrystal * Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RateBadgeToCrystal * Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                        }
                        break;
                }
                break;
            case E_AncestralProperty.Crystal:
                switch (ListBtnStatus[index])
                {
                    case E_AncestralProperty.Statue:
                        if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowStatue += Hot.DataPanelResTable.RateStatueToCrystal * Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Deed:
                        if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowDeed += Hot.DataPanelResTable.RateDeedToCrystal * Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowPicture += Hot.DataPanelResTable.RatePictureToCrystal * Hot.NowTranslateRate;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                        {
                            Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RateBadgeToCrystal * Hot.NowTranslateRate;
                        }
                        break;
                }
                break;
        }

        Hot.PanelOtherResTable_.UpdateInfo();        
    }

    private void UpDateBtnStatus(E_ArrowDirection e_ArrowDirection)
    {
        switch (e_ArrowDirection)
        {
            case E_ArrowDirection.Up:
                ListBtnStatus.Insert(0, ListBtnStatus[ListBtnStatus.Count - 1]);
                ListBtnStatus.RemoveAt(ListBtnStatus.Count - 1);
                break;
            case E_ArrowDirection.Down:
                ListBtnStatus.Add(ListBtnStatus[0]);
                ListBtnStatus.RemoveAt(0);
                break;            
        }

        UpdateImg();
    }

    private void UpdateImg()
    {
        Img0.sprite = Hot.MgrRes_.Load<Sprite>("Art/ResAncestralProperty" + ListBtnStatus[0].ToString());
        Img1.sprite = Hot.MgrRes_.Load<Sprite>("Art/ResAncestralProperty" + ListBtnStatus[1].ToString());
        Img2.sprite = Hot.MgrRes_.Load<Sprite>("Art/ResAncestralProperty" + ListBtnStatus[2].ToString());
        Img3.sprite = Hot.MgrRes_.Load<Sprite>("Art/ResAncestralProperty" + ListBtnStatus[3].ToString());
        Img4.sprite = Hot.MgrRes_.Load<Sprite>("Art/ResAncestralProperty" + ListBtnStatus[4].ToString());
    }
}
