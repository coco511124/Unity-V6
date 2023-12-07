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
    public List<PlayerData> pldata; //= new List<PlayerData>();
    [SerializeField] public string playerName;
    [SerializeField] public PlayerData player;
    [SerializeField] string type;
    [SerializeField] public static int pickupTimes;
 
    [SerializeField] public string filename;

    public static bool change;
    [SerializeField] public static int numstatic;
    [SerializeField] private int numprivate;

    string FILENAME;

    private void Start()
    {
        pldata = FileHandler.ReadFromJSON<PlayerData>(filename);
        FILENAME = Application.persistentDataPath + "/playerdatach1.csv";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "huai")
        {
            type = "�M���h�@����";

            Save();
            
        }
        else if (other.gameObject.tag == "people")
        {
            type = "�M�¦�����H����";

            Save();
            
        }
        else if (other.gameObject.tag == "green_stranger")
        {
            type = "�M����A�k�l���";

            Save();
            
        }
        else if (other.gameObject.tag == "pink_stranger")
        {
            type = "�M������A�k�l�ҹ��";
            Save();
            
        }
        else if (other.gameObject.tag == "blue_stranger")
        {
            type = "�M�Ŧ��A�k�l���";

            Save();
            
        }
        else if (other.gameObject.tag == "red_stranger")
        {
            type = "�M�����A�k�l���";

            Save();
            
        }
        else if (other.gameObject.tag == "green_stranger1")
        {
            type = "�M������A�k�l�A���";

            Save();

        }
        else if (other.gameObject.tag == "thing")
        {
            type = "�I����ĸ�";

            Save();
            
        }



    }
    public void PaperSelect()
    {
        type = "�B�����";
        Save();
        
    }
    public void Save()
    {
        pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type, pickupTimes));
        FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        WriteToCsv(FILENAME, pldata);
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
        WriteToCsv(FILENAME, pldata);
        Debug.Log(numprivate);

        //�y�{�|���������L�֭ȩ��o�̤]OK�A�]�N�O change = false;�o��C
    }
    public void WriteToCsv(string FILENAME, List<PlayerData> pldata)
    {
        using (var dataFile = new StreamWriter(FILENAME, false, System.Text.Encoding.UTF8))
        {
            dataFile.WriteLine(returnDataRowName());
            foreach (var playerData in pldata)
            {
                dataFile.WriteLine($"{playerData.playerName}, {playerData.playerTime}, {playerData.playerActionType}, {playerData.playerPickSugar}");
            }
            dataFile.Close();
        }
        Debug.Log(FILENAME);
    }
    string returnDataRowName()
    {
        return "Name, Time, ActionType";
    }

}
