using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopButtonCollierCanvas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")   //如果物體碰到collider的話，就讓物體的MeshRenderer關掉
        {
            HuaiPaperCanvas.ShowCanvas = false;

            if (other.gameObject.GetComponent<DetectObject>() == true)
            {
                other.gameObject.GetComponent<DetectObject>().inCollider = true;
            }
            
            if (other.gameObject.GetComponent<MeshRenderer>() == true)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                List<Transform> children = GetChildren(other.gameObject.transform, true);
                foreach (Transform child in children)
                {
                    if (child.GetComponent<MeshRenderer>() == true)
                    {
                        child.GetComponent<MeshRenderer>().enabled = false;

                        if (child.GetComponent<Canvas>() == true)
                        {
                            child.GetComponent<Canvas>().enabled = false;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")   //如果物體離開collider的話，就讓物體的MeshRenderer開啟
        {
            HuaiPaperCanvas.ShowCanvas = true;

            if (other.gameObject.GetComponent<DetectObject>() == true)
            {
                other.gameObject.GetComponent<DetectObject>().inCollider = false;
            }

            if (other.gameObject.GetComponent<MeshRenderer>() == true)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                List<Transform> children = GetChildren(other.gameObject.transform, true);
                foreach (Transform child in children)
                {
                    if (child.GetComponent<MeshRenderer>() == true)
                    {
                        child.GetComponent<MeshRenderer>().enabled = true;

                        if (child.GetComponent<Canvas>() == true)
                        {
                            child.GetComponent<Canvas>().enabled = true;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
            }

            //other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    List<Transform> GetChildren(Transform parent, bool recursive)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            children.Add(child);
            if (recursive)
            {
                children.AddRange(GetChildren(child, true));
            }
        }
        return children;
    }
}
