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
    
   
}
