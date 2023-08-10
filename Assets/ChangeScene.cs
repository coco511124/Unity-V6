using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject panel1, panel2, panel3;
   public void ChangeToChapterOne(){
    SceneManager.LoadScene("lesson2");
   }
   public void ChangeToChapterTwo()
    {
        SceneManager.LoadScene("2-1");
    }
    
   public void Panel1To2(){
    panel1.SetActive(false);
    panel2.SetActive(true);
   }
   public void Panel2To1(){
    panel2.SetActive(false);
    panel1.SetActive(true);
   }
   public void Panel2To3(){
    panel2.SetActive(false);
    panel3.SetActive(true);
   }
    public void Panel3To2(){
    panel3.SetActive(false);
    panel2.SetActive(true);
   }
}
