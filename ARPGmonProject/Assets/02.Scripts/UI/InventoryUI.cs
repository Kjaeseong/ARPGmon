using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private ItemSlot[] _slot;
    [SerializeField] private ItemInfoUI _info;

    [SerializeField][Tooltip("인벤토리 활성화시 비활성화,\n인벤토리 비활성화시 활성화되는 오브젝트")] private GameObject[] _backMenu;
    [SerializeField] private BackButton _backButton;

    private void Awake() 
    {
        _backButton.ParentUI = gameObject;
        _backButton.BackMenuSet(_backMenu);
    }

    private void OnEnable() 
    {
        _info.gameObject.SetActive(false);
    }

    private void Start() 
    {
        _slot = GetComponentsInChildren<ItemSlot>();

        for(int i = 0; i < _slot.Length; i++)
        {
            _slot[i].Inventory = this;
            _slot[i].SlotIndex = i;
        }
    }

    public void ActivateItemInfo(Sprite image, int itemIndex)
    {
        _info.gameObject.SetActive(true);
        _info._iconSprite = image;
        _info._descriptionText = "---";
    }

    public void UsingItem(int SlotIndex)
    {
        // TODO : 인벤토리 기능적 구현 완료시 코드 추가
        //_slot[i].RefreshIcon()
    }
}
