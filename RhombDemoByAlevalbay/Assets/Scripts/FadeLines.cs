using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLines : MonoBehaviour
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
        if ((collision.gameObject.tag == "tagStraightLine" || collision.gameObject.tag == "tagCurveLine") && collision.transform.parent == gameObject.transform.parent)
        {
            SpriteRenderer sprite;
            sprite = collision.GetComponent<SpriteRenderer>();
            sprite.DOFade(0, 1.0f);
        }
    }
}
