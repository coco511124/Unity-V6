using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public GameObject PL, Objects;
    [SerializeField] private Text Mission2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand"){
            Objects.SetActive(false);
            PL.tag = "PlayerWithSugar";
            Mission2.text = "<color=green>1.前往黃色驚嘆號 ✓</color>";
        }
    }
}
