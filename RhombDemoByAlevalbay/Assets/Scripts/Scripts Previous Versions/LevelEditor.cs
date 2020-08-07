using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class LevelEditor : MonoBehaviour
{
    private GameObject path;
    void Start()
    {
}
    void Update()
    {

    }
    public void CreatePath()
    {
        path = GameObject.FindGameObjectWithTag("tagTemplate");
        path = Instantiate(path, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        path.transform.SetParent(gameObject.transform.parent);

    }
}
//For Editor Code
#if UNITY_EDITOR
[CustomEditor(typeof(LevelEditor))]
[System.Serializable]
class gameEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        
        //defination
        LevelEditor script = (LevelEditor)target;
        
        //Crate Square
        if (GUILayout.Button("Create Path", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.CreatePath();
        }
     

    }
}
#endif