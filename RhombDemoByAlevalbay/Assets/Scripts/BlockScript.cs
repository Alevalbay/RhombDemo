using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    //Bool value for block status (pen/close) at start
    [SerializeField]
    private bool blockStatusAtStart;

    //Bool value for block status (pen/close) at game on

    private bool blockStatus;

    //GameObject EndPoint
    public GameObject endPoint;
    void Start()
    { 
        //Calls ControlBlock function for arrange block
        blockStatus = ControlBlock(blockStatusAtStart);
    }

    void Update()
    {

        //If i clicked square all blocks change status
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {

                // whatever tag you are looking for on your game object
                if (hit.collider.tag == "tagClickObject")
                {
                    blockStatus = ControlBlock(blockStatus);
                }
            }
        }

        //When path is complete destroy block object
        if (endPoint.GetComponent<IsPathComplete>().isPathComplete == true)
        {
            Destroy(gameObject);
        }
    }

    
    //Arrange block's component Spriterenderer and BoxCollider
    public bool ControlBlock(bool blockStatus)
    {
        if (blockStatus == true)
        {
            gameObject.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            return false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            return true;
        }
    }
    
}
