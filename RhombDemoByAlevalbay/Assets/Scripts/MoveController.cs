using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetLocation = Vector3.zero;

    [Range(1.0f, 10.0f), SerializeField]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEase = Ease.Linear;

    [SerializeField]
    private DoTweenType _doTweenType = DoTweenType.MovementOneWay;
    private enum DoTweenType
    {
        MovementOneWay
    }

    void Start()
    {

        if (_doTweenType == DoTweenType.MovementOneWay)
        {
            if (_targetLocation == Vector3.zero)
            {
                _targetLocation = transform.position;


            }
            transform.DOMove(_targetLocation, _moveDuration);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
