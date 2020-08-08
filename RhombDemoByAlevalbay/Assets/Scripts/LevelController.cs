using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{


    public GameObject[] levels;

    public  GameObject currentLevel;


    private int intCurrentLevel=0;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
    }



    public void NextLevel()
    {
        intCurrentLevel++;
        Destroy(currentLevel);
        Instantiate(levels[intCurrentLevel], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void RestartLevel(GameObject thisLevel)
    {
        Debug.Log("Destroying Level");
        Destroy(thisLevel);
        Instantiate(levels[intCurrentLevel], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }
   
}
