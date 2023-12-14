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

    private bool DetectObjectInCollider;
    private bool DetectObject_ForImage_StatueInCollider;
    private bool DetectObject_ForBrand_Haishen_InCollider;

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
        if (setGameObject != null)
        {
            setGameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

            List<Transform> children = GetChildren(setGameObject.transform, true);
            foreach (Transform child in children)
            {
                if (child.GetComponent<MeshRenderer>() == true)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    continue;
                }
            }
        }
        else
        {
            Debug.Log("������setGameObject�O�ŭ�");
            return;
        }
    }
    

    private void CallOpen_callOpenMeshRenderer(object sender, System.EventArgs e)
    {
        //Debug.Log(setGameObject.GetComponent<DetectObject>().inCollider);
        //�p�G��������ŦX�H�U����
        //1. null
        //2. DetectObject�}����inCollider��true
        //3. DetectObject_ForImage_Statue�}����inCollider��true
        //4. DetectObject_ForBrand_Haishen_�}����inCollider��true
        getDetectObjectbool(setGameObject);                          //�ǤJsetGameObject����k���P�_�A��bool�ȬOtrue�٬Ofalse
        getDetectObject_ForImage_Statuebool(setGameObject);
        getDetectObject_ForBrand_Haishen_bool(setGameObject);
        if (setGameObject == null || DetectObjectInCollider == true || DetectObject_ForImage_StatueInCollider == true || DetectObject_ForBrand_Haishen_InCollider == true)
        {           
            //Debug.Log("�}�Ү�setGameObject�O�ŭ�");
            return;
        }
        else
        {
            Debug.Log(setGameObject.GetComponent<DetectObject>());   //�|�^��NULL
            //GetComponentInChildren
            setGameObject.GetComponentInChildren<MeshRenderer>().enabled = true;

            List<Transform> children = GetChildren(setGameObject.transform, true);
            foreach (Transform child in children)
            {
                if (child.GetComponent<MeshRenderer>() == true)
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    continue;
                }
            }
            Debug.Log("��V�}�_�ӤF");
        }
    }
    private void getDetectObjectbool(GameObject setGameObject)                        //�P�_�U�Ӫ��󦳨S���b�I����̭��A�b�̭����ܴN�^��true
    {
        if (setGameObject != null && setGameObject.GetComponent<DetectObject>())
        {
            if (setGameObject.GetComponent<DetectObject>().inCollider == true)
            {
                DetectObjectInCollider = true;
            }
            else
            {
                DetectObjectInCollider = false;
            }
        }
        else
        {
            DetectObjectInCollider = false;
        }
    }
    private void getDetectObject_ForImage_Statuebool(GameObject setGameObject)         //�P�_�U�Ӫ��󦳨S���b�I����̭��A�b�̭����ܴN�^��true
    {
        if (setGameObject != null && setGameObject.GetComponent<DetectObject_ForImage_Statue>())
        {
            if (setGameObject.GetComponent<DetectObject_ForImage_Statue>().inCollider == true)
            {
                DetectObject_ForImage_StatueInCollider = true;
            }
            else
            {
                DetectObject_ForImage_StatueInCollider = false;
            }
        }
        else
        {
            DetectObject_ForImage_StatueInCollider = false;
        }
    }
    private void getDetectObject_ForBrand_Haishen_bool(GameObject setGameObject)        //�P�_�U�Ӫ��󦳨S���b�I����̭��A�b�̭����ܴN�^��true
    {
        if (setGameObject != null && setGameObject.GetComponent<DetectObject_ForBrand_Haishen_>())
        {
            if (setGameObject.GetComponent<DetectObject_ForBrand_Haishen_>().inCollider == true)
            {
                DetectObject_ForBrand_Haishen_InCollider = true;
            }
            else
            {
                DetectObject_ForBrand_Haishen_InCollider = false;
            }
        }
        else
        {
            DetectObject_ForBrand_Haishen_InCollider = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")
        {
            setGameObject = null;
            artStuff_Cache = null;
            titleText_Cache = null;
            descriptionText_Cache = null;
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
    List<Transform> GetChildren(Transform parent, bool recursive)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            children.Add(child);
            if (recursive)
            {
                children.AddRange(GetChildren(child, true));
            }
        }
        return children;
    }
}
