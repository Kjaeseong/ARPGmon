using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionCheckerUIController : MonoBehaviour
{
    private PositionCheckerUIView _view;
    private Coroutine _buttonDownCoroutine;
    private int _direction;

    private EventTrigger.Entry _rightButtonDown = new EventTrigger.Entry();
    private EventTrigger.Entry _rightButtonUp = new EventTrigger.Entry();
    private EventTrigger.Entry _leftButtonDown = new EventTrigger.Entry();
    private EventTrigger.Entry _leftButtonUp = new EventTrigger.Entry();

    private void Awake() 
    {
        _view = GetComponent<PositionCheckerUIView>();
    }
    
    private void Start() 
    {
        _view.OKButton.onClick.AddListener(CompletePositioning);

        SetButtonDownTrigger(_view.RightButton, _rightButtonDown, 1);
        SetButtonUpTrigger(_view.RightButton, _rightButtonUp);
        SetButtonDownTrigger(_view.LeftButton, _leftButtonDown, -1);
        SetButtonUpTrigger(_view.LeftButton, _leftButtonUp);
    }

    private void FixedUpdate() 
    {
        _view.Checker.MapMove();
    }

    private void OnDestroy() 
    {
        RemoveButtonTrigger(_rightButtonDown);
        RemoveButtonTrigger(_rightButtonUp);
        RemoveButtonTrigger(_leftButtonDown);
        RemoveButtonTrigger(_leftButtonUp);
    }

    private void RemoveButtonTrigger(EventTrigger.Entry Entry)
    {
        Entry.callback.RemoveAllListeners();
    }
    
    private void SetButtonDownTrigger(EventTrigger Target, EventTrigger.Entry Entry, int direction)
    {
        Entry.eventID = EventTriggerType.PointerDown;
        Entry.callback.AddListener((data) => {ButtonDown((PointerEventData)data, direction); });
        Target.triggers.Add(Entry);
    }

    private void SetButtonUpTrigger(EventTrigger Target, EventTrigger.Entry Entry)
    {
        Entry.eventID = EventTriggerType.PointerUp;
        Entry.callback.AddListener((data) => {ButtonUp((PointerEventData)data); });
        Target.triggers.Add(Entry);
    }

    private void ButtonDown(PointerEventData data, int direction)
    {
        _direction = direction;
        _buttonDownCoroutine = StartCoroutine(MapRotateCoroutine());
    }

    private void ButtonUp(PointerEventData data)
    {
        _direction = 0;
        StopCoroutine(_buttonDownCoroutine);
    }

    // public void ButtonDown(int Direction)
    // {
    //     _direction = Direction;
    //     _buttonDownCoroutine = StartCoroutine(MapRotateCoroutine());
    // }

    // public void ButtonUp(int Direction)
    // {
    //     _direction = 0;
    //     StopCoroutine(_buttonDownCoroutine);
    // }

    private IEnumerator MapRotateCoroutine()
    {
        while(true)
        {
            Debug.Log("회전");
            _view.Checker.MapRotate(_direction);
            yield return GameManager.Instance.Cycle;
        }
    }

    private void CompletePositioning()
    {
        for(int i = 0; i < _view.NextMenu.Length; i++)
        {
            _view.NextMenu[i].SetActive(true);
        }
        _view.Checker.PositionCheckEnd();
        gameObject.SetActive(false);
    }
}
