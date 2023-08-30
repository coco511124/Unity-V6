using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    public GameObject[] houses;
    public int index;
    public GameObject endCanvas, PL;
    public void Build()
    {
        houses[index].SetActive(true);
        index++;
        if(index >= houses.Length)
        {
            endCanvas.SetActive(true);
            Vector3 forward = PL.transform.forward;
            forward.y = 1;
            Vector3 x = PL.transform.forward;
            x.y = 0;
            endCanvas.transform.position = PL.transform.position + forward * 3;
            endCanvas.transform.rotation = Quaternion.LookRotation(x, Vector3.up);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Build();
        }
    }
}
