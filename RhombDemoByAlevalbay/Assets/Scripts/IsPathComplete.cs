using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsPathComplete : MonoBehaviour
{
    //Checks path is completed
    public bool isPathComplete;

    //
    private GameObject levelController;

    //
    private GameObject[] siblingEndingPoint;
    void Start()
    {
        isPathComplete = false;
        siblingEndingPoint = GameObject.FindGameObjectsWithTag("tagEndingPoint");
        levelController = GameObject.FindGameObjectWithTag("tagLevelController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Works On Collide Square
    private void OnTriggerEnter(Collider other)
    {
        if((other.transform.tag==("tagClickObject")) && (other.transform.parent==gameObject.transform.parent))
        {
            isPathComplete = true;
            IsAllComplete();
        }
    }

    public void IsAllComplete()
    {
        for (int i = 0; i < siblingEndingPoint.Length; i++)
        {
            Debug.Log("Arıyor");
            if (siblingEndingPoint[i].GetComponent<IsPathComplete>().isPathComplete == false)
            {
                break;
            }
            else
            {
                GameObject.FindGameObjectWithTag("tagLevelController").GetComponent<LevelController>().NextLevel();
            }
        }
    }
}
