using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndCanvasManager : MonoBehaviour
{
    public GameObject PL, endPanel;
    List<PlayerData> pldata = new List<PlayerData>();
    List<PlayerData> pldata10 = new List<PlayerData>();
    public Text logText;
    static bool checkOpen;

    string filename = "playerdata.json";

    private void Start()
    {
        checkOpen = false;
    }
    private void Update()
    {
        if (checkOpen)
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

        Debug.Log(pldata10);
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
