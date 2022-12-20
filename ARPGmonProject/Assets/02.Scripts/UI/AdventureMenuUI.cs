using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMenuUI : MonoBehaviour
{
    [SerializeField] private BackButton _backButton;
    [SerializeField] private AdventureMainUI _mainUI;
    [SerializeField][Tooltip("메뉴 활성화시 비활성화,\n 메뉴 비활성화시 활성화되는 오브젝트")] private GameObject[] _backMenu;

    private void Awake() 
    {
        _backButton.ParentUI = gameObject;
        _backButton.BackMenuSet(_backMenu);
    }

    public void ActivateInventory()
    {
        _mainUI.InventoryUI.gameObject.SetActive(true);
    }

    public void ActivateOption()
    {
        _mainUI.OptionUI.gameObject.SetActive(true);
    }

    public void ExitAdventure()
    {
        GameManager.Instance.Scene.Change("02.Lobby");
    }
}
