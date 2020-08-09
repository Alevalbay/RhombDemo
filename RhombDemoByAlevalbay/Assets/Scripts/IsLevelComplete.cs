using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLevelComplete : MonoBehaviour
{
    public GameObject[] levelEndPoınts;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckEndPointsOnLevel()
    {
        Debug.Log("CheckEndPointsOnLevel çalışıyor");

        for (int i=0;i<levelEndPoınts.Length;i++)
        {
            Debug.Log("Döngüye Giriliyor:"+levelEndPoınts[i].transform.GetComponent<IsPathComplete>().isPathComplete);

            if (levelEndPoınts[i].transform.GetComponent<IsPathComplete>().isPathComplete == false)
            {
                Debug.Log("Döngüden Çıkılıyor");
                break;
            }
            if(i==(levelEndPoınts.Length-1))
            {
                Debug.Log("Level Tamamlandı");
                GameObject.FindGameObjectWithTag("tagLevelController").GetComponent<LevelController>().NextLevel();
            }
        }
    }
}
