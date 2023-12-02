using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ex_Transform
{    
    public static Transform FindSonSonSon(this Transform Father, string SonName)
    {
        Transform target = null;

        target = Father.Find(SonName);
        if (target != null)
            return target;

        for (int i = 0; i < Father.childCount; i++)
        {
            target = Father.GetChild(i).FindSonSonSon(SonName);
            if (target != null)
                return target;
        }

        return null;
    }
}
