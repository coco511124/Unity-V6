using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDialog : MonoBehaviour
{
    public Text actorName, dialogMessage;
    public GameObject dialogBox;

    private void Start()
    {
        actorName.text = "����B";
    }
    public void PickNorth()
    {
        dialogBox.SetActive(true);
        dialogMessage.text = "�@�A�o�g�a�w�g�O�A�̲����H�����ҽd��F�C";
    }
    public void PickYuan()
    {
        dialogBox.SetActive(true);
        dialogMessage.text = "�@�A�ؿv�v�A�o��N�O�j�����A�w�g�O�A�̲����H���g�a�F�C";
    }
    public void PickRight()
    {
        SceneManager.LoadScene("2-3");
        //dialogBox.SetActive(true);
        //dialogMessage.text = "�@�A�o�g�a�w�g�O�A�̲����H�����ҽd��F�C";
    }
    public void CloseDialog()
    {
        dialogBox.SetActive(false);
    }
}
