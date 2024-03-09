using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectObject : MonoBehaviour
{
    //���}�����@�몫��ϥΡA���൹�����q�P�{�B����յP�{�ϥ�
    private XRGrabInteractable GameObject;

    string cache; //�֨�
    public bool inCollider;

    //�ΨӦs����w��Layer�A�H�Φۨ���Layer
    private int LayerOnly_0_5_8_layer;
    private int LayerSelf;

    private void Awake()
    {
        //gameObject.layer uses only integers, but we can turn a layer name into a layer integer using LayerMask.NameToLayer()
        LayerOnly_0_5_8_layer = LayerMask.NameToLayer("Only_0_5_8_layer");
        LayerSelf = LayerMask.NameToLayer("ObjectNoTouchPlayer");


    }


    private void Start()
    {
        GameObject = GetComponent<XRGrabInteractable>();
        inCollider = false;
        cache = tag;
        //print("");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Border")
        {
            gameObject.layer = LayerOnly_0_5_8_layer;
            Debug.Log("Current layer: " + gameObject.layer);
        }
        
         //��a�O�I�쪫��
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default");//��GameObject��layer�]��Default            
            this.tag = "Untagged"; //�p�G�I��terrain�Ϋؿv���������N��ۨ���tag�令Untagged
        }            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Border")
        {
            gameObject.layer = LayerSelf;
            Debug.Log("Current layer: " + gameObject.layer);
        }
        //�������}�a�O
        if (other.gameObject.tag == "Ground")
        {
            GameObject.interactionLayers = InteractionLayerMask.GetMask("Default", "Socket");//��GameObject��layer�]��Default��Socket
                                                                                             //this.tag = "Sugar";//�p�G���}terrain�Ϋؿv���������N��ۨ���tag�令Sugar
            this.tag = cache;
        }
    }

}
