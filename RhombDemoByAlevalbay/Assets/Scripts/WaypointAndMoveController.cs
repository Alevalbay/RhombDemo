using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAndMoveController : MonoBehaviour
{
    //Holds Waypoints
    public List<GameObject> waypointList;

    //
    private GameObject[] waypointArray;

    
    //DoTween path only accepts Vector3
    private Vector3[] waypointsVectors;
    void Start()
    {
        waypointsVectors = new Vector3[waypointList.Count];
        waypointArray = waypointList.ToArray();
        for(int i=0 ;i<=waypointArray.Length-1;i++)
        {
            waypointsVectors[i] = waypointArray[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                
                // whatever tag you are looking for on your game object
                if (hit.collider.tag == "tagClickObject" && gameObject.transform.parent==hit.collider.transform.parent)
                {
                    transform.DOPath(waypointsVectors, (2f), PathType.CatmullRom);
                }
            }
        }
    }

  


}
