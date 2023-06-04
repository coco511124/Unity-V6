using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behitten : MonoBehaviour
{
    public GameObject HideObj;
    public GameObject ShowObj;
    public GameObject hand_paper_active;
    public BoxCollider people_colli;

    void Start()
    {
        GetComponent<Itembox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void HitByRaycast()
    {
        if(Input.GetButtonDown("E"))
        {
            ShowObj.SetActive(true);
            HideObj.SetActive(false);
            if(tag=="people")
            {
            // FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            people_colli.enabled=true;//把人物boxcollider 有is trigger 的打勾
            }
            if(tag=="people2")
            {
            // FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            people_colli.enabled=true;
            quest_manager.Netsircount=1;
            }
            if(tag=="huai")
            {
            // FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            people_colli.enabled=true;
            hand_paper_active.SetActive(true);
            }
        }
    }
}
