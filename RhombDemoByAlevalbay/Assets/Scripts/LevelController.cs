using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    //Public Game object array for all levels
    public GameObject[] levels;

    //Public Game Objet for detec current level
    public  GameObject currentLevel;

    //Restart Auidio
    private AudioSource restartLevelAudio;

    private int intCurrentLevel = 0;

    public Text levelText;

    private 


    void Start()
    {
        restartLevelAudio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
       
    }



    public void NextLevel()
    {
        //Destory Current level for next level
        Destroy(currentLevel);
        //For Create New Level
        intCurrentLevel++;
        currentLevel =Instantiate(levels[intCurrentLevel], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        levelText.text=intCurrentLevel.ToString();
       
    }

    //Destroy Level And Create same level
    public void RestartLevel( )
    {
        restartLevelAudio.Play();
        Destroy(currentLevel);
        currentLevel=Instantiate(levels[intCurrentLevel], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }



}
