using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGlowCollider : MonoBehaviour
{
    public Material Material1, Material2;
    public GameObject Grabbles;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Grabbles.GetComponent<MeshRenderer>().material = Material1;
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