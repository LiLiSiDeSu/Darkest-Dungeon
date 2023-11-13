using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMapEditor : PanelBase
{
    public Transform MapEditorContent;

    public InputField IptFileName;
    public InputField IptWidth;
    public InputField IptHeight;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnGenerate":
                // IptFilename.text != ""
                if (IptWidth.text != "" && IptHeight.text != "")
                {

                }
                break;
            case "BtnSave":
                break;
            case "BtnFolder":
                break;
        }
    }    

    protected override void Awake()
    {
        base.Awake();        

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelMapEditor") &&                
                key == Hot.MgrInput_.AddMapSize && MapEditorContent.localScale.x < 2f)
            {
                MapEditorContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelMapEditor") &&                
                key == Hot.MgrInput_.ReduceMapSize && MapEditorContent.localScale.x > 1f)
            {
                MapEditorContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        IptFileName = transform.FindSonSonSon("IptFileName").GetComponent<InputField>();
        IptWidth = transform.FindSonSonSon("IptWidth").GetComponent<InputField>();
        IptHeight = transform.FindSonSonSon("IptHeight").GetComponent<InputField>();

        transform.FindSonSonSon("ImgSave").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGenerate").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgFolder").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }    
}
