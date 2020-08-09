using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
   
    //Destroy main menu after game start 
    public void DestroyMenu()
    {
        Destroy(gameObject);
    }
}
