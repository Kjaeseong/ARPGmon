using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusUIView : MonoBehaviour
{
    [field: SerializeField] public Button Evolution { get; set; }
    [field: SerializeField] public Image Hp { get; set; }
    [field: SerializeField] public Image Ep { get; set; }
    [field: SerializeField] public Image Exe { get; set; }
    [field: SerializeField] public TextMeshProUGUI Level { get; set; }
}