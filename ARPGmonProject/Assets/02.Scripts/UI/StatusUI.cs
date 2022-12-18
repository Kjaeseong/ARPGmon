using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusUI : MonoBehaviour
{
    [SerializeField] private Image _hpGauge;
    [SerializeField] private Image _epGauge;
    [SerializeField] private Image _exeGauge;
    [SerializeField] private TextMeshProUGUI _lvText;
    [SerializeField] private GameObject _EvolutionButton;
    [SerializeField][Tooltip("진화 버튼 활성화 여부")] private bool _evolusionButtonActivate;

    private void Start() 
    {
        _EvolutionButton.SetActive(_evolusionButtonActivate);
    }

    public void RefreshUI(int Hp, int Ep, int Exe, int Level)
    {
        RefreshGauge(_hpGauge, Hp, GameManager.Instance.Data.MaxHP);
        RefreshGauge(_epGauge, Ep, GameManager.Instance.Data.MaxEP);
        RefreshGauge(_exeGauge, Exe, GameManager.Instance.Data.MaxEXE);

        _lvText.text = "LV" + Level;
    }

    private void RefreshGauge(Image Target, int Value, int Max)
    {
        Target.fillAmount = (float)Value / Max;
    }
}
