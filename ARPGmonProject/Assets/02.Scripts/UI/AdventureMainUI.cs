using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureMainUI : MonoBehaviour
{
    [field: SerializeField] public PositionCheckerUI PositionCheckerUI { get; set; }
    [field: SerializeField] public StatusUI StatusUI { get; set; }
    [field: SerializeField] public AdventureMenuUI MenuUI { get; set; }
    [field: SerializeField] public OptionUI OptionUI { get; set; }
    [field: SerializeField] public InventoryUI InventoryUI { get; set; }

    [SerializeField] private Button _menuButton;
    
    private void Start() 
    {
        _menuButton.onClick.AddListener(MenuButton);
    }

    public void RotateComplete()
    {
        StatusUI.gameObject.SetActive(true);
    }

    public void MenuButton()
    {
        MenuUI.gameObject.SetActive(true);
    }


}
