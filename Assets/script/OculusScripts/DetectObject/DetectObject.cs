using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectObject : MonoBehaviour
{
    //此腳本給一般物件使用，不能給海神廟牌坊、文昌閣牌坊使用
    private XRGrabInteractable GameObject;

    string cache; //快取
    public bool inCollider;
    private void Start()
    {
        GameObject = GetComponent<XRGrabInteractable>();
        inCollider = false;
        cache = tag;
    }
    private void OnTriggerEnter(Collider other)
    {
        //當地板碰到物件
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default");//把GameObject的layer設為Default            
            this.tag = "Untagged"; //如果碰到terrain或建築物的底部就把自身的tag改成Untagged
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //當物件離開地板
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default", "Socket");//把GameObject的layer設為Default跟Socket
            //this.tag = "Sugar";//如果離開terrain或建築物的底部就把自身的tag改成Sugar
            this.tag = cache;
        }
    }

}
