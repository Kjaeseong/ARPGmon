using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMenuUIController : MonoBehaviour
{
    private AdventureMenuUIView _view;

    private void Awake() 
    {
        _view = GetComponent<AdventureMenuUIView>();
        _view.BackButton.BackMenuSet(_view.BackMenu);
        _view.BackButton.ParentUI = gameObject;
    }

    private void Start() 
    {
        _view.InventoryButton.onClick.AddListener(() => _view.InventoryUI.SetActive(true));
        _view.OptionButton.onClick.AddListener(() => _view.OptionUI.SetActive(true));
        _view.ExitButton.onClick.AddListener(() => GameManager.Instance.Scene.Change("02.Lobby"));
    }

    private void OnDestroy() 
    {
        _view.InventoryButton.onClick.RemoveAllListeners();
        _view.OptionButton.onClick.RemoveAllListeners();
        _view.ExitButton.onClick.RemoveAllListeners();
    }


}
