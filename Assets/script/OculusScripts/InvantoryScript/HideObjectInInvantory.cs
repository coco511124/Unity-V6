using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HideObjectInInvantory : MonoBehaviour
{
    //Show�X�Ӫ����
    public Image artStuff;
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    //���s�����
    private Sprite artStuff_Cache;
    private string titleText_Cache;
    private string descriptionText_Cache;

    public GameObject ParentObject;
    private GameObject setGameObject;


    // Start is called before the first frame update
    void Start()
    {
        setGameObject = null;

        //�Ȧs���@�}�l���]���ŭ�
        artStuff_Cache = null;
        titleText_Cache = null;
        descriptionText_Cache = null;

        InventoryCanvas callOpen = ParentObject.GetComponent<InventoryCanvas>();
        InventoryCanvas callClose = ParentObject.GetComponent<InventoryCanvas>();
        callOpen.callOpenMeshRenderer += CallOpen_callOpenMeshRenderer;
        callClose.callCloseMeshRenderer += CallClose_callCloseMeshRenderer;
    }

    private void CallClose_callCloseMeshRenderer(object sender, System.EventArgs e)
    {
        if (setGameObject == null)
        {
            Debug.Log("������setGameObject�O�ŭ�");
            return;
        }
        else
        {
            setGameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    private void CallOpen_callOpenMeshRenderer(object sender, System.EventArgs e)
    {
        if (setGameObject == null)
        {
            Debug.Log("�}�Ү�setGameObject�O�ŭ�");
            return;
        }
        else
        {
            //GetComponentInChildren
            setGameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            Debug.Log("��V�}�_�ӤF");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")
        {
            Debug.Log("�I�]�t�θI��̽��Τ��F");
            setGameObject = other.gameObject;

            //�q�̽��Τ��W��scriptable Object����ϡB���D�M�y�z
            //�̽���SO��bPickUP�}���A���h�@���SO
            LessonTwoSO localSOinfo = setGameObject.GetComponent<_SOHolder>().SOinfo;

            Sprite artSprite = localSOinfo.artWork; //setGameObject.GetComponent<Image>().sprite;
            string artTitle = localSOinfo.title;    //setGameObject.GetComponent<TMP_Text>().text;
            string artDescription = localSOinfo.description;  //setGameObject.GetComponent<TMP_Text>().text;
            getSpriteDescription(artSprite, artTitle, artDescription);
        }
    }

    public void getSpriteDescription(Sprite image, string title, string description)
    {
        //����쪺�̽��άO���h�@��󪺹Ϥ�(sprite)�B���D(text)�M�y�z(text)
        //�A���Ȧs��Cache
        artStuff_Cache = image;
        titleText_Cache = title;
        descriptionText_Cache = description;
    }


    //��I�]�t�γQhover���ɭԡA�N��s��ܷ�e����Ϥ��B���D�M�y�z
    //��ItemUI���U��Border���󱾸���XR Socket Interactor����Hover Event�I�s
    public void showSpriteDescription()
    {
        Debug.Log("�Qhover�F");
        artStuff.sprite = artStuff_Cache;
        titleText.text = titleText_Cache;
        descriptionText.text = descriptionText_Cache;
    }

}
