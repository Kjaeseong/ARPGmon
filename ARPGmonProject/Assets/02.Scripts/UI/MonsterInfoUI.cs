using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterInfoUI : MonoBehaviour
{
    private enum StatusText
    {
        NAME, LEVEL, HP, EP, EXE, ATK, DFE
    }

    private enum DirectionButton
    {
        LEFT, CENTER, RIGHT
    }

    [SerializeField][Tooltip("정보창 활성화시 비활성화,\n 정보창 비활성화히 활성화되는 오브젝트")] private GameObject[] _backMenu;
    [SerializeField] private TextMeshProUGUI[] _infoText;
    [SerializeField] BackButton _backButton;

    private void Awake() 
    {
        _backButton.ParentUI = gameObject;
        _backButton.BackMenuSet(_backMenu);
    }

    private void OnEnable() 
    {
        RefreshText();
    }

    private void RefreshText()
    {
        TextSet((int)StatusText.NAME, GameManager.Instance.Data.Name);
        TextSet((int)StatusText.LEVEL, GameManager.Instance.Data.Level);
        
        TextSet(
            (int)StatusText.HP, 
            GameManager.Instance.Data.Level,
            GameManager.Instance.Data.MaxHP
        );

        TextSet(
            (int)StatusText.EP, 
            GameManager.Instance.Data.Level,
            GameManager.Instance.Data.MaxEP
        );
        TextSet(
            (int)StatusText.EXE, 
            GameManager.Instance.Data.Level,
            GameManager.Instance.Data.MaxEXE
        );
        
        TextSet((int)StatusText.ATK, GameManager.Instance.Data.Level);
        TextSet((int)StatusText.DFE, GameManager.Instance.Data.Level);
    }


    private void TextSet(int index, int Value, int MaxValue)
    {
        _infoText[index].text = Value.ToString() + " / " + MaxValue.ToString();
    }

    private void TextSet(int index, string Value)
    {
        _infoText[index].text = Value;
    }

    private void TextSet(int index, int Value)
    {
        _infoText[index].text = Value.ToString();
    }
}
