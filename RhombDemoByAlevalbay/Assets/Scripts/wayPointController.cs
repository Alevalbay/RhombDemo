using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class wayPointController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(wayPointController))]
[System.Serializable]
class waypointEditor:Editor
{
    //wayPoints Array
    public GameObject[] wayPoints = new GameObject[25];
    //Object variable for waypoint prefab
    private Object waypoint;
    //Total number of waypoint
    private int numberOfWaypoint;
   
    //this we need this gameobject at editor code but unfortunately editor code does not accept Gameobject 
    private object path;
    public override void OnInspectorGUI()
    {
        
        //Decide Waypoint Number
        numberOfWaypoint = EditorGUILayout.IntSlider(numberOfWaypoint, 1, 25);
        //assingment for waypoint variable
        waypoint = EditorGUILayout.ObjectField(waypoint, typeof(Object), true);
         
    wayPointController script = (wayPointController)target;
        if (GUILayout.Button("AddWayPoint"))
        {
            //For loop 1 less because last waypoint final destination
            for(int i=0; i<numberOfWaypoint-1;i++)
            {
             //Crate Waypoints and turn itself object to gameobject
              GameObject tempWayPoint=Instantiate(waypoint, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0))as GameObject;
             tempWayPoint.name = ("WayPoint " + (i + 1));
             wayPoints[i] = tempWayPoint;
             //WayPoints parents
             wayPoints[i].transform.SetParent(script.GetComponent<Transform>());
            }
            
        }
        
    }
    
}
#endif