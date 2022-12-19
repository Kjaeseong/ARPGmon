using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfoUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] public GameObject _backMenu;
    public Sprite _iconSprite { get; set; }
    public string _descriptionText { get; set; }
    public string _nameText { get; set; }

    private void OnEnable() 
    {
        _backMenu.SetActive(false);
    }

    private void OnDisable() 
    {
        _backMenu.SetActive(true);
    }

    private void RefreshInfo()
    {
        _icon.sprite = _iconSprite;
        _description.text = _descriptionText;
    }
}
