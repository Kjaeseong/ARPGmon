using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyMenuUIController : MonoBehaviour
{
    private LobbyMenuUIView _view;

    private void Awake() 
    {
        _view = GetComponent<LobbyMenuUIView>();
    }

    private void Start() 
    {
        RemoveButtonEvent();
        SetButtonEvent();
    }

    private void OnDestroy() 
    {
        RemoveButtonEvent();
    }

    private void SetButtonEvent()
    {
        _view.InfoButton.onClick.AddListener(() => _view.MonsterInfoUI.gameObject.SetActive(true));
        // _view.FeedButton.onClick.AddListener();
        // _view.TrainingButton.onClick.AddListener();
        _view.OptionButton.onClick.AddListener(() => _view.OptionUI.gameObject.SetActive(true));
        _view.InventoryButton.onClick.AddListener(() => _view.InventoryUI.gameObject.SetActive(true));
        _view.AdventurButton.onClick.AddListener(() => GameManager.Instance.Scene.Change("03.Adventure"));
    }

    private void RemoveButtonEvent()
    {
        _view.InfoButton.onClick.RemoveAllListeners();
        _view.FeedButton.onClick.RemoveAllListeners();
        _view.TrainingButton.onClick.RemoveAllListeners();
        _view.OptionButton.onClick.RemoveAllListeners();
        _view.InventoryButton.onClick.RemoveAllListeners();
        _view.AdventurButton.onClick.RemoveAllListeners();
    }

    
}
