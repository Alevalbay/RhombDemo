using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class PathController : MonoBehaviour
{
    //wayPoints Array
    public GameObject[] wayPoints;
    //Object variable for waypoint prefab
    private GameObject waypoint;
    //
    public Vector3[] waypointsVector3;
    //
    private GameObject finalWaypoint;
    //
    private GameObject square;
    void Start()
    {
        drawPath();
        square = gameObject.transform.GetChild(0).gameObject;
        move(this.square);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move(GameObject square)
    {
       
        Debug.Log(waypointsVector3.Length);
        square.transform.DOPath(waypointsVector3, (0.5f*waypointsVector3.Length), PathType.CatmullRom, gizmoColor: Color.blue);
   
    }
    public void createWaypoint(int waypointNumber)
    {
        wayPoints = new GameObject[waypointNumber];
        waypoint = GameObject.FindGameObjectWithTag("tagWaypoint");
        //For loop 1 less because last waypoint final destination
        for (int i = 0; i < waypointNumber; i++)
        {
            wayPoints[i] = Instantiate(waypoint, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            wayPoints[i].name = ("WayPoint " + (i + 1));
            wayPoints[i].transform.SetParent(gameObject.GetComponent<Transform>());
        }
        
    }

    public void drawPath()
    {
        finalWaypoint = GameObject.FindGameObjectWithTag("tagFinalWaypoint");
        

        waypointsVector3 = new Vector3[(wayPoints.Length+1)];

        //Last Destiniton point
        waypointsVector3[(waypointsVector3.Length-1)] = finalWaypoint.transform.position;

        //we need way points vector 3 value
        for (int i=0;i<wayPoints.Length;i++)
        {
            waypointsVector3[i] = wayPoints[i].transform.position;
            //Destination Point
            if(i == wayPoints.Length)
            {
                waypointsVector3[i + 1] = finalWaypoint.transform.position;
            }
        }
        
    }

    
}

#if UNITY_EDITOR
[CustomEditor(typeof(PathController))]
[System.Serializable]
[CanEditMultipleObjects]
class waypointEditor:Editor
{
    
  
    //Total number of waypoint
    private int numberOfWaypoint;
   
    //this we need this gameobject at editor code but unfortunately editor code does not accept Gameobject 
    private object path;
    public override void OnInspectorGUI()
    {
        
        //Decide Waypoint Number
        numberOfWaypoint = EditorGUILayout.IntSlider(numberOfWaypoint, 1, 25);
        //for using waypointController cs script function and variables
        PathController script = (PathController)target;

        if (GUILayout.Button("AddWayPoint"))
        {
            script.createWaypoint(numberOfWaypoint);
        }


    }
}
#endif