using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDialog : MonoBehaviour
{
    public Text actorName, dialogMessage;
    public GameObject dialogBox;
    [SerializeField] private AudioSource[] PickMapSound;
    private int currentindex;

    private void Start()
    {
        currentindex = 0;
        actorName.text = "����B";
    }
    public void PickNorth()   //currentindex = 0
    {
        PickMapSound[currentindex].Stop();
        currentindex = 0;
        PickMapSound[currentindex].Play();
        dialogBox.SetActive(true);
        dialogMessage.text = "�@�A�o�g�a�w�g�O�A�̲����H�����ҽd��F�C";
    }
    public void PickYuan()    //currentindex = 1
    {
        PickMapSound[currentindex].Stop();
        currentindex = 1;
        PickMapSound[currentindex].Play();
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
