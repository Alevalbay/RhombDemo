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

    //Audio File works on Path Complete
    private AudioSource pathCompleteSound;
    void Start()
    {
        pathCompleteSound = gameObject.GetComponent<AudioSource>();
        isPathComplete = false;
    }

    //Works On Collide Square
    private void OnTriggerEnter(Collider other)
    {
        //First check for square collide end point
        //Second check for are they in same level object kit
        //Third check for if this function works every time "CheckEndPointsOnLevel" works "EndPointKit" times for exapmle at second level this function trigger twice and jump 4.th level instead of 3
        if ((other.transform.tag == ("tagClickObject")) && (other.transform.parent == gameObject.transform.parent) && ( isTriggered == false))
        {
            isPathComplete = true;
            pathCompleteSound.Play();
            GameObject.FindGameObjectWithTag("tagLevel").GetComponent<IsLevelComplete>().CheckEndPointsOnLevel();
        }
    }


}
