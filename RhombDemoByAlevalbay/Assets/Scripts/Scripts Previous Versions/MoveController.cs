using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private GameObject parent;
    private Vector3[] waypointsVector3;
  
    [Range(1.0f, 10.0f), SerializeField]
    private float _moveDuration = 1.0f;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
