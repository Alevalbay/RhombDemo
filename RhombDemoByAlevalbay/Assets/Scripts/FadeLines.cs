using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLines : MonoBehaviour
{
   
        private void OnTriggerEnter(Collider collision)
    {
        //If Square Collides with StraightLineObject or CurveLine and line objects and square sibling Lines Starts Fading 
        if ((collision.gameObject.tag == "tagStraightLine" || collision.gameObject.tag == "tagCurveLine") && collision.transform.parent == gameObject.transform.parent)
        {
            SpriteRenderer sprite;
            sprite = collision.GetComponent<SpriteRenderer>();
            sprite.DOFade(0, 1.0f);
        }
    }
}
