using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLevelComplete : MonoBehaviour
{
    //Hold Levels Ending Point For Next Level function
    public GameObject[] levelEndPoınts;

    //Check EndingPoints
    public void CheckEndPointsOnLevel()
    {
        //Checks all Points if all point isPathComplete==true level would be completed if any of them false it wont work
        for (int i=0;i<levelEndPoınts.Length;i++)
        {
            
            if (levelEndPoınts[i].transform.GetComponent<IsPathComplete>().isPathComplete == false)
            {
                break;
            }
            if(i==(levelEndPoınts.Length-1))
            {
                GameObject.FindGameObjectWithTag("tagLevelController").GetComponent<LevelController>().NextLevel();
            }
        }
    }
}
