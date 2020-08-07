using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RoadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision detected");
        if ((collision.gameObject.tag=="tagStraightLine" || collision.gameObject.tag == "tagCurveLine") && collision.transform.parent==gameObject.transform.parent )
        {
            Debug.Log("hello there1");
            SpriteRenderer sprite;
            sprite=collision.GetComponent<SpriteRenderer>();
            sprite.DOFade(0, 0.5f);
        }
    }

}
