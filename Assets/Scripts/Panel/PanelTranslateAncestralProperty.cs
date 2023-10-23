using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PanelTranslateAncestralProperty : PanelBase
{
    private List<E_SpriteNameAncestralProperty> ListBtnStatus = new List<E_SpriteNameAncestralProperty>() 
    {
        E_SpriteNameAncestralProperty.ResAncestralPropertyStatue,
        E_SpriteNameAncestralProperty.ResAncestralPropertyDeed,
        E_SpriteNameAncestralProperty.ResAncestralPropertyPicture,
        E_SpriteNameAncestralProperty.ResAncestralPropertyBadge,
        E_SpriteNameAncestralProperty.ResAncestralPropertyCrystal
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
            case E_SpriteNameAncestralProperty.ResAncestralPropertyStatue:
                switch (ListBtnStatus[index])
                {
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyDeed:
                        if (Hot.DataPanelResTable.NowStatue > Hot.DataPanelResTable.RateStatueToDeed)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.DataPanelResTable.RateStatueToDeed;
                            Hot.DataPanelResTable.NowDeed += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyPicture:
                        if (Hot.DataPanelResTable.NowStatue > Hot.DataPanelResTable.RateStatueToPicture)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.DataPanelResTable.RateStatueToPicture;
                            Hot.DataPanelResTable.NowPicture += 1;

                        }
                        break;                    
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyCrystal:
                        if (Hot.DataPanelResTable.NowStatue > Hot.DataPanelResTable.RateStatueToCrystal)
                        {
                            Hot.DataPanelResTable.NowStatue -= Hot.DataPanelResTable.RateStatueToCrystal;
                            Hot.DataPanelResTable.NowCrystal += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyBadge:
                        if (Hot.DataPanelResTable.NowStatue > 0)
                        {
                            Hot.DataPanelResTable.NowStatue -= 1;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RateStatueToBadge;
                        }
                        break;
                }
                break;
            case E_SpriteNameAncestralProperty.ResAncestralPropertyDeed:
                switch (ListBtnStatus[index])
                {
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyCrystal:
                        if (Hot.DataPanelResTable.NowDeed > Hot.DataPanelResTable.RateDeedToCrystal)
                        {
                            Hot.DataPanelResTable.NowDeed -= Hot.DataPanelResTable.RateDeedToCrystal;
                            Hot.DataPanelResTable.NowCrystal += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyStatue:
                        if (Hot.DataPanelResTable.NowDeed > 0)
                        {
                            Hot.DataPanelResTable.NowDeed -= 1;
                            Hot.DataPanelResTable.NowStatue += Hot.DataPanelResTable.RateStatueToDeed;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyPicture:
                        if (Hot.DataPanelResTable.NowDeed > 0)
                        {
                            Hot.DataPanelResTable.NowDeed -= 1;
                            Hot.DataPanelResTable.NowPicture += Hot.DataPanelResTable.RateDeedToPicture;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyBadge:
                        if (Hot.DataPanelResTable.NowDeed > 0)
                        {
                            Hot.DataPanelResTable.NowDeed -= 1;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RateDeedToBadge;
                        }
                        break;
                }
                break;
            case E_SpriteNameAncestralProperty.ResAncestralPropertyPicture:
                switch (ListBtnStatus[index])
                {
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyDeed:
                        if (Hot.DataPanelResTable.NowPicture > Hot.DataPanelResTable.RateDeedToPicture)
                        {
                            Hot.DataPanelResTable.NowPicture -= Hot.DataPanelResTable.RateDeedToPicture;
                            Hot.DataPanelResTable.NowDeed += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyCrystal:
                        if (Hot.DataPanelResTable.NowPicture > Hot.DataPanelResTable.RatePictureToCrystal)
                        {
                            Hot.DataPanelResTable.NowPicture -= Hot.DataPanelResTable.RatePictureToCrystal;
                            Hot.DataPanelResTable.NowCrystal += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyStatue:
                        if (Hot.DataPanelResTable.NowPicture > 0)
                        {
                            Hot.DataPanelResTable.NowPicture -= 1;
                            Hot.DataPanelResTable.NowStatue += Hot.DataPanelResTable.RateStatueToPicture;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyBadge:
                        if (Hot.DataPanelResTable.NowPicture > 0)
                        {
                            Hot.DataPanelResTable.NowPicture -= 1;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RatePictureToBadge;
                        }
                        break;
                }
                break;
            case E_SpriteNameAncestralProperty.ResAncestralPropertyBadge:
                switch (ListBtnStatus[index])
                {
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyStatue:
                        if (Hot.DataPanelResTable.NowBadge > Hot.DataPanelResTable.RateStatueToBadge)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RateStatueToBadge;
                            Hot.DataPanelResTable.NowStatue += 1;
                        }                        
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyDeed:
                        if (Hot.DataPanelResTable.NowBadge > Hot.DataPanelResTable.RateDeedToBadge)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RateDeedToBadge;
                            Hot.DataPanelResTable.NowDeed += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyPicture:
                        if (Hot.DataPanelResTable.NowBadge > Hot.DataPanelResTable.RatePictureToBadge)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RatePictureToBadge;
                            Hot.DataPanelResTable.NowPicture += 1;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyCrystal:
                        if (Hot.DataPanelResTable.NowBadge > Hot.DataPanelResTable.RateBadgeToCrystal)
                        {
                            Hot.DataPanelResTable.NowBadge -= Hot.DataPanelResTable.RateBadgeToCrystal;
                            Hot.DataPanelResTable.NowCrystal += 1;
                        }
                        break;
                }
                break;
            case E_SpriteNameAncestralProperty.ResAncestralPropertyCrystal:
                switch (ListBtnStatus[index])
                {
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyStatue:
                        if (Hot.DataPanelResTable.NowCrystal > 0)
                        {
                            Hot.DataPanelResTable.NowCrystal -= 1;
                            Hot.DataPanelResTable.NowStatue += Hot.DataPanelResTable.RateStatueToCrystal;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyDeed:
                        if (Hot.DataPanelResTable.NowCrystal > 0)
                        {
                            Hot.DataPanelResTable.NowCrystal -= 1;
                            Hot.DataPanelResTable.NowDeed += Hot.DataPanelResTable.RateDeedToCrystal;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyPicture:
                        if (Hot.DataPanelResTable.NowCrystal > 0)
                        {
                            Hot.DataPanelResTable.NowCrystal -= 1;
                            Hot.DataPanelResTable.NowPicture += Hot.DataPanelResTable.RatePictureToCrystal;
                        }
                        break;
                    case E_SpriteNameAncestralProperty.ResAncestralPropertyBadge:
                        if (Hot.DataPanelResTable.NowCrystal > 0)
                        {
                            Hot.DataPanelResTable.NowCrystal -= 1;
                            Hot.DataPanelResTable.NowBadge += Hot.DataPanelResTable.RateBadgeToCrystal;
                        }
                        break;
                }
                break;
        }

        Hot.PanelOtherResTable_.UpdateInfo();
        Hot.Data_.Save();
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
        Img0.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + ListBtnStatus[0].ToString());
        Img1.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + ListBtnStatus[1].ToString());
        Img2.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + ListBtnStatus[2].ToString());
        Img3.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + ListBtnStatus[3].ToString());
        Img4.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + ListBtnStatus[4].ToString());
    }
}
