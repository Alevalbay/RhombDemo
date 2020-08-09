using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsPathComplete : MonoBehaviour
{
    //Checks path is completed
    private bool isTriggered = false;
    public bool isPathComplete;
    void Start()
    {
        isPathComplete = false;
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Works On Collide Square
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        //First check for square collide end point
        //Second check for are they in same level object kit
        //Third check for if this function works every time "CheckEndPointsOnLevel" works "EndPointKit" times for exapmle at second level this function trigger twice and jump 4.th level instead of 3
        if ((other.transform.tag == ("tagClickObject")) && (other.transform.parent == gameObject.transform.parent) && ( isTriggered == false))
        {
            Debug.Log("This Function Triggered");
            isPathComplete = true;
            GameObject.FindGameObjectWithTag("tagLevel").GetComponent<IsLevelComplete>().CheckEndPointsOnLevel();
        }
    }


}
