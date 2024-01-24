using UnityEngine;
using UnityEngine.UI;

public class PanelBaseCellVector2 : PanelBaseCell
{
    public Image ImgItem;
    public Image ImgStatus;

    protected override void Awake()
    {
        base.Awake();

        ImgItem = transform.FindSonSonSon("ImgItem").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    public virtual void ChangeCellSize()
    {

    }
}
