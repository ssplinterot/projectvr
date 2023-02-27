using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toching : MonoBehaviour
{
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
                    RoadContoller.Instance?.OnSwape(RowController.Swape.left);
                    print("left");
                }
                else
                {
                    print("right");
                    RoadContoller.Instance?.OnSwape(RowController.Swape.right);
                }
            }
            else
            {
                if (direction.y < 0)
                {
                    RoadContoller.Instance?.OnSwape(RowController.Swape.down);
                    print("down");
                }
                else
                {
                    RoadContoller.Instance?.OnSwape(RowController.Swape.up);
                    print("up");
                }
            }
        }
    }
}
