using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsPathComplete : MonoBehaviour
{
    //Checks path is completed
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
        if((other.transform.tag==("tagClickObject")) && (other.transform.parent==gameObject.transform.parent))
        {
            isPathComplete = true;
        }
    }
}
