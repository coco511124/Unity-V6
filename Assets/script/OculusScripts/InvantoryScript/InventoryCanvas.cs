using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InventoryCanvas : MonoBehaviour
{
    public event EventHandler callOpenMeshRenderer;
    public event EventHandler callCloseMeshRenderer;


    public Transform head;
    public float spawnDistance = 0.25f;
    public GameObject invantoryCanvas;
    public InputActionProperty showInvantoryCanvasPressX;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (showInvantoryCanvasPressX.action.WasPressedThisFrame())  //����UX��
        {
            if (invantoryCanvas.GetComponent<Canvas>().enabled == false)   //�n���}canvas���e�Acanvas�O���_�Ӫ��ɭ�(false)
            {
                callOpenMeshRenderer?.Invoke(this, EventArgs.Empty);
                invantoryCanvas.GetComponent<Canvas>().enabled = true;      //�å��}canvas������Canvas����
                invantoryCanvas.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;         //�scanvas�k��

            }
            else
            {
                callCloseMeshRenderer?.Invoke(this, EventArgs.Empty);
                invantoryCanvas.GetComponent<Canvas>().enabled = false;
                invantoryCanvas.transform.position = head.position + new Vector3(head.up.x, 0, head.up.z).normalized * spawnDistance;   //��canvas���ʨ쪱�a����

            }

        }
        invantoryCanvas.transform.LookAt(new Vector3(head.position.x, invantoryCanvas.transform.position.y, head.position.z)); //���V���a
        invantoryCanvas.transform.forward *= -1;
    }

}
