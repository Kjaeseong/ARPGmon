using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionCheckerUI : MonoBehaviour
{
    [SerializeField] private Button _rotateLeft;
    [SerializeField] private Button _rotateRight;

    [SerializeField] private Button _okButton;

    [SerializeField] private PositionChecker _checker;
    private bool _isButtonDown;
    private Coroutine _buttonDownCoroutine;
    private int _direction;
    [SerializeField] private GameObject[] _nextMenu;

    private void Start() 
    {
        _okButton.onClick.AddListener(PositionCheckComplete);
    }

    private void FixedUpdate() 
    {
        _checker.MapMove();
    }

    public void ButtonDown(int Direction)
    {
        _isButtonDown = true;
        _direction = Direction;
        _buttonDownCoroutine = StartCoroutine(ButtonDownCoroutine());
    }

    public void ButtonUp()
    {
        _isButtonDown = false;
        _direction = 0;
        StopCoroutine(_buttonDownCoroutine);
    }

    private IEnumerator ButtonDownCoroutine()
    {
        while(true)
        {
            Debug.Log("Rotate");
            _checker.MapRotate(_direction);
            yield return GameManager.Instance.Cycle;
        }
    }

    private void PositionCheckComplete()
    {
        for(int i = 0; i < _nextMenu.Length; i++)
        {
            _nextMenu[i].SetActive(true);
        }
        _checker.PositionCheckEnd();
        gameObject.SetActive(false);
    }
}
