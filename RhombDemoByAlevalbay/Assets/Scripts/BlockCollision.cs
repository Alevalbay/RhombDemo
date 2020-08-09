using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    //Game Object for levelController function
    private GameObject lvlController;

    void Start()
    {
        lvlController = GameObject.FindGameObjectWithTag("tagLevelController");
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        //If square hits blocks and square and block are sibling function works
        if ((collision.transform.tag == ("tagBlock")) && (collision.transform.parent == gameObject.transform.parent))
        {
            Debug.Log("Restarting");
            lvlController.GetComponent<LevelController>().RestartLevel();
        }
    }
}
