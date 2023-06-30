using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColorOrTag : MonoBehaviour
{
    public void changeColor()                                   //透過SugarTable的Enent通知quest2改變顏色
    {
        Text text = GetComponent<Text>();
        text.text = "<color=green>2.尋找甘蔗</color>";
    }
    public void changePlayerTag()                              //透過SugarTable的Enent通知玩家(XROrigin)改變顏色
    {
        //GameObject gameObject = GetComponent<>();
        gameObject.tag = "PlayerWithSugar";
    }
}
