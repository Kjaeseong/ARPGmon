using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{
    [SerializeField] private GameObject _map;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private Vector2 _movePosDiff;
    private Vector2 _nowPos;
    private Vector2 _prePos;

    public void MapRotate(int Direction)
    {
        _map.transform.RotateAround(Camera.main.transform.position, Vector3.up, _rotateSpeed * Direction * Time.deltaTime);
    }

    private Vector2 PositionDrag()
    {
        _movePosDiff = Vector2.zero;
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch (0);
            if(touch.phase == TouchPhase.Began)
            {
                _prePos = touch.position - touch.deltaPosition;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                _nowPos = touch.position - touch.deltaPosition;
                _movePosDiff = (Vector2)_prePos - _nowPos;
                _prePos = touch.position - touch.deltaPosition;
            }
        }
        return -_movePosDiff;
    }

    public void MapMove()
    {
        Vector2 move = PositionDrag();

        _map.transform.position = new Vector3(
            _map.transform.position.x + (move.x *_moveSpeed * Time.deltaTime),
            _map.transform.position.y,
            _map.transform.position.z + (move.y *_moveSpeed * Time.deltaTime)
        );
    }

    public void PositionCheckEnd()
    {
        _map.transform.position = new Vector3(
            _map.transform.position.x,
            _map.transform.position.y - 1.3f,
            _map.transform.position.z
        );

        gameObject.SetActive(false);
    }
}
