using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSomeHint : MonoBehaviour
{
    [SerializeField] private GameObject RouteCanvas;


    //�I���鱵Ĳ�쪱�a����A�N�}�Ҵ���
    void OnTriggerEnter(Collider other)
    {
        RouteCanvas.SetActive(true);
    }
}
