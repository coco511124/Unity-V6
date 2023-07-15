using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Text;
using System.Linq;
using UnityEngine.XR;

[System.Serializable]
public class SaveSystem : MonoBehaviour
{
    public List<PlayerData> pldata = new List<PlayerData>();
    [SerializeField] public string playerName;
    [SerializeField] public PlayerData player;
    [SerializeField] string type;
    [SerializeField] public static int pickupTimes;
 
    [SerializeField] public string filename = "playerdata.json";

    public static bool change;
    [SerializeField] public static int numstatic;
    [SerializeField] private int numprivate;


    private void Start()
    {
        pldata = FileHandler.ReadFromJSON<PlayerData>(filename);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "huai")
        {
            type = "�M���h�@����";
            
            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "people")
        {
            type = "�M�¦�����H����";
            
            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "green_stranger")
        {
            type = "�M��⭯�ͤH����";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));                  
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "pink_stranger")
        {
            type = "�M���⭯�ͤH����";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "blue_stranger")
        {
            type = "�M�Ŧ⭯�ͤH����";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "red_stranger")
        {
            type = "�M���⭯�ͤH����";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "thing")
        {
            type = "�I����ĸ�";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }



    }
    public void PaperSelect()
    {
        type = "�B�����";

        pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
        FileHandler.SaveToJSON<PlayerData>(pldata, filename);
    }



    //�y�{�@
    public static void add()    //�̽��I�s�o��method
    {
        numstatic++;   //�R�A�ܼ�++
        change = true; //���L�֭ȧאּTrue�A��update��k�i�H�q�Lif�P�_
        

    }
    //�y�{�G
    private void Update()
    {
        if (change == true)   //�n�O�Q���\���ܪ��� �C �i�H�����gif(change�N�i)�A�M��]���@�w�n��change�A�Υi�H�M����F�o���ܼƬ����Ӫ��󰵨ƪ��R�W�NOK
        {
            numprivate = numstatic; //�R�A�ܼƪ��ȡA�ᤩ���p���ܼ�
            pickupTimes = numprivate;
            SugarSelect();  //�I�sSugarSelect��k����log

            //�y�{�|
            //�⥬�L�֭ȧאּfalse�A����
            change = false; //
        }
    }
    //�y�{�T
    public void SugarSelect()    //�������log
    {
        //type...;
        //pldata......(..... ,numprivate);
        //FileHandler......;

        type = "�ߨ��̽�";

        pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, numprivate));
        FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        Debug.Log(numprivate);

        //�y�{�|���������L�֭ȩ��o�̤]OK�A�]�N�O change = false;�o��C
    }

}
