using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameTools : BaseEditorGUIExtension<LatoutForGameTools>
{    
    public static int AddTranslateNum = 4;    
    public static int NowTranslateNum = 1;

    [MenuItem("-Tools-/GmaeTools/AddRes #&%_4", false, 1)]
    public static void ShowWindow()
    {
        GameTools GameTools_ = GetWindow<GameTools>();
        GameTools_.Show();

        layout.Style_AddTranslateNumTitle.fontSize = 15;        
        layout.Style_AddTranslateNum.fontSize = 15;
        layout.Style_AddTranslateNum.normal.textColor = Color.red;
        layout.Style_AddStoreDebris.fontSize = 15;
        layout.Style_AddBadge.fontSize = 15;
        layout.Style_AddStatue.fontSize = 15;
        layout.Style_AddPicture.fontSize = 15;
        layout.Style_AddDeed.fontSize = 15;
        layout.Style_AddCrystal.fontSize = 15;        
        layout.Style_AddCopper.fontSize = 15;
        layout.Style_AddSilver.fontSize = 15;
        layout.Style_AddGold.fontSize = 15;
        layout.Style_AddPlatinum.fontSize = 15;

        layout.Texture_Pic1 = Hot.MgrRes_.Load<Texture>("Art/Editor/" + "ToolsGameToolsBk1");
        layout.Texture_Pic2 = Hot.MgrRes_.Load<Texture>("Art/Editor/" + "ToolsGameToolsBk2");
        layout.Texture_Pic3 = Hot.MgrRes_.Load<Texture>("Art/BarBlack2");
        DestroyImmediate(Hot.MgrRes_.gameObject);
    }

    private void OnGUI()
    {
        if (!Application.isPlaying)
            Close();

        GUI.DrawTexture(layout.Rect_Pic1, layout.Texture_Pic1);
        GUI.DrawTexture(layout.Rect_Pic2, layout.Texture_Pic2);
        GUI.DrawTexture(layout.Rect_Pic3, layout.Texture_Pic3);

        GUI.Label(layout.Rect_AddTranslateNumTitle, layout.String_AddTranslateNumTitle, layout.Style_AddTranslateNumTitle);

        layout.String_AddTranslateNum = 
            GUI.TextField(layout.Rect_AddTranslateNum, layout.String_AddTranslateNum, layout.Style_AddTranslateNum);

        if (GUI.Button(layout.Rect_AddStoreDebris, layout.String_AddStoreDebris, layout.Style_AddStoreDebris))
        {
            Hot.DataPanelResTable.NowStoreDebris += int.Parse(layout.String_AddTranslateNum);            
        }
        if (GUI.Button(layout.Rect_AddBadge, layout.String_AddBadge, layout.Style_AddBadge))
        {
            Hot.DataPanelResTable.NowBadge += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelBadge += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddStatue, layout.String_AddStatue, layout.Style_AddStatue))
        {
            Hot.DataPanelResTable.NowStatue += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelStatue += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddPicture, layout.String_AddPicture, layout.Style_AddPicture))
        {
            Hot.DataPanelResTable.NowPicture += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelPicture += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddDeed, layout.String_AddDeed, layout.Style_AddDeed))
        {
            Hot.DataPanelResTable.NowDeed += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelDeed += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddCrystal, layout.String_AddCrystal, layout.Style_AddCrystal))
        {
            Hot.DataPanelResTable.NowCrystal += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelCrystal += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddCopper, layout.String_AddCopper, layout.Style_AddCopper))
        {
            Hot.DataPanelResTable.NowCopper += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelCopper += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddSilver, layout.String_AddSilver, layout.Style_AddSilver))
        {
            Hot.DataPanelResTable.NowSilver += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelSilver += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddGold, layout.String_AddGold, layout.Style_AddGold))
        {
            Hot.DataPanelResTable.NowGold += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelGold += int.Parse(layout.String_AddTranslateNum);
        }
        if (GUI.Button(layout.Rect_AddPlatinum, layout.String_AddPlatinum, layout.Style_AddPlatinum))
        {
            Hot.DataPanelResTable.NowPlatinum += int.Parse(layout.String_AddTranslateNum);
            Hot.DataPanelResTable.NowLevelPlatinum += int.Parse(layout.String_AddTranslateNum);
        }              

        Hot.PanelOtherResTable_.UpdateInfo();

        Repaint();
    }
}
