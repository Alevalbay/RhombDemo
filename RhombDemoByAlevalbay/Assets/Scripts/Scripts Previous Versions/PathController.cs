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
    public List<Vector3> wayPointList;
    //Object variable for waypoint prefab
    private GameObject waypoint;
    private GameObject newWaypoint;
    //
    public Vector3[] waypointsVector3;
    //
    private GameObject finalWaypoint;
    //
    private GameObject square;
    //
    GameObject[] allWayPoints;

    void Start()
    {
        square = gameObject.transform.GetChild(0).gameObject;

        DrawPath();
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
                Move(this.square);
            }
        }
    }
    public void Move(GameObject square)
    {
        
        square.transform.DOPath(waypointsVector3, (2f), PathType.CatmullRom, gizmoColor: Color.blue);
       

    }
    public void CreateWayPoint()
    {
        waypoint = GameObject.FindGameObjectWithTag("tagTemplateWaypoint");
        newWaypoint=Instantiate(waypoint, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newWaypoint.transform.SetParent(gameObject.transform.parent);
        newWaypoint.transform.tag = "tagWaypoint";

        
    }

    public void DrawPath()
    {
        allWayPoints = GameObject.FindGameObjectsWithTag("tagWaypoint");

        for(int i=0;i<=allWayPoints.Length;i++)
        {
            waypointsVector3[i] = allWayPoints[i].transform.position;
        }

        waypointsVector3[waypointsVector3.Length + 2] = gameObject.transform.GetChild(2).transform.position;

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
        
        //for using waypointController cs script function and variables
        PathController script = (PathController)target;

        if (GUILayout.Button("AddWayPoint"))
        {
            script.CreateWayPoint();
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