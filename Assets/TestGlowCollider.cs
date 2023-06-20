using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGlowCollider : MonoBehaviour
{
    public Material Material1, Material2;
    public GameObject Grabbles;

    public Text MissionTwo;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Grabbles.GetComponent<MeshRenderer>().material = Material1;
            MissionTwo.text = "2.尋找甘蔗 √";
            MissionTwo.color = Color.green;
            Debug.Log("enter!!!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Grabbles.GetComponent<MeshRenderer>().material = Material2;
            Debug.Log("exit!!!");
        }
    }
}