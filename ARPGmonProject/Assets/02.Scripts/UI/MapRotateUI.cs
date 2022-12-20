using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotateUI : MonoBehaviour
{
    [SerializeField] private GameObject _map;
    [SerializeField][Range(0, 100)] private float _rotateSpeed;
    [SerializeField] GameObject _minimapCam;
    [SerializeField] AdventureMainUI _mainUI;

    private bool _isButtonDown;
    private int _direction;

    private void OnDisable() 
    {
        Destroy(_minimapCam);
    }

    private void FixedUpdate() 
    {
        if(_isButtonDown)
        {
            RotateMap(_direction);
        }
    }

    public void ButtonDown(int Direction)
    {
        _isButtonDown = true;
        _direction = Direction;
    }

    public void ButtonUp()
    {
        _isButtonDown = false;
        _direction = 0;
    }

    private void RotateMap(int Direction)
    {
        _map.transform.RotateAround(
            Camera.main.transform.position,
            Vector3.up,
            _rotateSpeed * Direction * Time.deltaTime
        );
    }

    public void Complete()
    {
        _mainUI.RotateComplete();
        gameObject.SetActive(false);
    }
}
