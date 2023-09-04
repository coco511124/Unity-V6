using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ch3_BoatCheck : MonoBehaviour
{
    public GameObject player;
    public Canvas endPanel;
    public VRBoatController ControllBool;

    public BoatExit PlayerExit; // the player Exit

    bool stopCollider = false;

    float timemax = 2;
    float currentime = 0;

    SaveSystemCh3 saveSystemCh3;
    EndCanvasManagerCh2 endCanvasManager;
    public GameObject pl, end;

    List<PlayerDataCh2> pldata2;
    public string filename;
    public Text log;

    private void Start()
    {
        stopCollider = false;
        saveSystemCh3 = pl.GetComponent<SaveSystemCh3>();
        endCanvasManager = end.GetComponent<EndCanvasManagerCh2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if(stopCollider == false)
            {
                ControllBool.CanControll = false;               
                Debug.Log("¸I¨ì²î");
                stopCollider = true;
            }
            if (this.gameObject.name == "wrong_cube_south")
            {
                Debug.Log("south");
                saveSystemCh3.WrongCubeSouth();
            }
            else if (this.gameObject.name == "wrong_cube_castle")
            {
                saveSystemCh3.WrongCubeCastle();
            }
            else if(this.gameObject.name == "Correct_cube")
            {
                saveSystemCh3.CorrectCube();
                //endCanvasManager.ShowEndCanvas();

            }
        }
        
    }

    private void Update()
    {
        //if (stopCollider)
        //{
        //    if (currentime < timemax)
        //    {
        //        currentime += Time.deltaTime;
        //    }
        //    else
        //    {
        //        PlayerExit.BackPosition();
        //        endCanvasManager.ReadFile();
        //        showCanvas();
        //        return;


        //    }
        //    return;
        //}
    }
    private void LateUpdate()
    {
        if (stopCollider)
        {
            if (currentime < timemax)
            {
                currentime += Time.deltaTime;
            }
            else
            {
                PlayerExit.BackPosition();
                //endCanvasManager.ReadFile();
                showCanvas();
                this.enabled = false;


            }
           
        }
    }

    private void showCanvas()
    {
        
        Vector3 forward = player.transform.forward;
        forward.y = 0.25f;
        Vector3 x = player.transform.forward;
        x.y = 0;
        endPanel.transform.position = player.transform.position + forward * 5;
        endPanel.transform.rotation = Quaternion.LookRotation(x, Vector3.up);
        pldata2 = FileHandler.ReadFromJSON<PlayerDataCh2>(filename);

        if (pldata2.Count >= 10)
        {
            foreach (var item in pldata2.GetRange(pldata2.Count - 10, 10))
            {
                log.text += item.playerName + " " + item.playerTime + " " + item.playerActionType + "\n";
                
            }

        }
        else
        {
            foreach (var item in pldata2)
            {
                log.text += item.playerName + " " + item.playerTime + " " + item.playerActionType + "\n";
            }
        }
        endPanel.enabled = true;
        return;
    }
}
