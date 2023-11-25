using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionCall_Portal : MonoBehaviour
{
    //��Socket���F��ɡA�N��Event�I�sMethod��۹��������L�Ƚվ㬰True
    //���ӥ��L�ȬҬ�True�ɡA�N�N�ǰe�������
    bool bramd;
    bool Image_Statue;

    bool DisplayCanvas;
    public GameObject Portal;

    [SerializeField] private string MissionContent;
    [SerializeField] private Text PlayerText;


    // Start is called before the first frame update
    void Start()
    {
        bramd = false;
        Image_Statue = false;

        DisplayCanvas = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (bramd == true && Image_Statue == true)
        {
            PortalOut();
        }
    }

    public void brand_True()
    {
        bramd = true;
    }
    public void brand_False()
    {
        bramd = false;
    }
    public void Image_Statue_True()
    {
        Image_Statue = true;
    }
    public void Image_Statue_False()
    {
        Image_Statue = false;
    }

    private void PortalOut()
    {
        if (DisplayCanvas == true)
        {
            Portal.SetActive(true);
            PlayerText.text = MissionContent;
            DisplayCanvas = false;
        }

    }
}
