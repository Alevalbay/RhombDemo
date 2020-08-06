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
    private Object square;

    public override void OnInspectorGUI()
    {
      
        //defination
        LevelEditor script = (LevelEditor)target;
        
        //Its a little trick for use prefab file in Editor screen.Drag your prefab file as a object
        square = EditorGUILayout.ObjectField(square, typeof(Object), true);
        //Crate Square
        if (GUILayout.Button("Create Square", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            Instantiate(square, new Vector3(0, 0, 0), Quaternion.Euler(0,0,45));
        }
     

    }
}
#endif