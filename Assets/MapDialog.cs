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
        actorName.text = "原住民B";
    }
    public void PickNorth()
    {
        dialogBox.SetActive(true);
        dialogMessage.text = "哦，這土地已經是你們荷蘭人的管轄範圍了。";
    }
    public void PickYuan()
    {
        dialogBox.SetActive(true);
        dialogMessage.text = "哦，建築師，這邊就是大員市，已經是你們荷蘭人的土地了。";
    }
    public void PickRight()
    {
        SceneManager.LoadScene("2-3");
        //dialogBox.SetActive(true);
        //dialogMessage.text = "哦，這土地已經是你們荷蘭人的管轄範圍了。";
    }
    public void CloseDialog()
    {
        dialogBox.SetActive(false);
    }
}
