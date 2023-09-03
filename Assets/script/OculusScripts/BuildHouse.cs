using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    public GameObject[] houses;
    public int index;
    public GameObject endCanvas, PL, buildCanvas;
    public EndCanvasManagerCh2 endCanvasManager;
    public void Build()
    {
        houses[index].SetActive(true);
        index++;
        if(index >= houses.Length)
        {
            endCanvasManager.ShowEndCanvas();
            buildCanvas.SetActive(false);   
        }
    }
    private void Start()
    {
        endCanvasManager = endCanvas.GetComponent<EndCanvasManagerCh2>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Build();
        }
    }
}
