using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMainUIController : MonoBehaviour
{
    private AdventureMainUIView _view;

    private void Awake() 
    {
        _view = GetComponent<AdventureMainUIView>();
    }

    private void Start() 
    {
        _view.MenuButton.onClick.AddListener(() => _view.AdventureMenuUI.SetActive(true));
    }

    private void OnDestroy() 
    {
        _view.MenuButton.onClick.RemoveAllListeners();
    }
}
