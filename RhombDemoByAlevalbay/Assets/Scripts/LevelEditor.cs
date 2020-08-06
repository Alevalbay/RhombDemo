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
    private Object path;
    private int pathCounter=0;

    public override void OnInspectorGUI()
    {
        
        //defination
        LevelEditor script = (LevelEditor)target;
        
        //Its a little trick for use prefab file in Editor screen.Drag your prefab file as a object
        path = EditorGUILayout.ObjectField(path, typeof(Object), true);
        //Crate Square
        if (GUILayout.Button("Create Path", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            pathCounter++;
            Instantiate(path, new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
            path.name=(pathCounter+"th path");
        }
     

    }
}
#endif