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

    string FILENAME;

    private void Start()
    {
        pldataCh2 = FileHandler.ReadFromJSON<PlayerDataCh2>(filename);

        FILENAME = Application.dataPath + "/playerdatach2.csv";
    }
    public void Save()
    {
        pldataCh2.Add(new PlayerDataCh2(playerName, DateTime.Now.ToString(), type) { playerName = playerName, playerTime = DateTime.Now.ToString(), playerActionType = type });
        FileHandler.SaveToJSON<PlayerDataCh2>(pldataCh2, filename);
    }
    public void PickNorth()
    {
        type = "選擇北線尾";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void PickYuan() 
    {
        type = "選擇大員";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void PickRight()
    {
        type = "選擇正確答案";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void PickRice()
    {
        type = "撿取糯米漿";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void PickShell()
    {
        type = "撿取蚵殼灰";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void PickBrick()
    {
        type = "撿取紅磚石";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void PickSugar()
    {
        type = "撿取糖水";
        Save();
        WriteToCsv(FILENAME, pldataCh2);
    }
    public void WriteToCsv(string FILENAME, List<PlayerDataCh2> pldata2)
    {
        using (var dataFile = new StreamWriter(FILENAME))
        {
            dataFile.WriteLine(returnDataRowName());
            foreach (var playerDataCh2 in pldata2)
            {
                dataFile.WriteLine($"{playerDataCh2.playerName}, {playerDataCh2.playerTime}, {playerDataCh2.playerActionType}");
            }
            dataFile.Close();
        }
        Debug.Log(FILENAME);
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
            Debug.Log(FILENAME);
        }
    }

}
