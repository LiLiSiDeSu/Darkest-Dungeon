using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicContentStepForPanelCellRole : ContentStep
{
    public Transform DependentObjRoot;
    public GameObject RootDetectionArea;
    public int Index;

    public void Init(int index)
    {
        DependentObjRoot = transform.FindSonSonSon("DependentObjRoot");
        RootDetectionArea = transform.FindSonSonSon("RootDetectionArea").gameObject;
        transform.FindSonSonSon("DetectionAreaUp").GetComponent<DetectionArea>().e_ArrowDirection = E_ArrowDirection.Up;
        transform.FindSonSonSon("DetectionAreaDown").GetComponent<DetectionArea>().e_ArrowDirection = E_ArrowDirection.Down;
        Index = index;
        transform.FindSonSonSon("DetectionAreaUp").GetComponent<DetectionArea>().Index = index;
        transform.FindSonSonSon("DetectionAreaDown").GetComponent<DetectionArea>().Index = index;

        RootDetectionArea.gameObject.SetActive(false);
    }

    public void SetRootDetectionAreaActive(bool active)
    {
        RootDetectionArea.gameObject.SetActive(active);
    }

    public void SetIndex(int index)
    {
        Index = index;
        transform.FindSonSonSon("DetectionAreaUp").GetComponent<DetectionArea>().Index = index;
        transform.FindSonSonSon("DetectionAreaDown").GetComponent<DetectionArea>().Index = index;
    }
}
