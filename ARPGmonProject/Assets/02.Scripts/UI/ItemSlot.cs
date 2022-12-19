using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public int SlotIndex { get; set; }
    public int ItemIndex { get; set; }
    public InventoryUI Inventory { get; set; }
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _quantity;
    private Sprite _iconSprite;

    public void RefreshIcon(Sprite image, int Quantity)
    {
        _icon.sprite = image;
        _quantity.text = Quantity.ToString();
    }

    private void IconImageSet(Sprite image)
    {
        _icon.sprite = image;
    }

    private void RefreshQuantity(int Quantity)
    {
        _quantity.text = Quantity.ToString();
    }

    private void SelectItem()
    {
        Inventory.ActivateItemInfo(_iconSprite, ItemIndex);
    }
}
