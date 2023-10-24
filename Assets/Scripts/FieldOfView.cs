using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef, xrOrigin, originFuf, finalFuf, taskPanel;
    public TMP_Text taskText;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        //playerRef = GameObject.Find("XR Origin (XR Rig)");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    Debug.Log("偵測到了，任務失敗!!");
                    xrOrigin.transform.position = new Vector3((float)-108.8, 0, (float)18.8);
                    taskPanel.SetActive(true);
                    this.GetComponent<NPCwalk>().enabled = false;
                    this.GetComponent<RandomAgent>().enabled = false;
                    //this.gameObject.transform.position = new Vector3(-113, 0, 185);
                    taskText.text = "任務失敗，請重新捕捉林爽文";
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Stick")
        {
            xrOrigin.transform.position = new Vector3((float)-108.8, 0, (float)18.8);
            originFuf.SetActive(false);
            finalFuf.SetActive(true);
            Debug.Log("hit");
            xrOrigin.gameObject.tag = "hit";
            taskPanel.SetActive(true);
            taskText.text = "任務成功，請跟福康安進行對話";
        }
    }
    public void CloseTaskPanel()
    {
        taskPanel.SetActive(false);
    }
}
