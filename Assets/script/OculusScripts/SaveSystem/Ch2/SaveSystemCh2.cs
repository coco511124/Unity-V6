using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveSystemCh2 : MonoBehaviour
{
    //public List<PlayerDataCh2> pldataCh2= new List<PlayerDataCh2>();
    public List<PlayerDataCh2> pldataCh2;

    [SerializeField] public string filename;
    [SerializeField] public string playerName;
    [SerializeField] public string type;
    [SerializeField] PlayerDataCh2 playerDataCh2;

    private void Start()
    {
        pldataCh2 = FileHandler.ReadFromJSON<PlayerDataCh2>(filename);
    }
    public void Save()
    {
        pldataCh2.Add(new PlayerDataCh2(playerName, DateTime.Now.ToString(), type));
        FileHandler.SaveToJSON<PlayerDataCh2>(pldataCh2, filename);
    }
    public void PickNorth()
    {
        type = "選擇北線尾";
        Save();
    }
    public void PickYuan() 
    {
        type = "選擇大員";
        Save();
    }
    public void PickRight()
    {
        type = "選擇正確答案";
        Save();
    }
    public void PickRice()
    {
        type = "撿取糯米漿";
        Save();
    }
    public void PickShell()
    {
        type = "撿取蚵殼灰";
        Save();
    }
    public void PickBrick()
    {
        type = "撿取紅磚石";
        Save();
    }
    public void PickSugar()
    {
        type = "撿取糖水";
        Save();
    }
    
   
}
