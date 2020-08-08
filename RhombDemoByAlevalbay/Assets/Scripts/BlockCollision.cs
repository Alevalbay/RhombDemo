using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
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

        if ((collision.transform.tag == ("tagBlock")) && (collision.transform.parent == gameObject.transform.parent))
        {
            Debug.Log("Restarting");
            lvlController.GetComponent<LevelController>().RestartLevel(gameObject.transform.parent.parent.gameObject);
        }
    }
}
