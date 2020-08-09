using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAndMoveController : MonoBehaviour
{
    //Holds Waypoints
    public List<GameObject> waypointList;

    //Game object array for hold waypiont array
    private GameObject[] waypointArray;

    
    //DoTween path only accepts Vector3
    private Vector3[] waypointsVectors;

    //For calling Restrat Function
    private GameObject lvlController;

    //For arrange square complete time
    [Range(0.1f, 5f)]
    public float squarePathCompleteTime;
    void Start()
    {
        //For calling restart function
        lvlController = GameObject.FindGameObjectWithTag("tagLevelController");

        //MiniFunction for arrange Waypoints to Vector3 because DoPath works with vector3
        waypointsVectors = new Vector3[waypointList.Count];
        waypointArray = waypointList.ToArray();
        for(int i=0 ;i<=waypointArray.Length-1;i++)
        {
            waypointsVectors[i] = waypointArray[i].transform.position;
        }
    }

  
    void Update()
    {
        //On click Square Start following  Path
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                
                // whatever tag you are looking for on your game object
                if (hit.collider.tag == "tagClickObject" && gameObject.transform.parent==hit.collider.transform.parent)
                {
                    transform.DOPath(waypointsVectors, (squarePathCompleteTime), PathType.CatmullRom);
                }
            }
        }
    }

    //If Square collides other square
    private void OnTriggerEnter(Collider collision)
    {
        //First One Checks Collision tag
        //Second One Checks sibling object
        //Third One is if Ending Point "path Completed" the collision result would be Restart 
        if ((collision.transform.tag == ("tagEndingPoint")) && (collision.transform.parent != gameObject.transform.parent) && (collision.transform.GetComponent<IsPathComplete>().isPathComplete==true))
        {
            Debug.Log("Restarting");
            lvlController.GetComponent<LevelController>().RestartLevel();
        }
    }




}
