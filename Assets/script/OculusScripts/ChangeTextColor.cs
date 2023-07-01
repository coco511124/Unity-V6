using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{
    [SerializeField] private GameObject sugarTable;
    private void Start()
    {
        SugarSpawnSpot changeColorTag = sugarTable.GetComponent<SugarSpawnSpot>();        
        changeColorTag.changeColor += ChangeColorTag_changeColor;
    }

    private void ChangeColorTag_changeColor(object sender, System.EventArgs e)
    {
        changeColor();
    }
    
    public void changeColor()                                   //�z�LSugarTable��Enent�q��quest2�����C��
    {
        Text text = GetComponent<Text>();
        text.text = "<color=green>2.�M��̽�</color>";
    }
    
}
