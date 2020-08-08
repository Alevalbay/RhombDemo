using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{


    public GameObject[] levels;

    public  GameObject currentLevel;


    private int intCurrentLevel=0;

    private GameObject[] pathIsComplete;

    private bool tempIsComplete;

    private 


    void Start()
    {
    }

    void Update()
    {
       
    }



    public void NextLevel()
    {
        //Works Before new Level
        Destroy(currentLevel);
        intCurrentLevel++;
        currentLevel =Instantiate(levels[intCurrentLevel], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

        //Works after Instantiate New Level
        pathIsComplete = GameObject.FindGameObjectsWithTag("tagEndingPoint");
      
    }

    public void RestartLevel( )
    {
        Debug.Log("Destroying Level");
        Destroy(currentLevel);
        currentLevel=Instantiate(levels[intCurrentLevel], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        
    }


   
}
