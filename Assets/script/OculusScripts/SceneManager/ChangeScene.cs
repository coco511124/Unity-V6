using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject panel1, panel2, panel3, panel4;
    
    public void ChangeToChapterOne()
    {
    SceneManager.LoadScene("lesson2");
    }
    public void ChangeToChapterTwo()
    {
        SceneManager.LoadScene("2-1");
    }
    public void ChangeToChapterThree()
    {
        SceneManager.LoadScene("Chapter3_ChooseArea_Scene");
    }

    public void ChangeToChapterFour()
    {
        SceneManager.LoadScene("scenes4");
    }
    public void Panel1To2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    
    public void Panel2To1()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }
    public void Panel2To3()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    public void Panel3To2()
    {
        panel3.SetActive(false);
        panel2.SetActive(true);
    }
    public void Panel3To4()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }
    public void Panel4To3()
    {
        panel4.SetActive(false);
        panel3.SetActive(true);
    }
}
