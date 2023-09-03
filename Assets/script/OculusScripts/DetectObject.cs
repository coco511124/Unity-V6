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
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default");//把GameObject的layer設為Default
            this.tag = "Untagged"; //如果碰到terrain或建築物的底部就把自身的tag改成Untagged
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default", "Socket");//把GameObject的layer設為Default跟Socket
            this.tag = "Sugar";//如果離開terrain或建築物的底部就把自身的tag改成Sugar
        }
    }

}
