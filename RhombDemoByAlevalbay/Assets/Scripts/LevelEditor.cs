using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class LevelEditor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {

    }
}
//For Editor Code
#if UNITY_EDITOR
[CustomEditor(typeof(LevelEditor))]
[System.Serializable]
class gameEditor : Editor
{
    private GameObject square;

    int waypointNumber;
    //Check Create button for prevent waypoint system
    private bool checkWaypointMode =true;
    //


    public override void OnInspectorGUI()
    {
      
        //defination
        LevelEditor script = (LevelEditor)target;
        //How Many Waypoint will Crate?
        GUILayout.Label("Number Of Waypoint:"+waypointNumber);
        waypointNumber =EditorGUILayout.IntSlider(waypointNumber, 1,25);
        //
        square = EditorGUILayout.ObjectField(square, typeof(Object), true);
        //Crate Square Button
        if (GUILayout.Button("Create Square", GUILayout.MinWidth(100), GUILayout.Width(100)) && checkWaypointMode==true)
        {
            checkWaypointMode = false;


        }
     

    }
}
#endif