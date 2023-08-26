using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class SaveSystemCh2 : MonoBehaviour
{
    //public List<PlayerDataCh2> pldataCh2= new List<PlayerDataCh2>();
    public List<PlayerDataCh2> pldataCh2;

    [SerializeField] public string filename;
    [SerializeField] public string playerName;
    [SerializeField] public string type;
    [SerializeField] PlayerDataCh2 playerDataCh2;

    string FILEPATH;
    string FILENAME;

    private void Start()
    {
        pldataCh2 = FileHandler.ReadFromJSON<PlayerDataCh2>(filename);
        FILEPATH = Application.dataPath;
        FILENAME = "/playerdatach2.csv";
    }
    public void Save()
    {
        pldataCh2.Add(new PlayerDataCh2(playerName, DateTime.Now.ToString(), type) { playerName = playerName, playerTime = DateTime.Now.ToString(), playerActionType = type });
        FileHandler.SaveToJSON<PlayerDataCh2>(pldataCh2, filename);
    }
    public void PickNorth()
    {
        type = "��ܥ_�u��";
        Save();
    }
    public void PickYuan() 
    {
        type = "��ܤj��";
        Save();
    }
    public void PickRight()
    {
        type = "��ܥ��T����";
        Save();
    }
    public void PickRice()
    {
        type = "�ߨ��z�̼�";
        Save();
    }
    public void PickShell()
    {
        type = "�ߨ��H�ߦ�";
        Save();
    }
    public void PickBrick()
    {
        type = "�ߨ����j��";
        Save();
    }
    public void PickSugar()
    {
        type = "�ߨ��}��";
        Save();
    }
    public void WriteToCsv(string FILENAME, List<PlayerDataCh2> pldata2)
    {
        using (var dataFile = new StreamWriter(FILEPATH + FILENAME))
        {
            dataFile.WriteLine(returnDataRowName());
            foreach (var playerDataCh2 in pldata2)
            {
                dataFile.WriteLine($"{playerDataCh2.playerName}, {playerDataCh2.playerTime}, {playerDataCh2.playerActionType}");
            }
            dataFile.Close();
        }
    }
    string returnDataRowName()
    {
        return "Name, Time, ActionType";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            WriteToCsv(FILENAME, pldataCh2);
            Debug.Log(FILEPATH + FILENAME);
        }
    }

}
