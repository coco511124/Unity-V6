using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ch5Changescene : MonoBehaviour
{

    public string[] sceneName;
    public int index = 0;

    private void OnTriggerEnter(Collider other)
    {
        index++;
        SceneManager.LoadScene(sceneName[index]);
        Debug.Log(index);
        this.gameObject.SetActive(false);
    }

}
