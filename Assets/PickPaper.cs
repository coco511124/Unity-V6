using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPaper : MonoBehaviour
{
    int count;
    public GameObject portal, xrOrigin;

    public void PickUpTimes()
    {
        count++;
        if (count == 5)
        {
            portal.SetActive(true);
            xrOrigin.tag = "pick";
        }
    }
}
