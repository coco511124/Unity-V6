using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch3_BoatCheck : MonoBehaviour
{
    public GameObject player;
    public Canvas endPanel;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("¸I¨ì²î");
        Vector3 forward = player.transform.forward;
        forward.y = 1;
        Vector3 x = player.transform.forward;
        x.y = 0;
        endPanel.transform.position = player.transform.position + forward * 3;
        endPanel.transform.rotation = Quaternion.LookRotation(x, Vector3.up);
        endPanel.enabled = true;
        if (other.tag == "Player")
        {
           
        }
    }
}
