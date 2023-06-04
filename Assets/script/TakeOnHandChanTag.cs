using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOnHandChanTag : MonoBehaviour
{

    public GameObject sugar;
    public GameObject papar;
    public GameObject people;
    public GameObject huai;
    public GameObject netSir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnHand();
    }

    void isOnHand()
    {
        if(sugar.activeSelf)
        {
            people.tag="people";
            quest_manager.peopleDiaCountChangeTag = 1;
        }
        
        if(papar.activeSelf)
        {
            huai.tag="huai2";
            netSir.tag="people2";
            quest_manager.huaicount=1;
        }

    }
}
