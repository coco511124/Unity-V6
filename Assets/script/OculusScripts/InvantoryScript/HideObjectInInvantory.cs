using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HideObjectInInvantory : MonoBehaviour
{
    //Show出來的欄位
    public Image artStuff;
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    //佔存的欄位
    private Sprite artStuff_Cache;
    private string titleText_Cache;
    private string descriptionText_Cache;

    public GameObject ParentObject;
    private GameObject setGameObject;


    // Start is called before the first frame update
    void Start()
    {
        setGameObject = null;

        //暫存欄位一開始都設為空值
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
            Debug.Log("關閉時setGameObject是空值");
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
            Debug.Log("開啟時setGameObject是空值");
            return;
        }
        else
        {
            //GetComponentInChildren
            setGameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            Debug.Log("渲染開起來了");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")
        {
            Debug.Log("背包系統碰到甘蔗或文件了");
            setGameObject = other.gameObject;

            //從甘蔗或文件上的scriptable Object抓取圖、標題和描述
            //甘蔗的SO放在PickUP腳本，郭懷一文件的SO
            LessonTwoSO localSOinfo = setGameObject.GetComponent<_SOHolder>().SOinfo;

            Sprite artSprite = localSOinfo.artWork; //setGameObject.GetComponent<Image>().sprite;
            string artTitle = localSOinfo.title;    //setGameObject.GetComponent<TMP_Text>().text;
            string artDescription = localSOinfo.description;  //setGameObject.GetComponent<TMP_Text>().text;
            getSpriteDescription(artSprite, artTitle, artDescription);
        }
    }

    public void getSpriteDescription(Sprite image, string title, string description)
    {
        //抓取到的甘蔗或是郭懷一文件的圖片(sprite)、標題(text)和描述(text)
        //再放到暫存區Cache
        artStuff_Cache = image;
        titleText_Cache = title;
        descriptionText_Cache = description;
    }


    //當背包系統被hover的時候，就更新顯示當前物件圖片、標題和描述
    //由ItemUI底下的Border物件掛載的XR Socket Interactor中的Hover Event呼叫
    public void showSpriteDescription()
    {
        Debug.Log("被hover了");
        artStuff.sprite = artStuff_Cache;
        titleText.text = titleText_Cache;
        descriptionText.text = descriptionText_Cache;
    }

}
