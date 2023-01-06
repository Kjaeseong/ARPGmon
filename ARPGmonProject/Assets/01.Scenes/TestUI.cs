using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;


    private void FixedUpdate() 
    {
        SetText();
    }


    private void SetText()
    {
        _text.text = GameManager.Instance.Gps.Azimuth.ToString();
    }
}
