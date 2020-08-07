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
    //
    private LineRenderer myLineRenderer;
    void Start()
    {
        drawPath();
        square = gameObject.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.tag == ("tagSquare"))
            {
                Debug.Log("Click Detected");
                move(this.square);
            }
        }
    }
    public void move(GameObject square)
    {
       
        square.transform.DOPath(waypointsVector3, (0.5f*waypointsVector3.Length), PathType.CatmullRom, gizmoColor: Color.blue);
        myLineRenderer.DOColor(new Color2(Color.white, Color.white), new Color2(Color.green, Color.black), 1);


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

    //if true thats true function will create straight line case of false creates curve line
    public void createLine(bool straightOrCurve)
    {
        GameObject line;
        string lineTag;
        if(straightOrCurve==true)
        {
            Debug.Log("True Döndü");
            lineTag = "tagStraightLine";
        }
        else
        {
            Debug.Log("False Döndü");
            lineTag = "tagCurveLine";
        }
        Debug.Log("Line tag:" + lineTag);
        line= GameObject.FindGameObjectWithTag(lineTag);
        line=Instantiate(line, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        line.transform.SetParent(gameObject.GetComponent<Transform>());
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

        if (GUILayout.Button("AddStraightLine", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.createLine(true);
        }
        if(GUILayout.Button("AddCurveLine", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.createLine(false);
        }


    }
}
#endif