using UnityEngine;

public class LayoutForBatchRename : MonoBehaviour
{
    public string String_InputBaseNameTitle = "BaseName: ";
    public Rect Rect_InputBaseNameTitle = new Rect(0, 0, 100, 20);
    public GUIStyle Style_InputBaseNameTitle = new GUIStyle();

    public string String_InputBaseName = "";
    public Rect Rect_InputBaseName = new Rect(110, 0, 100, 20);
    public GUIStyle Style_InputBaseName = new GUIStyle();

    public string String_StartIndexTitle = "StartIndex: ";
    public Rect Rect_StartIndexTitle = new Rect(0, 20, 100, 20);
    public GUIStyle Style_StartIndexTitle = new GUIStyle();

    public string String_InputStartIndex = "0";
    public Rect Rect_InputStartIndex = new Rect(110, 20, 100, 20);
    public GUIStyle Style_InputStartIndex = new GUIStyle();

    public string String_BtnRenameTitle = "Rename";
    public Rect Rect_BtnRename = new Rect(0, 40, 100, 20);
    public GUIStyle Style_BtnRename = new GUIStyle();
}
