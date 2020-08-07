using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnding : MonoBehaviour
{
    public bool isFinished = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.transform.tag==("tagClickObject")) && (other.transform.parent==gameObject.transform.parent))
        {
            isFinished = true;
        }
    }
}
