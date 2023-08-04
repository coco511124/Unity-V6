using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AllSceneManager : MonoBehaviour
{
    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
