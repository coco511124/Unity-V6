using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectObject : MonoBehaviour
{
    private XRGrabInteractable GameObject;


    public bool inCollider;
    private void Start()
    {
        GameObject = GetComponent<XRGrabInteractable>();
        inCollider = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default");//��GameObject��layer�]��Default
            this.tag = "Untagged"; //�p�G�I��terrain�Ϋؿv���������N��ۨ���tag�令Untagged
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default", "Socket");//��GameObject��layer�]��Default��Socket
            this.tag = "Sugar";//�p�G���}terrain�Ϋؿv���������N��ۨ���tag�令Sugar
        }
    }

}
