using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndCanvasManager : MonoBehaviour
{
    public GameObject PL, endPanel;
    List<PlayerData> pldata = new List<PlayerData>();
    public Text logText;
    static bool checkOpen;

    string filename = "playerdatach1.json"; //12��5���ק�A�bplayerdata�᭱�h�W�["ch1"�A��ܲĤ@�椸�����

    private void Start()
    {
        checkOpen = false;
    }
    private void Update()
    {
        if (checkOpen || Input.GetKeyDown(KeyCode.S))
        {
            ShowEndCanvas();
            checkOpen = false;
        }
        
    }
    public static void EndCanvas()
    {
        checkOpen = true;
    }
    private void ShowEndCanvas()
    {
        Vector3 forward = PL.transform.forward;
        forward.y = 1;
        Vector3 x = PL.transform.forward;
        x.y = 0;
        endPanel.transform.position = PL.transform.position + forward * 3;
        endPanel.transform.rotation = Quaternion.LookRotation(x, Vector3.up);

        pldata = FileHandler.ReadFromJSON<PlayerData>(filename); //Ū��json�����e

        if (pldata.Count >= 10)
        {
            foreach (var item in pldata.GetRange(pldata.Count - 10, 10))
            {
                logText.text += item.playerName + " " + item.playerTime + " " + item.playerActionType + " " + "�ߨ��̽�" + item.playerPickSugar + "��\n"; //�C�Xlog����
            }
        }
        else
        {
            foreach (var item in pldata)
            {
                logText.text += item.playerName + " " + item.playerTime + " " + item.playerActionType + " " + "�ߨ��̽�" + item.playerPickSugar + "��\n"; //�C�Xlog����
            }
        }
        
        Debug.Log(logText.text);

        endPanel.SetActive(true);
    }
}
