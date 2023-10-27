using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public GameObject portal;

    public int times = 0;

    public void PickObj()
    {
        times++;
        if (times >= 2)
        {
            portal.SetActive(true);
        }
    }
}
