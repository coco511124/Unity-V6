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
 
    [SerializeField] public string filename = "playerdata.json";


    private void Start()
    {
        pldata = FileHandler.ReadFromJSON<PlayerData>(filename);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "huai")
        {
            type = "和郭懷一說話";
            
            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "people")
        {
            type = "和黑色荷蘭人說話";
            
            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "green_stranger")
        {
            type = "和綠色陌生人說話";
            
            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "pink_stranger")
        {
            type = "和粉色陌生人說話";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "blue_stranger")
        {
            type = "和藍色陌生人說話";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }
        else if (other.gameObject.tag == "red_stranger")
        {
            type = "和紅色陌生人說話";

            pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
            FileHandler.SaveToJSON<PlayerData>(pldata, filename);
        }



    }
    public void PaperSelect()
    {
        type = "拾取文件";

        pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
        FileHandler.SaveToJSON<PlayerData>(pldata, filename);
    }

    public void SugarSelect()
    {
        type = "撿取甘蔗";

        pldata.Add(new PlayerData(playerName, DateTime.Now.ToString(), type));
        FileHandler.SaveToJSON<PlayerData>(pldata, filename);
    }

}
