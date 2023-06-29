using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public GameObject PL, Objects;
    [SerializeField] private Text Mission2;
    

    public void changeOblectTag()
    {      
        PL.tag = "PlayerWithSugar";
        Mission2.text = "<color=green>2.尋找甘蔗</color>";
        BackColor();
    }
    public void ChangeColor()
    {
        Objects.GetComponent<TestGlowCollider>().setMaterialChange();
    }
    public void BackColor()
    {
        Objects.GetComponent<TestGlowCollider>().setMaterialOrigin();
    }
}
