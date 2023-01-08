using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterInfoUIView : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI Name { get; set; }
    [field: SerializeField] public TextMeshProUGUI Level { get; set; }
    [field: SerializeField] public TextMeshProUGUI Hp { get; set; }
    [field: SerializeField] public TextMeshProUGUI Ep { get; set; }
    [field: SerializeField] public TextMeshProUGUI Exe { get; set; }
    [field: SerializeField] public TextMeshProUGUI Atk { get; set; }
    [field: SerializeField] public TextMeshProUGUI Dfe { get; set; }
    [field: SerializeField] public GameObject[] BackMenu { get; set; }
    [field: SerializeField] public BackButton BackButton { get; set; }
}