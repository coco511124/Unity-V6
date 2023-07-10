using System;
using UnityEngine;
using UnityEngine.Timeline;
using System.IO;

[Serializable]
public class PlayerData
{
    [SerializeField] public string playerName;
    [SerializeField] public string playerTime;
    [SerializeField] public string playerActionType;


    public PlayerData(string name, string time, string actiontype) {
        
        playerName = name;
        playerTime = time;
        playerActionType = actiontype;
    }
}
