using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColorOrTag : MonoBehaviour
{
    public void changeColor()                                   //�z�LSugarTable��Enent�q��quest2�����C��
    {
        Text text = GetComponent<Text>();
        text.text = "<color=green>2.�M��̽�</color>";
    }
    public void changePlayerTag()                              //�z�LSugarTable��Enent�q�����a(XROrigin)�����C��
    {
        //GameObject gameObject = GetComponent<>();
        gameObject.tag = "PlayerWithSugar";
    }
}
