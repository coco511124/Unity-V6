using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject pl;

    private void Start()
    {
        stopCollider = false;
        saveSystemCh3 = pl.GetComponent<SaveSystemCh3>();
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
                
            }
        }
        
    }

    private void Update()
    {
        if (stopCollider)
        {
            if(currentime < timemax)
            {
                currentime += Time.deltaTime;
            }
            else
            {
                PlayerExit.BackPosition();
                showCanvas();
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
        endPanel.enabled = true;       
    }
}
