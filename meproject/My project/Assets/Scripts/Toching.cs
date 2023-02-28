using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toching : MonoBehaviour
{
    [SerializeField] private RoadContoller _road;
    [SerializeField] private Transform _rightHand;
    [SerializeField] private float _minMagnitude;
    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = _rightHand.position;    
    }

    void Update()
    {
        var direction = _rightHand.position - _lastPosition;
        _lastPosition = _rightHand.position;
        var direction2D = new Vector2(direction.x, direction.y);
        if (direction2D.magnitude >= _minMagnitude)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x < 0)
                {
                    _road.OnSwape(RowController.Swape.left);
                    print("left");
                }
                else
                {
                    print("right");
                    _road.OnSwape(RowController.Swape.right);
                }
            }
            else
            {
                if (direction.y < 0)
                {
                    _road.OnSwape(RowController.Swape.down);
                    print("down");
                }
                else
                {
                    _road.OnSwape(RowController.Swape.up);
                    print("up");
                }
            }
        }
    }
}
