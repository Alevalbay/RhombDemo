using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    [SerializeField]
    private bool blockStatusAtStart;

    private bool blockStatus;

    public GameObject destinationPoint;
    void Start()
    { 
        blockStatus = ControlBlock(blockStatusAtStart);
    }

    // Update is called once per frame
    void Update()
    {

        //
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

        if (destinationPoint.GetComponent<IsPathComplete>().isPathComplete == true)
        {
            Destroy(gameObject);
        }
    }

    

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
