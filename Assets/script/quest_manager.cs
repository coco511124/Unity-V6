using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest_manager : MonoBehaviour
{
    public static int peopleDiaCountChangeTag=0;
    public static int huaicount=0;
    public static int Netsircount=0;

    public BoxCollider coli_isfalse;
    public Text quest_1;

    public GameObject sugar;
    public Text quest_2;

    public GameObject netherlandpp;
    public Text quest_3;
    public GameObject huai_tagchange_forQuest4open;

    public Text quest_4;

    public GameObject blueNEtsir;
    public Text quest_5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        quest_onoff();
    }

    public void quest_onoff()
    {
        if(coli_isfalse.enabled==false)
        {
            // Debug.Log("boxcoli_false");
            //驚嘆號2_1對話完觸發 改變任務1 TEXT
            quest_1.text="<color=green>1.前往黃色驚嘆號 ✓</color>";
        }

        if(sugar.activeSelf)
        {
            quest_2.text="<color=green>2.尋找甘蔗 ✓</color>";
        }

        if(netherlandpp.tag=="Untagged"&&peopleDiaCountChangeTag==1)
        {
            quest_3.text="<color=green>3.找到荷蘭人並繳交甘蔗 ✓</color>";
            huai_tagchange_forQuest4open.tag="huai";
        }

        if(huaicount==1)
        {
            quest_4.text="<color=green>4.找到郭懷一對話獲取文件 ✓</color>";
        }

        if(blueNEtsir.tag=="people2"&&Netsircount==1)
        {
            quest_5.text="<color=green>5.尋找荷蘭人繳回文件 ✓</color>";
        }
    }
}
