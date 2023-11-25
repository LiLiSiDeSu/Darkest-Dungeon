using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutForPanelNews : MonoBehaviour
{
    public string String_PoolEsc = "PoolEsc";
    public Rect Rect_PoolEsc = new Rect(0, 0, 0 ,0);
    public GUIStyle Style_PoolEsc = new GUIStyle();

    public string String_PoolNowPanel = "PoolNowPanel";
    public Rect Rect_PoolNowPanel = new Rect(270, 0, 0, 0);
    public GUIStyle Style_PoolNowPanel = new GUIStyle();

    public string String_PoolBuffer = "PoolBuffer";
    public Rect Rect_PoolBuffer = new Rect(540, 0, 0, 0);
    public GUIStyle Style_PoolBuffer = new GUIStyle();

    public string String_MgrUI = "MgrUI";
    public Rect Rect_MgrUI = new Rect(810, 0, 0, 0);
    public GUIStyle Style_MgrUI = new GUIStyle();

    public void Refresh()
    {
        if (Application.isPlaying)
        {
            String_PoolEsc = "PoolEsc\n";
            String_PoolNowPanel = "PoolNowPanel\n";
            String_PoolBuffer = "PoolBuffer\n";
            String_MgrUI = "MgrUI\n";

            for (int i = 0; i < PoolEsc.GetInstance().ListEsc.Count; i++)
                String_PoolEsc += i.ToString() + " - " + PoolEsc.GetInstance().ListEsc[i] + "\n";

            for (int i = 0; i < PoolNowPanel.GetInstance().ListNowPanel.Count; i++)
                String_PoolNowPanel += i.ToString() + " - " + PoolNowPanel.GetInstance().ListNowPanel[i] + "\n";

            int i0 = 0;            
            foreach (List<GameObject> value in PoolBuffer.GetInstance().DicPool.Values)
            {
                if (value.Count > 0)
                {
                    String_PoolBuffer += i0.ToString() + " - " + value[0].name + "\n";
                    i0++;
                }
            }

            int i1 = 0;
            foreach (string key in MgrUI.GetInstance().DicPanel.Keys)
            {
                String_MgrUI += i1.ToString() + " - " + key + "\n";
                i1++;
            }
        }
    }
}
